namespace Dui_Mauris_Furyball
{
    public class DamageFromPreviousAddEntryCustomAnimationsEffect_B : EffectSO
    {
        public DeathType _deathType = DeathType.Basic;

        public BaseCombatTargettingSO _animationTarget;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            entryVariable = entryVariable + base.PreviousExitValue;
            exitAmount = 0;
            bool flag = false;

            if (0 < entryVariable && entryVariable <= 4)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetCharacterAbility("PressurePoint_1_A").visuals, _animationTarget, caster));
            }
            if (4 < entryVariable && entryVariable <= 9)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetCharacterAbility("Oil_1_A").visuals, _animationTarget, caster));
            }
            if (9 < entryVariable && entryVariable <= 16)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetCharacterAbility("Sear_1_A").visuals, _animationTarget, caster));
            }
            if (16 < entryVariable && entryVariable <= 24)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetCharacterAbility("WholeAgain_1_A").visuals, _animationTarget, caster));
            }
            if (24 < entryVariable && entryVariable <= 35)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetCharacterAbility("Amalgam_1_A").visuals, _animationTarget, caster));
            }
            if (35 < entryVariable && entryVariable <= 50)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetCharacterAbility("Hex_1_A").visuals, _animationTarget, caster));
            }
            if (50 < entryVariable)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetEnemyAbility("Concentration_A").visuals, _animationTarget, caster));
            }

            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    int amount = entryVariable;
                    DamageInfo damageInfo;
                    amount = caster.WillApplyDamage(amount, targetSlotInfo.Unit);
                    damageInfo = targetSlotInfo.Unit.Damage(amount, caster, _deathType, targetSlotOffset, addHealthMana: true, directDamage: true, ignoresShield: false);

                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;
                }
            }
            return flag;
        }
    }
}
