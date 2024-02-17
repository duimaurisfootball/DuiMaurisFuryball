namespace Dui_Mauris_Furyball
{
    public class DamageShieldBlockedAndGibEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    int amount = ((!stats.combatSlots.SlotContainsSlotStatusEffect(targetSlotInfo.SlotID, targetSlotInfo.IsTargetCharacterSlot, SlotStatusEffectType.Shield)) ? entryVariable : 0);
                    amount = caster.WillApplyDamage(amount, targetSlotInfo.Unit);
                    CombatManager.Instance.AddUIAction(new SpawnEnemyGibsUIAction(targetSlotInfo.Unit.ID));
                    exitAmount += targetSlotInfo.Unit.Damage(amount, caster, DeathType.Basic, targetSlotOffset).damageAmount;
                }
            }

            if (exitAmount > 0)
            {
                caster.DidApplyDamage(exitAmount);
            }

            return exitAmount > 0;
        }
    }
}
