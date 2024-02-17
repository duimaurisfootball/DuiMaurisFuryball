namespace Dui_Mauris_Furyball
{
    public class RemoveAbilityOnPercentage : EffectSO
    {

        [SerializeField]
        [Range(1f, 100f)]
        public int _percentageToApply = 0;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (entryVariable <= 0)
            {
                return false;
            }

            stats.statusEffectDataBase.TryGetValue(StatusEffectType.Linked, out var value);
            for (int i = 0; i < targets.Length; i++)
            {
                foreach (TargetSlotInfo targetSlotInfo in targets)
                    if (targets[i].HasUnit && UnityEngine.Random.Range(0, 100) < _percentageToApply)
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        exitAmount += stats.timeline.TryRemoveRandomEnemyTurns(unit, entryVariable);

                    }
            }

            return exitAmount > 0;
        }
    }

}