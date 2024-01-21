namespace Dui_Mauris_Furyball.CustomEffects
{
    public class PercentageDamageModifierEffectSetterWearable : BaseWearableSO
    {
        public override bool IsItemImmediate
        {
            get
            {
                return true;
            }
        }

        public override bool DoesItemTrigger
        {
            get
            {
                return true;
            }
        }

        public override void TriggerPassive(object sender, object args)
        {
            bool useSimpleInt = this._useSimpleInt;
            if (useSimpleInt)
            {
                IntValueChangeException ex = args as IntValueChangeException;
                bool flag = ex != null && !ex.Equals(null);
                if (flag)
                {
                    ex.AddModifier(new PercentageValueModifierRoundUp(false, this._percentageToModify, this._doesIncrease));
                }
            }
            else
            {
                bool useDealt = this._useDealt;
                if (useDealt)
                {
                    DamageDealtValueChangeException ex2 = args as DamageDealtValueChangeException;
                    bool flag2 = ex2 != null && !ex2.Equals(null);
                    if (flag2)
                    {
                        ex2.AddModifier(new PercentageValueModifierRoundUp(true, this._percentageToModify, this._doesIncrease));
                    }
                }
                else
                {
                    DamageReceivedValueChangeException ex3 = args as DamageReceivedValueChangeException;
                    bool flag3 = ex3 != null && !ex3.Equals(null);
                    if (flag3)
                    {
                        ex3.AddModifier(new PercentageValueModifierRoundUp(false, this._percentageToModify, this._doesIncrease));
                    }
                }
            }
        }

        public override void CustomOnTriggerAttached(IWearableEffector caller)
        {
            foreach (TriggerCalls triggerCalls in this._secondPerformTriggersOn)
            {
                bool flag = triggerCalls != TriggerCalls.Count;
                if (flag)
                {
                    CombatManager.Instance.AddObserver(new Action<object, object>(this.TryPerformWearable), triggerCalls.ToString(), caller);
                }
            }
        }

        public override void CustomOnTriggerDettached(IWearableEffector caller)
        {
            foreach (TriggerCalls triggerCalls in this._secondPerformTriggersOn)
            {
                bool flag = triggerCalls != TriggerCalls.Count;
                if (flag)
                {
                    CombatManager.Instance.RemoveObserver(new Action<object, object>(this.TryPerformWearable), triggerCalls.ToString(), caller);
                }
            }
        }

        public override void FinalizeCustomTriggerItem(object sender, object args, int triggerID)
        {
            IWearableEffector wearableEffector = sender as IWearableEffector;
            bool flag = wearableEffector == null || wearableEffector.Equals(null);
            if (!flag)
            {
                bool isWearableConsumed = wearableEffector.IsWearableConsumed;
                if (!isWearableConsumed)
                {
                    bool itemConsumed = false;
                    bool getsConsumedOnSecondaryUse = this._GetsConsumedOnSecondaryUse;
                    if (getsConsumedOnSecondaryUse)
                    {
                        itemConsumed = true;
                        wearableEffector.ConsumeWearable();
                    }
                    bool secondDoesPerformItemPopUp = this._secondDoesPerformItemPopUp;
                    if (secondDoesPerformItemPopUp)
                    {
                        CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(wearableEffector.ID, base.GetItemLocData().text, itemConsumed, null));
                    }
                    IUnit caster = sender as IUnit;
                    bool secondImmediateEffect = this._secondImmediateEffect;
                    if (secondImmediateEffect)
                    {
                        CombatManager.Instance.ProcessImmediateAction(new ImmediateEffectAction(this._secondEffects, caster, 0), false);
                    }
                    else
                    {
                        CombatManager.Instance.AddSubAction(new EffectAction(this._secondEffects, caster, 0));
                    }
                }
            }
        }

        public void TryPerformWearable(object sender, object args)
        {
            IWearableEffector wearableEffector = sender as IWearableEffector;
            bool flag = wearableEffector == null || wearableEffector.Equals(null);
            if (!flag)
            {
                bool flag2 = !wearableEffector.CanWearableTrigger;
                if (!flag2)
                {
                    bool flag3 = this._secondPerformConditions != null && !this._secondPerformConditions.Equals(null);
                    if (flag3)
                    {
                        EffectorConditionSO[] secondPerformConditions = this._secondPerformConditions;
                        for (int i = 0; i < secondPerformConditions.Length; i++)
                        {
                            bool flag4 = !secondPerformConditions[i].MeetCondition(wearableEffector, args);
                            if (flag4)
                            {
                                return;
                            }
                        }
                    }
                    bool secondImmediateEffect = this._secondImmediateEffect;
                    if (secondImmediateEffect)
                    {
                        CombatManager.Instance.ProcessImmediateAction(new PerformItemCustomImmediateAction(this, sender, args, 0), false);
                    }
                    else
                    {
                        CombatManager.Instance.AddSubAction(new PerformItemCustomAction(this, sender, args, 0));
                    }
                }
            }
        }

        [Header("Percentage Multiplier Data")]
        [SerializeField]
        public bool _useDealt;

        [SerializeField]
        public bool _useSimpleInt;

        [SerializeField]
        public bool _doesIncrease = true;

        [SerializeField]
        [Min(1f)]
        public int _percentageToModify = 50;

        [Header("Wearable Secondary data")]
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
