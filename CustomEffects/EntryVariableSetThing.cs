namespace Dui_Mauris_Furyball
{
    public class EntryVariableSetThing : BaseWearableSO
    {
        public override bool IsItemImmediate => true;
        public override bool DoesItemTrigger => true;

        public EffectInfo[] effects;

        public override void CustomOnTriggerAttached(IWearableEffector caller)
        {
            CombatManager.Instance.AddObserver(TryConsumeWearable, EntryVariablePatch.MODIFY_ENTRY_VARIABLE, caller);
        }
        public override void TriggerPassive(object sender, object args)
        {
            if (args is IntegerReference intref)
            {
                intref.value = 3;
            }
        }
        public override void CustomOnTriggerDettached(IWearableEffector caller)
        {
            CombatManager.Instance.RemoveObserver(TryConsumeWearable, EntryVariablePatch.MODIFY_ENTRY_VARIABLE, caller);
        }
    }
}