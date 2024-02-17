namespace Dui_Mauris_Furyball
{
    public class MultiCustomTriggerEffectItem : Item
    {
        public EffectsAndTriggerBase[] triggerEffects = new EffectsAndTriggerBase[0];

        public override BaseWearableSO Wearable()
        {
            var w = ScriptableObject.CreateInstance<MultiCustomTriggerEffectWearable>();
            w.BaseWearable(this);
            w.triggerEffects = triggerEffects;

            return w;
        }
    }
}
