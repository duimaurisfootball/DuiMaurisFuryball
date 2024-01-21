namespace Dui_Mauris_Furyball.CustomEffects
{
    internal class CheckStoredValuePercentageEffect : EffectSO
    {
        [SerializeField]
        public bool _returnPercentage;

        [SerializeField]
        public UnitStoredValueNames _valueName = (UnitStoredValueNames)258384;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = caster.GetStoredValue(_valueName);
            if (_returnPercentage)
            {
                float gap1 = entryVariable;
                float gap2 = exitAmount;
                gap2 /= 100f;
                gap1 *= gap2;
                exitAmount = (int)Math.Floor(gap1);
            }

            return exitAmount > 0;
        }
    }
}
