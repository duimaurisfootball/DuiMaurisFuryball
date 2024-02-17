namespace Dui_Mauris_Furyball
{
    public class ApplyShieldByWeakestEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            List<TargetSlotInfo> list = new List<TargetSlotInfo>();
            int num = -1;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && targetSlotInfo.Unit.IsAlive)
                {
                    if (num < 0)
                    {
                        list.Add(targetSlotInfo);
                        num = targetSlotInfo.Unit.CurrentHealth;
                    }
                    else if (targetSlotInfo.Unit.CurrentHealth < num)
                    {
                        list.Clear();
                        list.Add(targetSlotInfo);
                        num = targetSlotInfo.Unit.CurrentHealth;
                    }
                    else if (targetSlotInfo.Unit.CurrentHealth == num)
                    {
                        list.Add(targetSlotInfo);
                    }
                }
            }

            stats.slotStatusEffectDataBase.TryGetValue(SlotStatusEffectType.Shield, out var value);
            foreach (TargetSlotInfo item in list)
            {
                Shield_SlotStatusEffect shield_SlotStatusEffect = new Shield_SlotStatusEffect(item.SlotID, entryVariable, item.IsTargetCharacterSlot);
                shield_SlotStatusEffect.SetEffectInformation(value);
                if (stats.combatSlots.ApplySlotStatusEffect(item.SlotID, item.IsTargetCharacterSlot, entryVariable, shield_SlotStatusEffect))
                {
                    exitAmount += entryVariable;
                }
            }

            return exitAmount > 0;
        }
    }
}
