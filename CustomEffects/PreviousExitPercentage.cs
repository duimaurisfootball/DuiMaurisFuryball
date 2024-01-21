namespace Dui_Mauris_Furyball.CustomEffects
{
    public class PreviousExitPercentage : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = base.PreviousExitValue * entryVariable / 100 ;
            return true;
        }
    }
}
