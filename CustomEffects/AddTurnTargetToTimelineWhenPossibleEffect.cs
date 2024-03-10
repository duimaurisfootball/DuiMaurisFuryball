namespace Dui_Mauris_Furyball
{
    public class AddTurnTargetToTimelineWhenPossibleEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (entryVariable <= 0)
            {
                return false;
            }

            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && !targetSlotInfo.IsTargetCharacterSlot && targetSlotInfo.Unit.AbilityCount != 0)
                {
                    EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                    stats.timeline.TryAddNewExtraEnemyTurns(unit, entryVariable);
                    exitAmount += entryVariable;
                }
            }

            return true;
        }
    }
}
