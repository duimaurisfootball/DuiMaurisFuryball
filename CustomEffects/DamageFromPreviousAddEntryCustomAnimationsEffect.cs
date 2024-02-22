namespace Dui_Mauris_Furyball
{
    public class DamageFromPreviousAddEntryCustomAnimationsEffect_A : EffectSO
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
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals, _animationTarget, caster));
            }
            if (4 < entryVariable && entryVariable <= 9)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetCharacterAbility("Buster_1_A").visuals, _animationTarget, caster));
            }
            if (9 < entryVariable && entryVariable <= 16)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetCharacterAbility("Decimation_1_A").visuals, _animationTarget, caster));
            }
            if (16 < entryVariable && entryVariable <= 24)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetEnemyAbility("Mutilate_A").visuals, _animationTarget, caster));
            }
            if (24 < entryVariable && entryVariable <= 35)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetCharacterAbility("Expire_1_A").visuals, _animationTarget, caster));
            }
            if (35 < entryVariable && entryVariable <= 50)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetCharacterAbility("Skewer_1_A").visuals, _animationTarget, caster));
            }
            if (50 < entryVariable)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetEnemyAbility("RingABell_A").visuals, _animationTarget, caster));
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
