namespace Dui_Mauris_Furyball
{
    public class HealBonusHealEffect : EffectSO
    {
        public int _numerator = 1;
        public int _denominator = 1;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            entryVariable *= base.PreviousExitValue;
            entryVariable = entryVariable + (entryVariable * _numerator / _denominator);

            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int num = entryVariable;

                    exitAmount += targetSlotInfo.Unit.Heal(num, HealType.Heal, true);
                }
            }

            return exitAmount > 0;
        }
    }
}
