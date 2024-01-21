namespace Dui_Mauris_Furyball
{
    public class CheckStoredValueNumberToBoolEffect : EffectSO
    {
        public UnitStoredValueNames _valueName = (UnitStoredValueNames)258384;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            bool flag = false;
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    int valueStored = target.Unit.GetStoredValue(_valueName);

                    if (entryVariable == valueStored) 
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            Debug.Log(flag);
            return flag;
        }
    }
}
