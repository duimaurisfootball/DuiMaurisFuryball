using System;
using System.Collections.Generic;
using System.Text;

namespace Dui_Mauris_Furyball.CustomEffects
{
    internal class PendulumDamage : EffectSO
    {
        [SerializeField]
        public UnitStoredValueNames _valueNameTop = UnitStoredValueNames.PunchA;

        [SerializeField]
        public UnitStoredValueNames _valueNameBottom = UnitStoredValueNames.PunchA;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));

                    int topDamage = entryVariable + caster.GetStoredValue(_valueNameTop);
                    int bottomDamage = base.PreviousExitValue - caster.GetStoredValue(_valueNameBottom);

                    if (bottomDamage < 0)
                    {
                        bottomDamage = 0;
                    }

                    int amount = UnityEngine.Random.Range(topDamage, bottomDamage);
                    DamageInfo damageInfo;
                    {
                        amount = caster.WillApplyDamage(amount, targetSlotInfo.Unit);
                        damageInfo = targetSlotInfo.Unit.Damage(amount, caster, DeathType.Basic, targetSlotOffset, addHealthMana: true, directDamage: true);
                    }

                    exitAmount += damageInfo.damageAmount;
                }
            }
            return exitAmount > 0;
        }
    }
}
