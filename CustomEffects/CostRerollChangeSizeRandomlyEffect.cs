namespace Dui_Mauris_Furyball
{
    public class CostRerollChangeSizeRandomlyEffect : EffectSO
    {
        public List<ManaColorSO> _newCosts;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets) 
            {
                if (targetSlotInfo.HasUnit && targetSlotInfo.Unit is CharacterCombat cc)
                {
                    foreach (var ab in cc.CombatAbilities)
                    {
                        int jobba = UnityEngine.Random.Range(-1, 1);
                        if (ab.cost.Length > 0)
                        {
                            int numbal = ab.cost.Length;
                            if (UnityEngine.Random.Range(0, 1) == 0)
                            {
                                numbal += jobba;
                            }
                            ab.cost = new ManaColorSO[numbal];
                            for (int i = 0; i < numbal; i++)
                            {
                                exitAmount++;
                                ab.cost[i] = _newCosts[UnityEngine.Random.Range(0, _newCosts.Count)];
                            }
                        }
                        if (ab.cost.Length == 0)
                        {
                            int numbal = ab.cost.Length;
                            if (UnityEngine.Random.Range(0, 2) == 0)
                            {
                                numbal++;
                            }
                            ab.cost = new ManaColorSO[numbal];
                            for (int i = 0; i < numbal; i++)
                            {
                                exitAmount++;
                                ab.cost[i] = _newCosts[UnityEngine.Random.Range(0, _newCosts.Count)];
                            }
                        }
                    }
                    foreach (CharacterCombatUIInfo characterCombatUIInfo in stats.combatUI._charactersInCombat.Values)
                    {
                        bool flag3 = characterCombatUIInfo.SlotID == targetSlotInfo.Unit.SlotID;
                        if (flag3)
                        {
                            characterCombatUIInfo.UpdateAttacks((targetSlotInfo.Unit as CharacterCombat).CombatAbilities.ToArray());
                            break;
                        }
                    }
                }
            }
            
            return false;
        }
    }
}