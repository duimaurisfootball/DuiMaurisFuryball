namespace Dui_Mauris_Furyball
{
    public class ApplyShieldFromPreviousAddEntryCustomAnimationsEffect : EffectSO
    {

        public BaseCombatTargettingSO _animationTarget;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            entryVariable = entryVariable + base.PreviousExitValue;
            exitAmount = 0;
            if (entryVariable <= 0)
            {
                return false;
            }

            if (0 < entryVariable && entryVariable <= 10)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetCharacterAbility("Wrath_1_A").visuals, _animationTarget, caster));
            }
            if (10 < entryVariable && entryVariable <= 19)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetCharacterAbility("Resolve_1_A").visuals, _animationTarget, caster));
            }
            if (19 < entryVariable && entryVariable <= 27)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetCharacterAbility("Entrenched_1_A").visuals, _animationTarget, caster));
            }
            if (27 < entryVariable && entryVariable <= 40)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetEnemyAbility("DrippingsOfTheGarden_A").visuals, _animationTarget, caster));
            }
            if (40 < entryVariable)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetEnemyAbility("BabyShower_A").visuals, _animationTarget, caster));
            }

            stats.slotStatusEffectDataBase.TryGetValue(SlotStatusEffectType.Shield, out var value);
            for (int i = 0; i < targets.Length; i++)
            {
                Shield_SlotStatusEffect shield_SlotStatusEffect = new Shield_SlotStatusEffect(targets[i].SlotID, entryVariable, targets[i].IsTargetCharacterSlot);
                shield_SlotStatusEffect.SetEffectInformation(value);
                if (stats.combatSlots.ApplySlotStatusEffect(targets[i].SlotID, targets[i].IsTargetCharacterSlot, entryVariable, shield_SlotStatusEffect))
                {
                    exitAmount += entryVariable;
                }
            }

            return exitAmount > 0;
        }
    }
}
