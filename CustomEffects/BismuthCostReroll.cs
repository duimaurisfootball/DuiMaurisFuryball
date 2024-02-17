namespace Dui_Mauris_Furyball.CustomEffects
{
    internal class BismuthCostReroll : EffectSO
    {
        public List<ManaColorSO> _newCosts;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is CharacterCombat cc)
            {
                foreach (var ab in cc.CombatAbilities)
                {
                    if (ab.cost.Length > 0)
                    {
                        var oldcost = ab.cost;
                        ab.cost = new ManaColorSO[oldcost.Length];
                        for (int i = 0; i < oldcost.Length; i++)
                        {
                            exitAmount++;
                            ab.cost[i] = _newCosts[UnityEngine.Random.Range(0, _newCosts.Count)];
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
