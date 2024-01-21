namespace Dui_Mauris_Furyball
{
    public class BowlingPinBaby
    {
        public static void Add()
        {
            var unfoldAll = ScriptableObject.CreateInstance<CostRerollSetSizeEffect>();
            unfoldAll._newCosts = new()
            {
                Pigments.Purple
            };
            unfoldAll._size = 1;

            var removeDelicate = ScriptableObject.CreateInstance<RemovePassiveEffect>();
            removeDelicate._passiveToRemove = PassiveAbilityTypes.Delicate;

            EffectItem bowlingBaby = new EffectItem();
            bowlingBaby.name = "Baby Pins";
            bowlingBaby.flavorText = "\"Harder conversions have been done before.\"";
            bowlingBaby.description = "This party member's costs are now 1 purple. Remove delicate from this party member.";
            bowlingBaby.sprite = ResourceLoader.LoadSprite("BowlingPinBaby", 1, null);
            bowlingBaby.trigger = TriggerCalls.OnCombatStart;
            bowlingBaby.unlockableID = (UnlockableID)999088;
            bowlingBaby.namePopup = false;
            bowlingBaby.itemPools = BrutalAPI.ItemPools.Shop;
            bowlingBaby.shopPrice = 6;
            bowlingBaby.startsLocked = false;
            bowlingBaby.effects = new Effect[]
                {
                    new(unfoldAll, 1, null, Slots.Self),
                    new(removeDelicate, 1, null, Slots.Self),
                };
            bowlingBaby.AddItem();
        }
    }
}
