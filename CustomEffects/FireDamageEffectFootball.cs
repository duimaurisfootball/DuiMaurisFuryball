using System;
using System.Collections.Generic;
using System.Text;

namespace Dui_Mauris_Furyball
{
    public class FireDamageEffectFootball : EffectSO
    {
        [SerializeField]
        public bool _usePreviousExitValue;

        [SerializeField]
        public bool _severedHeadDamage;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (_usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            if (_severedHeadDamage)
            {
                entryVariable++;
            }

            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                bool flag = targetSlotInfo.HasUnit && targetSlotInfo.Unit.ContainsStatusEffect(StatusEffectType.OilSlicked, 0);
                if (flag)
                {
                    targetSlotInfo.Unit.TryRemoveStatusEffect(StatusEffectType.OilSlicked);
                    int targetSlotOffset = areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : -1;
                    DamageInfo damageInfo = targetSlotInfo.Unit.Damage(entryVariable * 3, caster, DeathType.Fire, targetSlotOffset, false, false, false, DamageType.Fire);
                    exitAmount += damageInfo.damageAmount;
                }
                else
                {
                    bool hasUnit = targetSlotInfo.HasUnit;
                    if (hasUnit)
                    {
                        int targetSlotOffset2 = areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : -1;
                        DamageInfo damageInfo2 = targetSlotInfo.Unit.Damage(entryVariable, caster, DeathType.Fire, targetSlotOffset2, false, false, false, DamageType.Fire);
                        exitAmount += damageInfo2.damageAmount;
                    }
                }
            }
            bool flag2 = exitAmount > 0;
            if (flag2)
            {
                caster.DidApplyDamage(exitAmount);
            }
            return exitAmount > 0;
        }
    }
}
