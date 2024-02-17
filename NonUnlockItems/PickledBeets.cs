namespace Dui_Mauris_Furyball
{
    public class PickledBeets
    {
        public static void Add()
        {
            var redGen = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            redGen.mana = Pigments.Red;

            var pickledBeets = new FresnelItem();
            pickledBeets.name = "Pickled Beets";
            pickledBeets.flavorText = "\"Extra red pigment. Stains redder than red.\"";
            pickledBeets.description = "Upon lucky pigment triggering, produce an additional red pigment.";
            pickledBeets.sprite = ResourceLoader.LoadSprite("PickledBeets", 1, null);
            pickledBeets.unlockableID = (UnlockableID)9002825;
            pickledBeets.namePopup = false;
            pickledBeets.itemPools = BrutalAPI.ItemPools.Shop;
            pickledBeets.shopPrice = 4;
            pickledBeets.effects = new Effect[]
            {
                new(redGen, 1, null, Slots.Self),
            };
        }
    }
}
