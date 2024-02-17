namespace Dui_Mauris_Furyball
{
    public class ApplyGuttedEffectShieldBlocked : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    int amount = ((!stats.combatSlots.SlotContainsSlotStatusEffect(targetSlotInfo.SlotID, targetSlotInfo.IsTargetCharacterSlot, SlotStatusEffectType.Shield)) ? entryVariable : 0);
                    stats.statusEffectDataBase.TryGetValue(StatusEffectType.Gutted, out var value);
                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (amount <= 0)
                        {
                            return false;
                        }

                        if (targets[i].HasUnit)
                        {
                            var StatusEffect = new Gutted_StatusEffect(amount);
                            StatusEffect.SetEffectInformation(value);
                            if (targets[i].Unit.ApplyStatusEffect(StatusEffect, amount))
                            {
                                exitAmount += entryVariable;
                            }
                        }
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class ApplyRupturedEffectShieldBlocked : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    int amount = ((!stats.combatSlots.SlotContainsSlotStatusEffect(targetSlotInfo.SlotID, targetSlotInfo.IsTargetCharacterSlot, SlotStatusEffectType.Shield)) ? entryVariable : 0);
                    stats.statusEffectDataBase.TryGetValue(StatusEffectType.Ruptured, out var value);
                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (amount <= 0)
                        {
                            return false;
                        }

                        if (targets[i].HasUnit)
                        {
                            var StatusEffect = new Ruptured_StatusEffect(amount);
                            StatusEffect.SetEffectInformation(value);
                            if (targets[i].Unit.ApplyStatusEffect(StatusEffect, amount))
                            {
                                exitAmount += entryVariable;
                            }
                        }
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class ApplyScarsEffectShieldBlocked : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    int amount = ((!stats.combatSlots.SlotContainsSlotStatusEffect(targetSlotInfo.SlotID, targetSlotInfo.IsTargetCharacterSlot, SlotStatusEffectType.Shield)) ? entryVariable : 0);
                    stats.statusEffectDataBase.TryGetValue(StatusEffectType.Scars, out var value);
                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (amount <= 0)
                        {
                            return false;
                        }

                        if (targets[i].HasUnit)
                        {
                            var StatusEffect = new Scars_StatusEffect(amount);
                            StatusEffect.SetEffectInformation(value);
                            if (targets[i].Unit.ApplyStatusEffect(StatusEffect, amount))
                            {
                                exitAmount += entryVariable;
                            }
                        }
                    }
                }
            }
            return exitAmount > 0;
        }
    }
}
