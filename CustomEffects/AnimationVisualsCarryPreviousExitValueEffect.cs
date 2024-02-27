namespace Dui_Mauris_Furyball
{
    public class AnimationVisualsCarryPreviousExitValueEffect : EffectSO
    {
        public AttackVisualsSO _visuals;

        public BaseCombatTargettingSO _animationTarget;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(_visuals, _animationTarget, caster));
            exitAmount = base.PreviousExitValue * entryVariable;
            return true;
        }
    }
}
