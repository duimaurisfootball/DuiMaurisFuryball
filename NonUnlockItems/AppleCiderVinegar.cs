namespace Dui_Mauris_Furyball
{
    public class AppleCiderVinegar
    {
        public static void Add()
        {
            var yellowGen = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            yellowGen.mana = Pigments.Yellow;

            var vinegar = new FresnelItem();
            vinegar.name = "Apple Cider Vinegar";
            vinegar.flavorText = "\"Extra yellow pigment. With the mother!\"";
            vinegar.description = "Upon lucky pigment triggering, produce an additional yellow pigment.";
            vinegar.sprite = ResourceLoader.LoadSprite("AppleCiderVinegar", 1, null);
            vinegar.unlockableID = (UnlockableID)9002827;
            vinegar.namePopup = true;
            vinegar.itemPools = BrutalAPI.ItemPools.Shop;
            vinegar.shopPrice = 3;
            vinegar.startsLocked = false;
            vinegar.effects = new Effect[]
            {
                new(yellowGen, 1, null, Slots.Self),
            };
            vinegar.AddItem();
        }
    }
}
