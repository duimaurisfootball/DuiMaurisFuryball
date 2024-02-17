namespace Dui_Mauris_Furyball
{
    public class DustItem : Item
    {
        public Effect[] effects = new Effect[0];
        public bool addResultToEffect = false;

        public override BaseWearableSO Wearable()
        {
            var w = ScriptableObject.CreateInstance<SandyDamage>();
            w.BaseWearable(this);
            w.effects = ExtensionMethods.ToEffectInfoArray(effects);

            return w;
        }
    }
}
