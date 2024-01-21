namespace Dui_Mauris_Furyball
{
    public class BowlingPinSplit
    {
        public static void Add()
        {
            var combineYellow = ScriptableObject.CreateInstance<CostRerollFromToEffect>();
            combineYellow._originalCosts = new()
            {
                PigmentType.Yellow
            };
            combineYellow._newCosts = new()
            {
                Pigments.SplitPigment( Pigments.Red, Pigments.Blue ),
                Pigments.SplitPigment( Pigments.Red, Pigments.Purple ),
                Pigments.SplitPigment( Pigments.Purple, Pigments.Blue ),
            };
            var combineRed = ScriptableObject.CreateInstance<CostRerollFromToEffect>();
            combineRed._originalCosts = new()
            {
                PigmentType.Red
            };
            combineRed._newCosts = new()
            {
                Pigments.SplitPigment( Pigments.Purple, Pigments.Blue ),
                Pigments.SplitPigment( Pigments.Yellow, Pigments.Blue ),
                Pigments.SplitPigment( Pigments.Yellow, Pigments.Purple ),
            };
            var combineBlue = ScriptableObject.CreateInstance<CostRerollFromToEffect>();
            combineBlue._originalCosts = new()
            {
                PigmentType.Blue
            };
            combineBlue._newCosts = new()
            {
                Pigments.SplitPigment( Pigments.Red, Pigments.Purple ),
                Pigments.SplitPigment( Pigments.Red, Pigments.Yellow ),
                Pigments.SplitPigment( Pigments.Yellow, Pigments.Purple ),
            };
            var combinePurple = ScriptableObject.CreateInstance<CostRerollFromToEffect>();
            combinePurple._originalCosts = new()
            {
                PigmentType.Purple
            };
            combinePurple._newCosts = new()
            {
                Pigments.SplitPigment( Pigments.Red, Pigments.Blue ),
                Pigments.SplitPigment( Pigments.Yellow, Pigments.Blue ),
                Pigments.SplitPigment( Pigments.Yellow, Pigments.Red ),
            };


            EffectItem bowlingSplit = new EffectItem();
            bowlingSplit.name = "Split Pins";
            bowlingSplit.flavorText = "\"Damn, couldn't convert a spare.\"";
            bowlingSplit.description = "Reroll this party member's single pigment costs into a split pigment cost not containing the original cost.";
            bowlingSplit.sprite = ResourceLoader.LoadSprite("BowlingPinSplit", 1, null);
            bowlingSplit.trigger = TriggerCalls.OnCombatStart;
            bowlingSplit.unlockableID = (UnlockableID)999085;
            bowlingSplit.namePopup = false;
            bowlingSplit.itemPools = BrutalAPI.ItemPools.Shop;
            bowlingSplit.shopPrice = 5;
            bowlingSplit.startsLocked = false;
            bowlingSplit.effects = new Effect[]
                {
                    new(combineYellow, 1, null, Slots.Self),
                    new(combineRed, 1, null, Slots.Self),
                    new(combineBlue, 1, null, Slots.Self),
                    new(combinePurple, 1, null, Slots.Self),
                };
            bowlingSplit.AddItem();
        }
    }
}
