namespace Dui_Mauris_Furyball
{
    public class ApplyScarsFromPreviousAddEntryCustomAnimationsEffect : EffectSO
    {
        public bool _justOneTarget;

        public bool _randomBetweenPrevious;

        public BaseCombatTargettingSO _animationTarget;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            stats.statusEffectDataBase.TryGetValue(StatusEffectType.Scars, out var value);

            entryVariable = entryVariable + base.PreviousExitValue;


            if (0 < entryVariable && entryVariable <= 3)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetCharacterAbility("Tears_1_A").visuals, _animationTarget, caster));
            }
            if (3 < entryVariable && entryVariable <= 5)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetCharacterAbility("Fumes_1_A").visuals, _animationTarget, caster));
            }
            if (5 < entryVariable && entryVariable <= 8)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetCharacterAbility("Rebuild_1_A").visuals, _animationTarget, caster));
            }
            if (8 < entryVariable && entryVariable <= 13)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetEnemyAbility("LiquidLullaby_A").visuals, _animationTarget, caster));
            }
            if (13 < entryVariable)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetEnemyAbility("TraumaBond_A").visuals, _animationTarget, caster));
            }

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
