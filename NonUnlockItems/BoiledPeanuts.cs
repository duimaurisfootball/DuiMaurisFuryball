namespace Dui_Mauris_Furyball
{
    public class BoiledPeanuts
    {
        public static void Add()
        {
            var cookMore = ScriptableObject.CreateInstance<ExtraLootOptionsEffect>();
            cookMore._changeOption = true;
            cookMore._itemName = "BoiledPeanuts_SW";

            var boiledPeanuts = new EffectItem();
            boiledPeanuts.name = "Boiled Peanuts";
            boiledPeanuts.flavorText = "\"It's impossible to have just a few.\"";
            boiledPeanuts.description = "Heal this party member 8 health on combat end, ignoring anything that might prevent it. Consume this item on use.";
            boiledPeanuts.sprite = ResourceLoader.LoadSprite("BoiledPeanuts", 1, null);
            boiledPeanuts.unlockableID = (UnlockableID)900220293;
            boiledPeanuts.namePopup = true;
            boiledPeanuts.itemPools = BrutalAPI.ItemPools.Shop;
            boiledPeanuts.shopPrice = 3;
            boiledPeanuts.startsLocked = false;
            boiledPeanuts.trigger = TriggerCalls.OnCombatEnd;
            boiledPeanuts.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<PenetratingHealEffect>(), 8, null, Slots.Self),
                new(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, null, Slots.Self),
                new(cookMore, 1, null, Slots.Self),
                new(cookMore, 1, null, Slots.Self, Conditions.Chance(50)),
                new(cookMore, 2, null, Slots.Self, Conditions.Chance(50)),
                new(cookMore, 4, null, Slots.Self, Conditions.Chance(50)),
                new(cookMore, 8, null, Slots.Self, Conditions.Chance(50)),
            };
            boiledPeanuts.AddItem();
        }
    }
}
