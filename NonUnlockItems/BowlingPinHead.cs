namespace Dui_Mauris_Furyball
{
    public class BowlingPinHead
    {
        public static void Add()
        {
            var unfoldAll = ScriptableObject.CreateInstance<CostRerollSizeMultiplierEffect>();
            unfoldAll._newCosts = new()
            {
                Pigments.Gray
            };
            unfoldAll._multiplier = 2;

            EffectItem bowlingTap = new EffectItem();
            bowlingTap.name = "Head Pin";
            bowlingTap.flavorText = "\"Aim a little to the left.\"";
            bowlingTap.description = "This party member's abilities now only cost gray, but cost twice as much.";
            bowlingTap.sprite = ResourceLoader.LoadSprite("BowlingPinHead", 1, null);
            bowlingTap.trigger = TriggerCalls.OnCombatStart;
            bowlingTap.unlockableID = (UnlockableID)999087;
            bowlingTap.namePopup = false;
            bowlingTap.itemPools = BrutalAPI.ItemPools.Shop;
            bowlingTap.shopPrice = 5;
            bowlingTap.startsLocked = false;
            bowlingTap.effects = new Effect[]
                {
                    new(unfoldAll, 1, null, Slots.Self),
                };
            bowlingTap.AddItem();
        }
    }
}
