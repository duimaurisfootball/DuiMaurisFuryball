namespace Dui_Mauris_Furyball
{
    public class ApplyShieldFromPreviousAddEntryEffect : EffectSO
    {

        public BaseCombatTargettingSO _animationTarget;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            entryVariable = entryVariable + base.PreviousExitValue;
            exitAmount = 0;
            if (entryVariable <= 0)
            {
                return false;
            }
            stats.slotStatusEffectDataBase.TryGetValue(SlotStatusEffectType.Shield, out var value);
            for (int i = 0; i < targets.Length; i++)
            {
                Shield_SlotStatusEffect shield_SlotStatusEffect = new Shield_SlotStatusEffect(targets[i].SlotID, entryVariable, targets[i].IsTargetCharacterSlot);
                shield_SlotStatusEffect.SetEffectInformation(value);
                if (stats.combatSlots.ApplySlotStatusEffect(targets[i].SlotID, targets[i].IsTargetCharacterSlot, entryVariable, shield_SlotStatusEffect))
                {
                    exitAmount += entryVariable;
                }
            }

            return exitAmount > 0;
        }
    }
}
