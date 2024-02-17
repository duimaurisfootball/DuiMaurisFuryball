namespace Dui_Mauris_Furyball
{
    public class LuckyBlueAmountActuallySetEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 1;
            stats.LuckyManaAmount = entryVariable;
            return true;
        }
    }
}
