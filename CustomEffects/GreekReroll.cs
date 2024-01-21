namespace Dui_Mauris_Furyball
{
    public class GreekReroll : EffectSO
    {
        public static PigmentType AllBasicPigment = PigmentType.Yellow | PigmentType.Red | PigmentType.Blue | PigmentType.Purple;
        public static PigmentType GetOppositePigmentType(PigmentType orig)
        {
            return (PigmentType)((int)AllBasicPigment - (int)(AllBasicPigment & orig));
        }

        public static ManaColorSO GetOppositePigment(ManaColorSO orig)
        {
            var oppositeType = GetOppositePigmentType(orig.pigmentType);
            var components = new List<ManaColorSO>();
            foreach (var kvp in Pigments.PigmentDatabase)
            {
                if (oppositeType.HasFlag(kvp.Key))
                {
                    components.Add(kvp.Value);
                }
            }
            if (components.Count == 2)
            {
                return Pigments.SplitPigment(components[0], components[1]);
            }
            return orig;
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is CharacterCombat cc)
            {
                foreach (var ab in cc.CombatAbilities)
                {
                    var oldcost = ab.cost;
                    ab.cost = new ManaColorSO[oldcost.Length];
                    for (int i = 0; i < oldcost.Length; i++)
                    {
                        if ((ab.cost[i] = GetOppositePigment(oldcost[i])) != oldcost[i])
                        {
                            exitAmount++;
                        }
                        else
                        {
                            ab.cost[i] = oldcost[i];
                        }
                    }
                }
                foreach (CharacterCombatUIInfo characterCombatUIInfo in stats.combatUI._charactersInCombat.Values)
                //i don't understand this one. it's a foreach, but it seems like the next line forces it to only check the caster, so why do this more than once?
                {
                    bool flag3 = characterCombatUIInfo.SlotID == caster.SlotID;
                    //if the caster is the one being targeted this is true...? but, why?
                    if (flag3)
                    {
                        characterCombatUIInfo.UpdateAttacks((caster as CharacterCombat).CombatAbilities.ToArray());
                        //this just changes the attacks to be accurate to what they are
                        break;
                        //stop
                    }
                }
            }
            return false;
        }
    }
}
