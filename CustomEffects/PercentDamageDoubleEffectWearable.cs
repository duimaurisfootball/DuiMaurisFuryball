namespace Dui_Mauris_Furyball.CustomEffects
{
    public class PercentDamageDoubleEffectWearable : Item
    {
        public override BaseWearableSO Wearable()
        {
            PercentageDamageModifierEffectSetterWearable percentageDamageModifierEffectSetterWearable = ScriptableObject.CreateInstance<PercentageDamageModifierEffectSetterWearable>();
            ExtensionMethods.BaseWearable(percentageDamageModifierEffectSetterWearable, this);
            percentageDamageModifierEffectSetterWearable._useDealt = this._useDealt;
            percentageDamageModifierEffectSetterWearable._useSimpleInt = this._useSimpleInt;
            percentageDamageModifierEffectSetterWearable._doesIncrease = this._doesIncrease;
            percentageDamageModifierEffectSetterWearable._percentageToModify = this._percentageToModify;
            percentageDamageModifierEffectSetterWearable._secondPerformTriggersOn = this._secondPerformTriggersOn;
            percentageDamageModifierEffectSetterWearable._secondDoesPerformItemPopUp = this._secondDoesPerformItemPopUp;
            percentageDamageModifierEffectSetterWearable._secondEffects = this._secondEffects;
            percentageDamageModifierEffectSetterWearable._secondPerformConditions = this._secondPerformConditions;
            percentageDamageModifierEffectSetterWearable._GetsConsumedOnSecondaryUse = this._GetsConsumedOnSecondaryUse;
            percentageDamageModifierEffectSetterWearable._secondImmediateEffect = this._secondImmediateEffect;
            return percentageDamageModifierEffectSetterWearable;
        }

        [SerializeField]
        public bool _useDealt;

        [SerializeField]
        public bool _useSimpleInt;

        [SerializeField]
        public bool _doesIncrease = true;

        [SerializeField]
        [Min(1f)]
        public int _percentageToModify = 50;

        [SerializeField]
        public TriggerCalls[] _secondPerformTriggersOn;

        [SerializeField]
        public EffectorConditionSO[] _secondPerformConditions;

        [SerializeField]
        public bool _secondDoesPerformItemPopUp = true;

        [Header("Secondary Consume Data")]
        [SerializeField]
        public bool _GetsConsumedOnSecondaryUse;

        [Header("Wearable Effects")]
        [SerializeField]
        public bool _secondImmediateEffect;

        [SerializeField]
        public EffectInfo[] _secondEffects;
    }
}
