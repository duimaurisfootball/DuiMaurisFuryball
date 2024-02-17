namespace Dui_Mauris_Furyball
{
    public class MetallurgicalScars : EffectSO
    {
        public bool _justOneTarget;

        public bool _randomBetweenPrevious;


        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            stats.statusEffectDataBase.TryGetValue(StatusEffectType.Scars, out var value);

            entryVariable = entryVariable * base.PreviousExitValue;
            entryVariable++;

            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    int amount = (_randomBetweenPrevious ? UnityEngine.Random.Range(base.PreviousExitValue, entryVariable + 1) : entryVariable);
                    Scars_StatusEffect scars_StatusEffect = new Scars_StatusEffect(amount);
                    scars_StatusEffect.SetEffectInformation(value);
                    if (targets[i].Unit.ApplyStatusEffect(scars_StatusEffect, amount))
                    {
                        exitAmount++;
                    }
                }
            }


            return exitAmount > 0;
        }
    }
}
