namespace Dui_Mauris_Furyball
{
    public class ApplyPermanentShieldEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (entryVariable <= 0)
            {
                return false;
            }

            stats.slotStatusEffectDataBase.TryGetValue(SlotStatusEffectType.Shield, out var value);
            for (int i = 0; i < targets.Length; i++)
            {
                var shield_SlotStatusEffect = new Shield_SlotStatusEffect(targets[i].SlotID, 0, true, 1);
                shield_SlotStatusEffect.SetEffectInformation(value);
                for (int amount = 0; amount < entryVariable; amount++)
                {
                    stats.combatSlots.ApplySlotStatusEffect(targets[i].SlotID, targets[i].IsTargetCharacterSlot, 0, shield_SlotStatusEffect);
                    exitAmount += entryVariable;
                }
            }

            return exitAmount > 0;
        }
    }
}
