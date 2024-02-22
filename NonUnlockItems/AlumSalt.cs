namespace Dui_Mauris_Furyball
{
    public class AlumSalt
    {
        public static void Add()
        {
            var purpleGen = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            purpleGen.mana = Pigments.Purple;

            var alumSalt = new FresnelItem();
            alumSalt.name = "Alum Salt";
            alumSalt.flavorText = "\"Extra purple pigment. Dries your mouth out.\"";
            alumSalt.description = "Upon lucky pigment triggering, produce an additional purple pigment.";
            alumSalt.sprite = ResourceLoader.LoadSprite("AlumSalt", 1, null);
            alumSalt.unlockableID = (UnlockableID)9002828;
            alumSalt.namePopup = true;
            alumSalt.itemPools = BrutalAPI.ItemPools.Shop;
            alumSalt.shopPrice = 3;
            alumSalt.startsLocked = false;
            alumSalt.effects = new Effect[]
            {
                new(purpleGen, 1, null, Slots.Self),
            };
            alumSalt.AddItem();
        }
    }
}
