namespace Dui_Mauris_Furyball
{
    public class MultiCustomTriggerEffectWearable : BaseWearableSO
    {
        public EffectsAndTriggerBase[] triggerEffects;

        private Dictionary<int, Action<object, object>> effectMethods = new();

        public override bool IsItemImmediate => false;
        public override bool DoesItemTrigger => false;

        public override void CustomOnTriggerAttached(IWearableEffector caller)
        {
            if (triggerEffects != null)
            {
                for (var i = 0; i < triggerEffects.Length; i++)
                {
                    var te = triggerEffects[i];
                    var strings = te.TriggerStrings();

                    foreach (var str in strings)
                    {
                        CombatManager.Instance.AddObserver(GetEffectMethod(i), str, caller);
                    }
                }
            }
        }

        public override void CustomOnTriggerDettached(IWearableEffector caller)
        {
            if (triggerEffects != null)
            {
                for (var i = 0; i < triggerEffects.Length; i++)
                {
                    var te = triggerEffects[i];
                    var strings = te.TriggerStrings();

                    foreach (var str in strings)
                    {
                        CombatManager.Instance.RemoveObserver(GetEffectMethod(i), str, caller);
                    }
                }
            }
        }

        public Action<object, object> GetEffectMethod(int i)
        {
            if (effectMethods.TryGetValue(i, out var existing))
            {
                return existing;
            }
            var method = (object sender, object args) =>
            {
                TryPerformItemEffect(sender, args, i);
            };
            effectMethods[i] = method;
            return method;
        }

        public void TryPerformItemEffect(object sender, object args, int index)
        {
            if (index < triggerEffects.Length && sender is IWearableEffector effector && effector.CanWearableTrigger)
            {
                var te = triggerEffects[index];

                if (te != null)
                {
                    if (te.conditions != null)
                    {
                        foreach (var cond in te.conditions)
                        {
                            if (!cond.MeetCondition(effector, args))
                            {
                                return;
                            }
                        }
                    }

                    if (te.immediate)
                    {
                        CombatManager.Instance.ProcessImmediateAction(new PerformItemCustomImmediateAction(this, sender, args, index));
                    }
                    else
                    {
                        CombatManager.Instance.AddSubAction(new PerformItemCustomAction(this, sender, args, index));
                    }
                }
            }
        }

        public override void FinalizeCustomTriggerItem(object sender, object args, int idx)
        {
            if (idx < triggerEffects.Length && sender is IWearableEffector effector && sender is IUnit caster && !effector.IsWearableConsumed)
            {
                var te = triggerEffects[idx];

                if (te != null)
                {
                    var consumed = te.getsConsumed;
                    if (consumed)
                    {
                        effector.ConsumeWearable();
                    }
                    if (te.doesPopup)
                    {
                        CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(effector.ID, GetItemLocData().text, consumed, wearableImage));
                    }
                    if (te.immediate)
                    {
                        CombatManager.Instance.ProcessImmediateAction(new ImmediateEffectAction(te.effects, caster));
                    }
                    else
                    {
                        CombatManager.Instance.AddSubAction(new EffectAction(te.effects, caster));
                    }
                }
            }
        }
    }

    public abstract class EffectsAndTriggerBase
    {
        public EffectInfo[] effects;
        public bool immediate;
        public bool doesPopup;
        public EffectorConditionSO[] conditions;
        public bool getsConsumed;

        public abstract IEnumerable<string> TriggerStrings();
    }

    public class EffectsAndTriggerPair : EffectsAndTriggerBase
    {
        public TriggerCalls trigger;

        public override IEnumerable<string> TriggerStrings()
        {
            yield return trigger.ToString();
        }
    }

    public class EffectsAndCustomTriggerPair : EffectsAndTriggerBase
    {
        public string customTrigger;

        public override IEnumerable<string> TriggerStrings()
        {
            yield return customTrigger;
        }
    }

    public class EffectsAndMultipleTriggersPair : EffectsAndTriggerBase
    {
        public TriggerCalls[] triggers;

        public override IEnumerable<string> TriggerStrings()
        {
            foreach (var tc in triggers)
            {
                yield return triggers.ToString();
            }
        }
    }

    public class EffectsAndMultipleCustomTriggersPair : EffectsAndTriggerBase
    {
        public string[] customTriggers;

        public override IEnumerable<string> TriggerStrings()
        {
            return customTriggers;
        }
    }
}
