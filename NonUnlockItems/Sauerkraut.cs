namespace Dui_Mauris_Furyball
{
    public class Sauerkraut
    {
        public static void Add()
        {
            var blueGen = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            blueGen.mana = Pigments.Blue;

            var sour = new FresnelItem();
            sour.name = "Sauerkraut";
            sour.flavorText = "\"Extra blue pigment. Tastes just how it sounds.\"";
            sour.description = "Upon lucky pigment triggering, produce an additional blue pigment.";
            sour.sprite = ResourceLoader.LoadSprite("Sauerkraut", 1, null);
            sour.unlockableID = (UnlockableID)9002826;
            sour.namePopup = true;
            sour.itemPools = BrutalAPI.ItemPools.Shop;
            sour.shopPrice = 1;
            sour.startsLocked = false;
            sour.effects = new Effect[]
            {
                new(blueGen, 1, null, Slots.Self),
            };
            sour.AddItem();
        }
    }
}
