namespace Dui_Mauris_Furyball
{
    public class BowlingPinGreek
    {
        public static void Add()
        {
            EffectItem bowlingTap = new EffectItem();
            bowlingTap.name = "Greek Pins";
            bowlingTap.flavorText = "\"Statistically the worst split!\"";
            bowlingTap.description = "Reroll this party member's split pigment costs into the opposite split pigment.";
            bowlingTap.sprite = ResourceLoader.LoadSprite("BowlingPinGreek", 1, null);
            bowlingTap.trigger = TriggerCalls.OnCombatStart;
            bowlingTap.unlockableID = (UnlockableID)999086;
            bowlingTap.namePopup = false;
            bowlingTap.itemPools = BrutalAPI.ItemPools.Shop;
            bowlingTap.shopPrice = 3;
            bowlingTap.startsLocked = false;
            bowlingTap.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<GreekReroll>(), 1, null, Slots.Self),
                };
            bowlingTap.AddItem();
        }
    }
}
