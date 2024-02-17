namespace Dui_Mauris_Furyball
{
    public class HealByHealthColorPlusEntryVariableCarryPeviousExitValueEffect : EffectSO
    {
        public bool _usePreviousExitValue;

        public bool _directHeal = true;

        public ManaColorSO _matchingHealthColor;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            int num = base.PreviousExitValue + entryVariable;

            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && _matchingHealthColor.SharesPigmentColor(targetSlotInfo.Unit.HealthColor))
                {
                    targetSlotInfo.Unit.Heal(num, HealType.Heal, _directHeal);
                    exitAmount = base.PreviousExitValue;
                }
            }

            return exitAmount > 0;
        }
    }
}
