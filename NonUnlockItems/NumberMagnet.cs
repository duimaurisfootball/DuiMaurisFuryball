namespace Dui_Mauris_Furyball
{
    public class NumberMagnet
    {
        public static void Add()
        {
            var soulSlap = ScriptableObject.CreateInstance<AbilitiesUsageChange_Wearable_SMS>();
            soulSlap._usesAllAbilities = true;
            soulSlap._usesBasicAbility = false;


            var NumberMagnet = new EntryVariableItem();
            NumberMagnet.name = "Number Magnet";
            NumberMagnet.flavorText = "\"Three.\"";
            NumberMagnet.description = "\"Slap\" is replaced with this party member's missing ability. Every entry variable for this party member's abilities is set to 3.";
            NumberMagnet.sprite = ResourceLoader.LoadSprite("NumberMagnet", 1, null);
            NumberMagnet.trigger = TriggerCalls.OnCombatStart;
            NumberMagnet.unlockableID = (UnlockableID)333333333;
            NumberMagnet.namePopup = false;
            NumberMagnet.itemPools = ItemPools.Shop | ItemPools.Treasure;
            NumberMagnet.shopPrice = 3;
            NumberMagnet.startsLocked = false;
            NumberMagnet.equippedModifiers = new WearableStaticModifierSetterSO[]
                {
                    soulSlap
                };
            NumberMagnet.AddItem();
        }
    }
}

