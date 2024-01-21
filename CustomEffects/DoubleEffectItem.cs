namespace Dui_Mauris_Furyball.CustomEffects
{
    public class DoubleEffectItem : Item
    {
        public Effect[] firstEffects = new Effect[0];

        public Effect[] secondEffects = new Effect[0];

        public bool _firstEffectImmediate = false;

        public bool _secondImmediateEffect = false;

        public TriggerCalls[] FirstTrigger = new TriggerCalls[0];

        public TriggerCalls[] SecondTrigger = new TriggerCalls[0];

        public bool firstPopUp = true;

        public bool secondPopUp = true;

        public EffectorConditionSO[] secondTriggerConditions = new EffectorConditionSO[0];
        public override BaseWearableSO Wearable()
        {
            CustomDoublePerformEffectWearable customDoublePerformEffectWearable = ScriptableObject.CreateInstance<CustomDoublePerformEffectWearable>();
            ExtensionMethods.BaseWearable(customDoublePerformEffectWearable, this);
            customDoublePerformEffectWearable._firstEffects = ExtensionMethods.ToEffectInfoArray(this.firstEffects);
            customDoublePerformEffectWearable._firstImmediateEffect = this._firstEffectImmediate;
            customDoublePerformEffectWearable._secondPerformTriggersOn = this.FirstTrigger;
            customDoublePerformEffectWearable.doesItemPopUp = this.firstPopUp;
            customDoublePerformEffectWearable._secondEffects = ExtensionMethods.ToEffectInfoArray(this.secondEffects);
            customDoublePerformEffectWearable._secondImmediateEffect = this._firstEffectImmediate;
            customDoublePerformEffectWearable._secondPerformTriggersOn = this.SecondTrigger;
            customDoublePerformEffectWearable._secondDoesPerformItemPopUp = this.secondPopUp;
            customDoublePerformEffectWearable._secondPerformConditions = this.secondTriggerConditions;
            return customDoublePerformEffectWearable;
        }
    }
}
