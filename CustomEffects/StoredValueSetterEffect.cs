namespace Dui_Mauris_Furyball.CustomEffects
{
    internal class StoredValueSetterEffect : EffectSO
    {
        public bool _increase = true;

        public int _minimumValue = 0;

        public UnitStoredValueNames _valueName = UnitStoredValueNames.PunchA;

        public bool _randomBetweenPrevious;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                    exitAmount = targetSlotInfo.Unit.GetStoredValue(this._valueName);
                    bool randomBetweenPrevious = this._randomBetweenPrevious;
                    if (randomBetweenPrevious)
                    {
                        entryVariable = UnityEngine.Random.Range(base.PreviousExitValue, entryVariable + 1);
                    }
                    exitAmount += (this._increase ? entryVariable : (-entryVariable));
                    exitAmount = Mathf.Max(this._minimumValue, exitAmount);
                    targetSlotInfo.Unit.SetStoredValue(this._valueName, exitAmount);
            }
            return exitAmount > 0;
        }
    }
}
