namespace Dui_Mauris_Furyball
{
    public class PenetratingHealEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && targetSlotInfo.Unit.IsAlive)
                {
                    int healthTo = Math.Min(targetSlotInfo.Unit.CurrentHealth + entryVariable, targetSlotInfo.Unit.MaximumHealth);
                    if (targetSlotInfo.Unit.SetHealthTo(healthTo))
                    {
                        exitAmount++;
                    }
                }
            }

            return exitAmount > 0;
        }
    }
}
