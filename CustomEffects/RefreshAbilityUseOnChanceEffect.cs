namespace Dui_Mauris_Furyball
{
    public class RefreshAbilityUseOnChanceEffect : EffectSO
    {
        [SerializeField]
        public bool _doesExhaustInstead;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (UnityEngine.Random.Range(0, 100) < entryVariable)
                {
                    if (targets[i].HasUnit && (_doesExhaustInstead ? targets[i].Unit.ExhaustAbilityUse() : targets[i].Unit.RefreshAbilityUse()))
                    {
                        exitAmount++;
                    }
                }
            }

            return exitAmount > 0;
        }
    }
}
