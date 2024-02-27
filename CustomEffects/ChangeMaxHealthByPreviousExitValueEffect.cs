namespace Dui_Mauris_Furyball
{ 
    public class ChangeMaxHealthByPreviousExitValueEffect : EffectSO
    {
        public bool _increase = true;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    int num = entryVariable * base.PreviousExitValue;

                    int newMaxHealth = targets[i].Unit.MaximumHealth + (_increase ? num : (-num));
                    if (targets[i].Unit.MaximizeHealth(newMaxHealth))
                    {
                        exitAmount += num;
                    }
                }
            }

            return exitAmount > 0;
        }
    }
}
