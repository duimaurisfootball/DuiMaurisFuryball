namespace Dui_Mauris_Furyball.CustomEffects
{
    public class CostRerollFromToEffect : EffectSO
    {
        public List<PigmentType> _originalCosts;

        public List<ManaColorSO> _newCosts;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is CharacterCombat cc)
            {
                foreach (var ab in cc.CombatAbilities)
                {
                    if (ab.cost.Length > 0 && ab.cost.Any(x => _originalCosts.Contains(x.pigmentType)))
                    {
                        var oldcost = ab.cost;
                        ab.cost = new ManaColorSO[oldcost.Length];
                        for (int i = 0; i < oldcost.Length; i++)
                        {
                            if (_originalCosts.Contains(oldcost[i].pigmentType))
                            {
                                exitAmount++;
                                ab.cost[i] = _newCosts[UnityEngine.Random.Range(0, _newCosts.Count)];
                            }
                            else
                            {
                                ab.cost[i] = oldcost[i];
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
