namespace Dui_Mauris_Furyball
{
    public class HourglassPigment : BaseWearableSO
    {
        public override bool IsItemImmediate => true;
        public override bool DoesItemTrigger => true;

        public EffectInfo[] effects;

        public override void CustomOnTriggerAttached(IWearableEffector caller)
        {
            CombatManager.Instance.AddObserver(TryConsumeWearable, LuckyPigmentPatch.LUCKY_PIGMENT_FAILED, caller);
        }
        public override void TriggerPassive(object sender, object args)
        {
            if (sender is IUnit u)
            {
                CombatManager.Instance.AddSubAction(new EffectAction(effects, u));
            }
        }
        public override void CustomOnTriggerDettached(IWearableEffector caller)
        {
            CombatManager.Instance.RemoveObserver(TryConsumeWearable, LuckyPigmentPatch.LUCKY_PIGMENT_FAILED, caller);
        }
    }
}
