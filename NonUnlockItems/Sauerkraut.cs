namespace Dui_Mauris_Furyball
{
    public class Sauerkraut
    {
        public static void Add()
        {
            var blueGen = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            blueGen.mana = Pigments.Blue;

            var pickledBeets = new FresnelItem();
            pickledBeets.name = "Sauerkraut";
            pickledBeets.flavorText = "\"Extra blue pigment. Tastes just how it sounds.\"";
            pickledBeets.description = "Upon lucky pigment triggering, produce an additional blue pigment.";
            pickledBeets.sprite = ResourceLoader.LoadSprite("Sauerkraut", 1, null);
            pickledBeets.unlockableID = (UnlockableID)9002826;
            pickledBeets.namePopup = false;
            pickledBeets.itemPools = BrutalAPI.ItemPools.Shop;
            pickledBeets.shopPrice = 1;
            pickledBeets.effects = new Effect[]
            {
                new(blueGen, 1, null, Slots.Self),
            };
        }
    }
}
