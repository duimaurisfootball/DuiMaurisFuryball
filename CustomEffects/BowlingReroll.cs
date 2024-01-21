using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Dui_Mauris_Furyball.CustomEffects
{
    public class BowlingReroll : EffectSO
    {
        public static readonly List<(PigmentType, ManaColorSO)> pigmentQualities = new()
        {
            (PigmentType.Purple, Pigments.Purple),
            (PigmentType.Blue, Pigments.Blue),
            (PigmentType.Purple | PigmentType.Blue, Pigments.SplitPigment(Pigments.Purple, Pigments.Blue)),
            (PigmentType.Yellow, Pigments.Yellow),
            (PigmentType.Yellow | PigmentType.Purple, Pigments.SplitPigment(Pigments.Purple, Pigments.Yellow)),
            (PigmentType.Yellow | PigmentType.Blue, Pigments.SplitPigment(Pigments.Blue, Pigments.Yellow)),
            (PigmentType.Red, Pigments.Red),
            (PigmentType.Red | PigmentType.Purple, Pigments.SplitPigment(Pigments.Purple, Pigments.Red)),
            (PigmentType.Red | PigmentType.Blue, Pigments.SplitPigment(Pigments.Blue, Pigments.Red)),
            (PigmentType.Red | PigmentType.Yellow, Pigments.SplitPigment(Pigments.Yellow, Pigments.Red)),
        };
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is CharacterCombat cc)
            {
                
                foreach (var ab in cc.CombatAbilities)
                {

                    var worst = ab.cost.Where(x => pigmentQualities.Exists(x2 => x2.Item1 == x.pigmentType)).Min(x => pigmentQualities.FindIndex(x2 => x2.Item1 == x.pigmentType));
                    Debug.Log(worst);
                    if (worst + 1 < pigmentQualities.Count)
                    {
                        var oldcost = ab.cost;
                        ab.cost = new ManaColorSO[oldcost.Length];
                        var replacedWorst = false;
                        for (int i = 0; i < oldcost.Length; i++)
                        {
                            if (ab.cost.Any(x => pigmentQualities.Exists(x2 => x2.Item1 == x.pigmentType)))
                            {
                                var quality = pigmentQualities.FindIndex(x => x.Item1 == oldcost[i].pigmentType);
                                Debug.Log($"quality of cost {oldcost[i].pigmentType} for ability {ab.cost}: {quality}");
                                if (!replacedWorst && quality >= 0 && quality == worst)
                                {
                                    replacedWorst = true;
                                    ab.cost[i] = pigmentQualities[UnityEngine.Random.Range(quality + 1, pigmentQualities.Count)].Item2;
                                    Debug.Log("Cost Upgraded");
                                }
                                else
                                {
                                    ab.cost[i] = oldcost[i];
                                }
                            }
                        }
                    }
                }
                foreach (CharacterCombatUIInfo characterCombatUIInfo in stats.combatUI._charactersInCombat.Values)
                {
                    bool flag3 = characterCombatUIInfo.SlotID == caster.SlotID;
                    if (flag3)
                    {
                        characterCombatUIInfo.UpdateAttacks((caster as CharacterCombat).CombatAbilities.ToArray());
                        break;
                    }
                }
            }
            return false;
        }
    }
}
