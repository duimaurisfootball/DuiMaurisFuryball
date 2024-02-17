namespace Dui_Mauris_Furyball
{
    public class AlumSalt
    {
        public static void Add()
        {
            var purpleGen = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            purpleGen.mana = Pigments.Purple;

            var pickledBeets = new FresnelItem();
            pickledBeets.name = "Alum Salt";
            pickledBeets.flavorText = "\"Extra purple pigment. Dries your mouth out.\"";
            pickledBeets.description = "Upon lucky pigment triggering, produce an additional purple pigment.";
            pickledBeets.sprite = ResourceLoader.LoadSprite("AlumSalt", 1, null);
            pickledBeets.unlockableID = (UnlockableID)9002828;
            pickledBeets.namePopup = false;
            pickledBeets.itemPools = BrutalAPI.ItemPools.Shop;
            pickledBeets.shopPrice = 3;
            pickledBeets.effects = new Effect[]
            {
                new(purpleGen, 1, null, Slots.Self),
            };
        }
    }
}
