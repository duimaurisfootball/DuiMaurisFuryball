namespace Dui_Mauris_Furyball
{
    public class PerformRandomAbilityCheckConstructEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            AbilityDataBase abilityDB = LoadedAssetsHandler.GetAbilityDB();
            if (abilityDB == null || abilityDB.Equals(null))
            {
                return false;
            }


            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                foreach (AbilitySO randomCharacterAbility in abilityDB.GetRandomCharacterAbilities(entryVariable))
                {
                    if (targetSlotInfo.HasUnit && targetSlotInfo.Unit.ContainsPassiveAbility(PassiveAbilityTypes.Construct))
                    {
                        targetSlotInfo.Unit.TryPerformRandomAbility(randomCharacterAbility);
                        exitAmount++;
                    }
                }
            }


            return exitAmount > 0;
        }
    }
}
