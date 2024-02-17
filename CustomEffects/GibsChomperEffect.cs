namespace Dui_Mauris_Furyball
{
    public class GibsChomperEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;


            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    CombatManager.Instance.AddUIAction(new SpawnEnemyGibsUIAction(targetSlotInfo.Unit.ID));
                }
            }

            return true;
        }
    }
}
