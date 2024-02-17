namespace Dui_Mauris_Furyball
{
    public class CostRerollEffect : EffectSO
    {
        public static ManaColorSO[] RandomArray(int length, ManaColorSO[] OrigCost)
        {
            List<ManaColorSO> list = new List<ManaColorSO>();
            for (int i = 0; i < length; i++)
            {
                list.Add(CostRerollEffect.RandomPig());
            }
            return list.ToArray();
        }

        public static ManaColorSO RandomPig()
        {
            ManaColorSO[] array = new ManaColorSO[]
            {
                Pigments.Red,
                Pigments.Red,
                Pigments.Red,
                Pigments.Blue,
                Pigments.Blue,
                Pigments.Blue,
                Pigments.Yellow,
                Pigments.Yellow,
                Pigments.Yellow,
                Pigments.Purple,
                Pigments.Purple,
                Pigments.Purple,
                Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
                Pigments.SplitPigment(Pigments.Red, Pigments.Yellow),
                Pigments.SplitPigment(Pigments.Red, Pigments.Purple),
                Pigments.SplitPigment(Pigments.Blue, Pigments.Yellow),
                Pigments.SplitPigment(Pigments.Blue, Pigments.Purple),
                Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple),
                Pigments.Gray,
            };
            return array[UnityEngine.Random.Range(0, array.Length)];
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool flag = !caster.IsUnitCharacter;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                CharacterCombat characterCombat = caster as CharacterCombat;
                bool flag2 = characterCombat != null;
                if (flag2)
                {
                    foreach (CombatAbility combatAbility in characterCombat._combatAbilities)
                    {
                        int num = combatAbility.cost.Length;
                        combatAbility.cost = CostRerollEffect.RandomArray(num, combatAbility.cost);
                        exitAmount += num;
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
                result = (exitAmount > 0);
            }
            return result;
        }
    }
}

