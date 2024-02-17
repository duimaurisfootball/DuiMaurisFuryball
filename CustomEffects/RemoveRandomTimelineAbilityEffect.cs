namespace Dui_Mauris_Furyball
{
    public class RemoveRandomTimelineAbilityEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            List<TargetSlotInfo> list = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    list.Add(targetSlotInfo);
                }
            }

            if (list.Count <= 0)
            {
                return false;
            }
            int index = UnityEngine.Random.Range(0, list.Count);
            TargetSlotInfo targetSlotInfo2 = list[index];
            int targetSlotOffset = (areTargetSlots ? (targetSlotInfo2.SlotID - targetSlotInfo2.Unit.SlotID) : (-1));
            int amount = entryVariable;

            if (targetSlotInfo2.HasUnit && !targetSlotInfo2.IsTargetCharacterSlot)
            {
                EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo2.Unit.ID);
                exitAmount += stats.timeline.TryRemoveRandomEnemyTurns(unit, entryVariable);
            }


            return exitAmount > 0;
        }
    }
}
