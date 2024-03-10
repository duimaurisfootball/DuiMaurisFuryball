namespace Dui_Mauris_Furyball
{
    public class DamageBonusDamageEffect : EffectSO
    {
        public int _numerator = 1;
        public int _denominator = 1;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            entryVariable *= base.PreviousExitValue;
            entryVariable = entryVariable + (entryVariable * _numerator / _denominator);

            exitAmount = 0;
            bool flag = false;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    int amount = entryVariable;
                    DamageInfo damageInfo;
                    amount = caster.WillApplyDamage(amount, targetSlotInfo.Unit);
                    damageInfo = targetSlotInfo.Unit.Damage(amount, caster, DeathType.Basic, targetSlotOffset, true, true, false);
                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;
                }
            }

            return flag;
        }
    }
}
