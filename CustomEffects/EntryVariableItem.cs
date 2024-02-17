namespace Dui_Mauris_Furyball
{
    public class EntryVariableItem : Item
    {
        public override BaseWearableSO Wearable()
        {
            var w = ScriptableObject.CreateInstance<EntryVariableSetThing>();
            w.BaseWearable(this);

            return w;
        }
    }
}
