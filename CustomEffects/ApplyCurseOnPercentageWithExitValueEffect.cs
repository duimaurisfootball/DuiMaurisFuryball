namespace Dui_Mauris_Furyball
{
    public class ApplyCurseOnPercentageWithExitValueEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            entryVariable = base.PreviousExitValue;
            exitAmount = 0;
            stats.statusEffectDataBase.TryGetValue(StatusEffectType.Cursed, out var value);
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit && UnityEngine.Random.Range(0, 100) < entryVariable)
                {
                    Cursed_StatusEffect cursed_StatusEffect = new Cursed_StatusEffect();
                    cursed_StatusEffect.SetEffectInformation(value);
                    if (targets[i].Unit.ApplyStatusEffect(cursed_StatusEffect, 0))
                    {
                        exitAmount++;
                    }
                }
            }
            return exitAmount > 0;
        }
    }
}

