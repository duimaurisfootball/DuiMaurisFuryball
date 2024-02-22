namespace Dui_Mauris_Furyball
{
    public class TheHorrorEffect : EffectSO
    {
        public int _repeatChance = 0;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool flag = false;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                int ball = 0;
                for (int i = 0; i < 1;)
                {
                    ball++;
                    if (_repeatChance <= UnityEngine.Random.Range(0, 100))
                    {
                        i++;
                    }
                }
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    DamageInfo damageInfo;
                    damageInfo = targetSlotInfo.Unit.Damage(ball, null, DeathType.Basic, targetSlotOffset, true, true, false);
                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;
                }
            }

            return flag;
        }
    }
}
