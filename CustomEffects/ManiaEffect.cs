using System.Collections.Generic;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

namespace Dui_Mauris_Furyball
{
    //used to be called PlaySoundDamageConsumeManaApplyScarsOnPercentageRepeatOnPercentageEffect :)
    public class ManiaEffect : EffectSO
    {
        public float _waitTime = 0;
        public string _sound;
        public int _damage = 0;
        public BaseCombatTargettingSO _extraTargets;
        public BaseCombatTargettingSO _extraTargetsAttack;
        public int _repeatChance = 0;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            bool flag = false;
            exitAmount = 0;
            List<IUnit> list = new List<IUnit>();
            List<IUnit> list2 = new List<IUnit>();
            stats.statusEffectDataBase.TryGetValue(StatusEffectType.Scars, out var value);
            for (int j = 0; j < 1;)
            {
                TargetSlotInfo[] extraTargets = _extraTargets.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter);
                TargetSlotInfo[] extraTargetsAttack = _extraTargetsAttack.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter);
                foreach (TargetSlotInfo targetSlotInfo in extraTargetsAttack)
                {
                    CombatManager.Instance.AddUIAction(new PlayStatusEffectSoundAndWaitUIAction(_sound, _waitTime));
                    if (targetSlotInfo.HasUnit)
                    {
                        int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                        int amount = _damage;
                        DamageInfo damageInfo;
                        amount = caster.WillApplyDamage(amount, targetSlotInfo.Unit);
                        damageInfo = targetSlotInfo.Unit.Damage(amount, caster, DeathType.Basic, targetSlotOffset, true, true, false);
                        flag |= damageInfo.beenKilled;
                    }
                    JumpAnimationInformation jumpInfo = stats.GenerateUnitJumpInformation(caster.ID, caster.IsUnitCharacter);
                    string manaConsumedSound = stats.audioController.manaConsumedSound;
                    stats.MainManaBar.ConsumeRandomMana(1, jumpInfo, manaConsumedSound);
                    if (UnityEngine.Random.Range(0, 1) == 0)
                    {
                        stats.MainManaBar.ConsumeRandomMana(1, jumpInfo, manaConsumedSound);
                    }
                }

                foreach (TargetSlotInfo targetSlotInfo1 in extraTargets)
                {
                    if (targetSlotInfo1.HasUnit && entryVariable > UnityEngine.Random.Range(0, 100))
                    {
                        Scars_StatusEffect scars_StatusEffect = new Scars_StatusEffect(1);
                        scars_StatusEffect.SetEffectInformation(value);
                        targetSlotInfo1.Unit.ApplyStatusEffect(scars_StatusEffect, 1);
                    }
                    for (int i = 0; i < extraTargets.Length; i++)
                    {
                        if (extraTargets[i].HasUnit)
                        {
                            IUnit unit = extraTargets[i].Unit;
                            if (unit.IsUnitCharacter && !list.Contains(unit))
                            {
                                list.Add(unit);
                            }
                            else if (!unit.IsUnitCharacter && !list2.Contains(unit))
                            {
                                list2.Add(unit);
                            }
                        }
                    }

                    foreach (IUnit item in list)
                    {
                        int num = UnityEngine.Random.Range(0, 2) * 2 - 1;
                        if (item.SlotID + num >= 0 && item.SlotID + num < stats.combatSlots.CharacterSlots.Length)
                        {
                            if (stats.combatSlots.SwapCharacters(item.SlotID, item.SlotID + num, isMandatory: true))
                            {
                                exitAmount++;
                            }

                            continue;
                        }

                        num *= -1;
                        if (item.SlotID + num >= 0 && item.SlotID + num < stats.combatSlots.CharacterSlots.Length && stats.combatSlots.SwapCharacters(item.SlotID, item.SlotID + num, isMandatory: true))
                        {
                            exitAmount++;
                        }
                    }

                    foreach (IUnit item2 in list2)
                    {
                        int num = UnityEngine.Random.Range(0, 2) * (item2.Size + 1) - 1;
                        if (stats.combatSlots.CanEnemiesSwap(item2.SlotID, item2.SlotID + num, out var firstSlotSwap, out var secondSlotSwap))
                        {
                            if (stats.combatSlots.SwapEnemies(item2.SlotID, firstSlotSwap, item2.SlotID + num, secondSlotSwap))
                            {
                                exitAmount++;
                            }

                            continue;
                        }

                        num = ((num < 0) ? item2.Size : (-1));
                        if (stats.combatSlots.CanEnemiesSwap(item2.SlotID, item2.SlotID + num, out firstSlotSwap, out secondSlotSwap) && stats.combatSlots.SwapEnemies(item2.SlotID, firstSlotSwap, item2.SlotID + num, secondSlotSwap))
                        {
                            exitAmount++;
                        }
                    }
                }
                    if (_repeatChance < UnityEngine.Random.Range(0, 100))
                {
                    j++;
                }
            }

            return true;
        }
    }
}
