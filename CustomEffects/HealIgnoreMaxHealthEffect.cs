namespace Dui_Mauris_Furyball
{
    public class HealIgnoreMaxHealthEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && targetSlotInfo.Unit.IsAlive && targetSlotInfo.Unit.CanHeal(true, 0))
                {
                    if (targetSlotInfo.Unit.SetHealthTo(targetSlotInfo.Unit.CurrentHealth + entryVariable))
                    {
                        exitAmount++;
                    }
                }
            }

            return exitAmount > 0;
        }
    }
}
