namespace Dui_Mauris_Furyball
{
    public class LeakingLeakingLeaking : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            entryVariable += caster.GetStoredValue((UnitStoredValueNames)888833) + 1;
            caster.GenerateHealthMana(entryVariable);
            exitAmount = entryVariable;
            return exitAmount > 0;
        }
    }
}
