namespace Dui_Mauris_Furyball
{
    public class SeasoningDamage : BasePassiveAbilitySO
    {
        public override bool IsPassiveImmediate => true;
        public override bool DoesPassiveTrigger => true;

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }

        public override void CustomOnTriggerAttached(IPassiveEffector caller)
        {
            CombatManager.Instance.AddObserver(TryTriggerPassive, WillApplyDamagePatch.WILL_APPLY_DAMAGE_CONTEXT_EVENT, caller);
        }

        public override void TriggerPassive(object sender, object args)
        {
            if (args is WillApplyDamageContext context)
            {
                (context.exception).AddModifier(new PercentageValueModifierButNotStupid(true, (context.target as IStatusEffector).StatusEffects.Count * 20, true));
            }
        }

        public override void CustomOnTriggerDettached(IPassiveEffector caller)
        {
            CombatManager.Instance.RemoveObserver(TryTriggerPassive, WillApplyDamagePatch.WILL_APPLY_DAMAGE_CONTEXT_EVENT, caller);
        }
    }

public class PercentageValueModifierButNotStupid : IntValueModifier
{
    public readonly float percentage;
    public readonly bool doesIncrease;

    public PercentageValueModifierButNotStupid(bool dmgDealt, int percent, bool increase) : base(dmgDealt ? 4 : 62)
    {
        percentage = Mathf.Max(percent, 0);
        doesIncrease = increase;
    }

    public override int Modify(int value)
    {
        float f = percentage * (float)value / 100f;
        int num = Mathf.Max(0, Mathf.CeilToInt(f));
        if (!doesIncrease)
        {
            return Mathf.Max(0, value - num);
        }
        return value + num;
    }
}
}
