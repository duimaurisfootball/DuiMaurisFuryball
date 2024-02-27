namespace Dui_Mauris_Furyball
{
    public class Beeper
    {
        public static void Add()
        {
            var beeper = new EffectItem();
            beeper.name = "Beeper";
            beeper.flavorText = "\".......Beep!.......\"";
            beeper.description = "Place 4 unbreakable shield on this position and the opposing position on combat start.";
            beeper.sprite = ResourceLoader.LoadSprite("Beeper", 1, null);
            beeper.unlockableID = (UnlockableID)5891799;
            beeper.namePopup = true;
            beeper.itemPools = BrutalAPI.ItemPools.Shop;
            beeper.shopPrice = 7;
            beeper.trigger = TriggerCalls.OnCombatStart;
            beeper.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<ApplyPermanentShieldEffect>(), 4, null, Slots.Self),
                new(ScriptableObject.CreateInstance<ApplyPermanentShieldEffect>(), 4, null, Slots.Front),
            };
            beeper.AddItem();
        }
    }
}
