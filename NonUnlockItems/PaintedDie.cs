namespace Dui_Mauris_Furyball
{
    public class PaintedDie
    {
        public static void Add()
        {
            var randomizeMana = ScriptableObject.CreateInstance<RandomizeAllManaEffect>();
            randomizeMana.manaRandomOptions = new ManaColorSO[] { Pigments.Red, Pigments.Yellow, Pigments.Blue, Pigments.Purple };

            var paintedDie = new FresnelItem();
            paintedDie.name = "Painted Die";
            paintedDie.flavorText = "\"Loaded if you're colorblind.\"";
            paintedDie.description = "Upon lucky pigment triggering, randomize all stored pigment.";
            paintedDie.sprite = ResourceLoader.LoadSprite("PaintedDie", 1, null);
            paintedDie.unlockableID = (UnlockableID)9002855;
            paintedDie.namePopup = true;
            paintedDie.itemPools = BrutalAPI.ItemPools.Shop;
            paintedDie.shopPrice = 3;
            paintedDie.startsLocked = false;
            paintedDie.effects = new Effect[]
            {
                new(randomizeMana, 1, null, Slots.Self),
            };
            paintedDie.AddItem();
        }
    }
}
