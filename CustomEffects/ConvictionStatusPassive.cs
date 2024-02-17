using Dui_Mauris_Furyball;

public class DivineProtectingPassive : BasePassiveAbilitySO
{
    public override bool IsPassiveImmediate => true;
    public override bool DoesPassiveTrigger => true;

    public int slotOffset = 1;
    public bool appliesToAllies = true;

    public static UnitStoredValueNames DIVINE_PROTECTING_PROTECTED_UNIT = (UnitStoredValueNames)18185011;

    public override void OnPassiveConnected(IUnit unit)
    {
        var target = CombatManager.Instance._stats.combatSlots.GetAllySlotTarget(unit.SlotID, slotOffset, unit.IsUnitCharacter);
        CombatManager.Instance.AddSubAction(new DivineProtectingConnectedAction(unit, this, appliesToAllies));
        unit.SetStoredValue(DIVINE_PROTECTING_PROTECTED_UNIT, -1);
    }

    public override void OnPassiveDisconnected(IUnit unit)
    {
        var currProt = GetCurrentlyProtectedUnit(unit, unit.IsUnitCharacter == appliesToAllies);
        if (currProt != null)
        {
            CombatManager.Instance.ProcessImmediateAction(new DivineProtectingDisconnectedAction(unit, currProt));
        }
        unit.SetStoredValue(DIVINE_PROTECTING_PROTECTED_UNIT, -1);
    }

    public static IUnit GetCurrentlyProtectedUnit(IUnit owner, bool isCharacter)
    {
        if (owner.GetStoredValue(DIVINE_PROTECTING_PROTECTED_UNIT) >= 0)
        {
            var uid = owner.GetStoredValue(DIVINE_PROTECTING_PROTECTED_UNIT);
            IDictionary dict = isCharacter ? CombatManager.Instance._stats.Characters : CombatManager.Instance._stats.Enemies;
            var u = dict.Contains(uid) ? dict[uid] as IUnit : null;
            if (u != null)
            {
                return u;
            }
        }
        return null;
    }

    public override void CustomOnTriggerAttached(IPassiveEffector caller)
    {
        CombatManager.Instance.AddObserver(AnyoneMoved, DisjointedStatusPassivePatch.ANYONE_MOVED, caller);
    }

    public void AnyoneMoved(object sender, object args)
    {
        if (sender is IUnit u && args is AnyoneMovedNotificationInfo notifinfo && notifinfo.unit != null && notifinfo.unit.IsUnitCharacter == u.IsUnitCharacter == appliesToAllies)
        {
            var currProt = GetCurrentlyProtectedUnit(u, u.IsUnitCharacter == appliesToAllies);
            if (notifinfo.unit == u)
            {
                var newTarget = CombatManager.Instance._stats.combatSlots.GetGenericAllySlotTarget(GetTargettedSlotId(u), u.IsUnitCharacter == appliesToAllies);
                if (newTarget == null || !newTarget.HasUnit || currProt == null || newTarget.Unit != currProt)
                {
                    if (newTarget != null && newTarget.HasUnit && newTarget.Unit != currProt)
                    {
                        CombatManager.Instance.ProcessImmediateAction(new DivineProtectingUnitAction(u, newTarget.Unit));
                    }
                    if (currProt != null)
                    {
                        CombatManager.Instance.ProcessImmediateAction(new DivineProtectingDisconnectedAction(u, currProt));
                    }
                }
            }
            else
            {
                if (notifinfo.unit == currProt && notifinfo.unit.SlotID != GetTargettedSlotId(u))
                {
                    CombatManager.Instance.ProcessImmediateAction(new DivineProtectingDisconnectedAction(u, notifinfo.unit));
                }
                else if (notifinfo.unit != currProt && notifinfo.unit.SlotID == GetTargettedSlotId(u))
                {
                    CombatManager.Instance.ProcessImmediateAction(new DivineProtectingUnitAction(u, notifinfo.unit));
                    if (currProt != null)
                    {
                        CombatManager.Instance.ProcessImmediateAction(new DivineProtectingDisconnectedAction(u, currProt));
                    }
                }
            }
        }
    }

    public int GetTargettedSlotId(IUnit attachedTo)
    {
        if (slotOffset > 0)
        {
            return attachedTo.SlotID + slotOffset + attachedTo.Size - 1;
        }
        return attachedTo.SlotID + slotOffset;
    }

    public override void CustomOnTriggerDettached(IPassiveEffector caller)
    {
        CombatManager.Instance.RemoveObserver(AnyoneMoved, DisjointedStatusPassivePatch.ANYONE_MOVED, caller);
    }

    public override void TriggerPassive(object sender, object args)
    {
    }
}

public class DivineProtectingConnectedAction(IUnit u, BasePassiveAbilitySO p, bool doAllies) : CombatAction
{
    public IUnit unit = u;
    public BasePassiveAbilitySO passive = p;
    public bool doAllies = doAllies;

    public override IEnumerator Execute(CombatStats stats)
    {
        bool valid;
        if (unit.IsUnitCharacter)
        {
            valid = stats.CharactersOnField.ContainsKey(unit.ID) && stats.CharactersOnField[unit.ID] == unit;
        }
        else
        {
            valid = stats.EnemiesOnField.ContainsKey(unit.ID) && stats.EnemiesOnField[unit.ID] == unit;
        }
        if (valid)
        {
            var target = stats.combatSlots.GetAllySlotTarget(unit.SlotID, 1, unit.IsUnitCharacter == doAllies);
            if (target != null && target.HasUnit && DivineProtectingPassive.GetCurrentlyProtectedUnit(unit, unit.IsUnitCharacter == doAllies) == null)
            {
                var showPassiveInformation = new ShowPassiveInformationUIAction(unit.ID, unit.IsUnitCharacter, passive._passiveName, passive.passiveIcon);
                yield return showPassiveInformation.Execute(stats);
                var divineProtection = new DivineProtection_StatusEffect(0, 1);
                if (stats.statusEffectDataBase.TryGetValue(divineProtection.EffectType, out var info))
                {
                    divineProtection.SetEffectInformation(info);
                }
                target.Unit.ApplyStatusEffect(divineProtection, 0);
                unit.SetStoredValue(DivineProtectingPassive.DIVINE_PROTECTING_PROTECTED_UNIT, target.Unit.ID);
            }
        }
    }
}

public class DivineProtectingDisconnectedAction(IUnit u, IUnit u2) : IImmediateAction
{
    public IUnit targetUnit = u2;
    public IUnit owner = u;

    public void Execute(CombatStats stats)
    {
        targetUnit.DettachStatusRestrictor(StatusEffectType.DivineProtection);
        if (DivineProtectingPassive.GetCurrentlyProtectedUnit(owner, targetUnit.IsUnitCharacter) == targetUnit)
        {
            owner.SetStoredValue(DivineProtectingPassive.DIVINE_PROTECTING_PROTECTED_UNIT, -1);
        }
    }
}

public class DivineProtectingUnitAction(IUnit u, IUnit u2) : IImmediateAction
{
    public IUnit targetUnit = u2;
    public IUnit owner = u;

    public void Execute(CombatStats stats)
    {
        var divineprotection = new DivineProtection_StatusEffect(0, 1);
        if (stats.statusEffectDataBase.TryGetValue(divineprotection.EffectType, out var info))
        {
            divineprotection.SetEffectInformation(info);
        }
        targetUnit.ApplyStatusEffect(divineprotection, 0);
        owner.SetStoredValue(DivineProtectingPassive.DIVINE_PROTECTING_PROTECTED_UNIT, targetUnit.ID);
    }
}