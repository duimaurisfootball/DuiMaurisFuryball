namespace Dui_Mauris_Furyball
{
    public class SandyDamage : BaseWearableSO
    {
        public override bool IsItemImmediate => true;

        public override bool DoesItemTrigger => true;

        public EffectInfo[] effects;

        public override void CustomOnTriggerAttached(IWearableEffector caller)
        {
            CombatManager.Instance.AddObserver(TryConsumeWearable, WillApplyDamagePatch.WILL_APPLY_DAMAGE_CONTEXT_EVENT, caller);
        }

        public override void TriggerPassive(object sender, object args)
        {
            if (args is WillApplyDamageContext context)
            {
                if (context.target.HealthColor == Pigments.Blue)
                {
                    (context.exception).AddModifier(new PercentageValueModifierButNotStupid(true, 100, true));
                }
                if (context.target.HealthColor == Pigments.Yellow)
                {
                    (context.exception).AddModifier(new PercentageValueModifierButVeryStupid(true, 75, false));
                }
            }
        }

        public override void CustomOnTriggerDettached(IWearableEffector caller)
        {
            CombatManager.Instance.RemoveObserver(TryConsumeWearable, WillApplyDamagePatch.WILL_APPLY_DAMAGE_CONTEXT_EVENT, caller);
        }
    }
    public class PercentageValueModifierButVeryStupid : IntValueModifier
    {
        public readonly float percentage;
        public readonly bool doesIncrease;

        public PercentageValueModifierButVeryStupid(bool dmgDealt, int percent, bool increase) : base(dmgDealt ? 4 : 62)
        {
            percentage = Mathf.Max(percent, 0);
            doesIncrease = increase;
        }

        public override int Modify(int value)
        {
            float f = percentage * (float)value / 100f;
            int num = Mathf.Max(0, Mathf.FloorToInt(f));
            if (!doesIncrease)
            {
                return Mathf.Max(0, value - num);
            }
            return value + num;
        }
    }
}
