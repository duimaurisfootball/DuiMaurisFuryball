using Dui_Mauris_Furyball.CustomEffects;
using Dui_Mauris_Furyball.ExtraStoredValues;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dui_Mauris_Furyball.NonUnlockItems
{
    public class BowlingPinTap
    {
        public static void Add()
        {

            var desplitYR = ScriptableObject.CreateInstance<CostRerollFromToEffect>();
            desplitYR._originalCosts = new()
            {
                PigmentType.Yellow | PigmentType.Red,
            };
            desplitYR._newCosts = new()
            {
                Pigments.Blue,
                Pigments.Purple,
            };
            var desplitYB = ScriptableObject.CreateInstance<CostRerollFromToEffect>();
            desplitYB._originalCosts = new()
            {
                PigmentType.Yellow | PigmentType.Blue,
            };
            desplitYB._newCosts = new()
            {
                Pigments.Red,
                Pigments.Purple,
            };
            var desplitYP = ScriptableObject.CreateInstance<CostRerollFromToEffect>();
            desplitYP._originalCosts = new()
            {
                PigmentType.Yellow | PigmentType.Purple,
            };
            desplitYP._newCosts = new()
            {
                Pigments.Red,
                Pigments.Blue,
            };
            var desplitBR = ScriptableObject.CreateInstance<CostRerollFromToEffect>();
            desplitBR._originalCosts = new()
            {
                PigmentType.Blue | PigmentType.Red,
            };
            desplitBR._newCosts = new()
            {
                Pigments.Purple,
                Pigments.Yellow,
            };
            var desplitBP = ScriptableObject.CreateInstance<CostRerollFromToEffect>();
            desplitBP._originalCosts = new()
            {
                PigmentType.Blue | PigmentType.Purple,
            };
            desplitBP._newCosts = new()
            {
                Pigments.Yellow,
                Pigments.Red,
            };
            var desplitRP = ScriptableObject.CreateInstance<CostRerollFromToEffect>();
            desplitRP._originalCosts = new()
            {
                PigmentType.Purple | PigmentType.Red,
            };
            desplitRP._newCosts = new()
            {
                Pigments.Yellow,
                Pigments.Blue,
            };



            EffectItem bowlingTap = new EffectItem();
            bowlingTap.name = "Tapped Pins";
            bowlingTap.flavorText = "\"No more splits... thank god!\"";
            bowlingTap.description = "Reroll this party member's split pigment costs into a single pigment cost not of the original split pigment.";
            bowlingTap.sprite = ResourceLoader.LoadSprite("BowlingPinTap", 1, null);
            bowlingTap.trigger = TriggerCalls.OnCombatStart;
            bowlingTap.unlockableID = (UnlockableID)999084;
            bowlingTap.namePopup = false;
            bowlingTap.itemPools = BrutalAPI.ItemPools.Shop;
            bowlingTap.shopPrice = 1;
            bowlingTap.startsLocked = false;
            bowlingTap.effects = new Effect[]
                {
                    new(desplitYR, 1, null, Slots.Self),
                    new(desplitYB, 1, null, Slots.Self),
                    new(desplitYP, 1, null, Slots.Self),
                    new(desplitBR, 1, null, Slots.Self),
                    new(desplitBP, 1, null, Slots.Self),
                    new(desplitRP, 1, null, Slots.Self),
                };
            bowlingTap.AddItem();
        }
    }
}
