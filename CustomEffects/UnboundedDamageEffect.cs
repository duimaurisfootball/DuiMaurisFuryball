namespace Dui_Mauris_Furyball
{
    public class UnboundedDamageEffect : EffectSO
    {
        public int _repeatChance = 0;
        public int _guaranteedRepeats = 1;
        public int _multiplier = 1;
        public bool _indirect = false;
        public bool _ignoreShield = false;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool flag = false;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                int ball = 0 - _guaranteedRepeats;
                ball += entryVariable;
                for (int i = 0; i < _guaranteedRepeats;)
                {
                    ball++;
                    if (_repeatChance <= UnityEngine.Random.Range(0, 100 * _multiplier))
                    {
                        i++;
                    }
                }
                
                if (targetSlotInfo.HasUnit && _indirect)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    DamageInfo damageInfo;
                    damageInfo = targetSlotInfo.Unit.Damage(ball, null, DeathType.Basic, targetSlotOffset, false, false, _ignoreShield);
                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;
                }
                if (targetSlotInfo.HasUnit && !_indirect)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    DamageInfo damageInfo;
                    damageInfo = targetSlotInfo.Unit.Damage(ball, null, DeathType.Basic, targetSlotOffset, true, true, _ignoreShield);
                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;
                }
            }
            return flag;
        }
    }

}
