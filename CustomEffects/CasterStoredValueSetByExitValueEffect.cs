namespace Dui_Mauris_Furyball
{
    public class CasterStoredValueSetByExitValueEffect : EffectSO
    {
        public bool _randomBetweenEntryAndPrevious = false;

        public UnitStoredValueNames _valueName = (UnitStoredValueNames)258384;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = caster.GetStoredValue(_valueName);
            int amountOut = 0;
            if (_randomBetweenEntryAndPrevious)
            {
                amountOut = UnityEngine.Random.Range(base.PreviousExitValue, entryVariable);
            }
            else
            {
                amountOut = base.PreviousExitValue;
            }
            

            exitAmount = amountOut;
            caster.SetStoredValue(_valueName, exitAmount);
            return true;
        }
    }
}
