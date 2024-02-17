namespace Dui_Mauris_Furyball
{
    public class AppleCiderVinegar
    {
        public static void Add()
        {
            var yellowGen = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            yellowGen.mana = Pigments.Yellow;

            var pickledBeets = new FresnelItem();
            pickledBeets.name = "Apple Cider Vinegar";
            pickledBeets.flavorText = "\"Extra yellow pigment. With the mother!\"";
            pickledBeets.description = "Upon lucky pigment triggering, produce an additional yellow pigment.";
            pickledBeets.sprite = ResourceLoader.LoadSprite("AppleCiderVinegar", 1, null);
            pickledBeets.unlockableID = (UnlockableID)9002827;
            pickledBeets.namePopup = false;
            pickledBeets.itemPools = BrutalAPI.ItemPools.Shop;
            pickledBeets.shopPrice = 3;
            pickledBeets.effects = new Effect[]
            {
                new(yellowGen, 1, null, Slots.Self),
            };
        }
    }
}
