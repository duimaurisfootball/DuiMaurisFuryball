namespace Dui_Mauris_Furyball.CustomEffects
{
    public class ButterflyHeal : EffectSO
    {
        [SerializeField]
        public bool _directHeal = true;

        [SerializeField]
        public UnitStoredValueNames _valueNameTop = UnitStoredValueNames.PunchA;

        [SerializeField]
        public UnitStoredValueNames _valueNameBottom = UnitStoredValueNames.PunchA;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            int topHeal = entryVariable + caster.GetStoredValue(_valueNameTop);
            int bottomHeal = base.PreviousExitValue - caster.GetStoredValue(_valueNameBottom);

            if (bottomHeal < 0)
            {
                bottomHeal = 0;
            }

            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    int amount = UnityEngine.Random.Range(bottomHeal, topHeal);
                    exitAmount += targets[i].Unit.Heal(amount, HealType.Heal, _directHeal);
                }
            }

            return exitAmount > 0;
        }
    }
}