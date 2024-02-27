namespace Dui_Mauris_Furyball
{
    internal class ApplyPermanentFireEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (entryVariable <= 0)
            {
                return false;
            }

            stats.slotStatusEffectDataBase.TryGetValue(SlotStatusEffectType.OnFire, out var value);
            for (int i = 0; i < targets.Length; i++)
            {
                var onFire_SlotStatusEffect = new OnFire_SlotStatusEffect(targets[i].SlotID, 0, 1);
                onFire_SlotStatusEffect.SetEffectInformation(value);
                if (stats.combatSlots.ApplySlotStatusEffect(targets[i].SlotID, targets[i].IsTargetCharacterSlot, 0, onFire_SlotStatusEffect))
                {
                    exitAmount += entryVariable;
                }
            }

            return exitAmount > 0;
        }
    }
}
