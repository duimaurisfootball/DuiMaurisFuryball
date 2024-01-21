namespace Dui_Mauris_Furyball
{
    public class SpecialDamageShieldBlockedEffect : EffectSO
    {
        [SerializeField]
        public DeathType _deathType = DeathType.Basic;

        [SerializeField]
        public bool _usePreviousExitValue;

        [SerializeField]
        public bool _indirect;

        [SerializeField]
        public bool _returnKillAsSuccess;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (_usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            exitAmount = 0;
            bool flag = false;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    int amount = ((!stats.combatSlots.SlotContainsSlotStatusEffect(targetSlotInfo.SlotID, targetSlotInfo.IsTargetCharacterSlot, SlotStatusEffectType.Shield)) ? entryVariable : 0);
                    DamageInfo damageInfo;
                    if (_indirect)
                    {
                        damageInfo = targetSlotInfo.Unit.Damage(amount, null, _deathType, targetSlotOffset, addHealthMana: false, directDamage: false);
                    }
                    else
                    {
                        amount = caster.WillApplyDamage(exitAmount, targetSlotInfo.Unit);
                        damageInfo = targetSlotInfo.Unit.Damage(amount, caster, _deathType, targetSlotOffset, addHealthMana: true, directDamage: true);
                    }

                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;
                }
            }

            if (!_indirect && exitAmount > 0)
            {
                caster.DidApplyDamage(exitAmount);
            }

            if (!_returnKillAsSuccess)
            {
                return exitAmount > 0;
            }

            return flag;
        }
    }
    public class ApplyFrailEffectShieldBlocked : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                int amount = ((!stats.combatSlots.SlotContainsSlotStatusEffect(targetSlotInfo.SlotID, targetSlotInfo.IsTargetCharacterSlot, SlotStatusEffectType.Shield)) ? entryVariable : 0);
                stats.statusEffectDataBase.TryGetValue(StatusEffectType.Frail, out var value);
                for (int i = 0; i < targets.Length; i++)
                {
                    if (amount <= 0)
                    {
                        return false;
                    }

                    if (targets[i].HasUnit)
                    {
                        Frail_StatusEffect frail_StatusEffect = new Frail_StatusEffect(amount);
                        frail_StatusEffect.SetEffectInformation(value);
                        if (targets[i].Unit.ApplyStatusEffect(frail_StatusEffect, amount))
                        {
                            exitAmount += entryVariable;
                        }
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class ApplyRupturedEffectShieldBlocked : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                int amount = ((!stats.combatSlots.SlotContainsSlotStatusEffect(targetSlotInfo.SlotID, targetSlotInfo.IsTargetCharacterSlot, SlotStatusEffectType.Shield)) ? entryVariable : 0);
                stats.statusEffectDataBase.TryGetValue(StatusEffectType.Ruptured, out var value);
                for (int i = 0; i < targets.Length; i++)
                {
                    if (amount <= 0)
                    {
                        return false;
                    }

                    if (targets[i].HasUnit)
                    {
                        Ruptured_StatusEffect ruptured_StatusEffect = new Ruptured_StatusEffect(amount);
                        ruptured_StatusEffect.SetEffectInformation(value);
                        if (targets[i].Unit.ApplyStatusEffect(ruptured_StatusEffect, amount))
                        {
                            exitAmount += entryVariable;
                        }
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class ApplyScarsEffectShieldBlocked : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                int amount = ((!stats.combatSlots.SlotContainsSlotStatusEffect(targetSlotInfo.SlotID, targetSlotInfo.IsTargetCharacterSlot, SlotStatusEffectType.Shield)) ? entryVariable : 0);
                stats.statusEffectDataBase.TryGetValue(StatusEffectType.Scars, out var value);
                for (int i = 0; i < targets.Length; i++)
                {
                    if (amount <= 0)
                    {
                        return false;
                    }

                    if (targets[i].HasUnit)
                    {
                        Scars_StatusEffect scars_StatusEffect = new Scars_StatusEffect(amount);
                        scars_StatusEffect.SetEffectInformation(value);
                        if (targets[i].Unit.ApplyStatusEffect(scars_StatusEffect, amount))
                        {
                            exitAmount += entryVariable;
                        }
                    }
                }
            }
            return exitAmount > 0;
        }
    }

}
