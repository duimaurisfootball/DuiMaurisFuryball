namespace Dui_Mauris_Furyball.NonUnlockItems
{
    public class SpearItem
    {
        public static void Add()
        {
            IDetour Spears = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(SpearStoredValue).GetMethod("AddStoredValueName", ~BindingFlags.Default));

            var spearCount = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            spearCount._increase = false;
            spearCount._minimumValue = 0;
            spearCount._valueName = (UnitStoredValueNames)567235;

            var spearCheck = ScriptableObject.CreateInstance<CasterStoreValueCheckEffect>();
            spearCheck._valueName = (UnitStoredValueNames)567235;

            var spearSet = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            spearSet._increase = true;
            spearSet._valueName = (UnitStoredValueNames)567235;

            var spearKleck = ScriptableObject.CreateInstance<CheckStoredValueNumberToBoolEffect>();
            spearKleck._valueName = (UnitStoredValueNames)567235;

            var carryOver = ScriptableObject.CreateInstance<PreviousEffectCondition>();

            var liveSpears = ScriptableObject.CreateInstance<CasterAddOrRemoveExtraAbilityEffect>();

            var killSpears = ScriptableObject.CreateInstance<CasterAddOrRemoveExtraAbilityEffect>();
            killSpears._removeExtraAbility = true;

            Ability spear0 = new Ability();
            spear0.name = "Spear";
            spear0.description = "Deal 6 damage to the Opposing enemy. Refresh this party member. Uses one spear.";
            spear0.cost = new ManaColorSO[] { };
            spear0.sprite = ResourceLoader.LoadSprite("spearAbility");
            spear0.effects = new Effect[]
                {
                    new(spearCheck, 0, null, Slots.Self),
                    new(ScriptableObject.CreateInstance<DamageEffect>(), 6, IntentType.Damage_3_6, Slots.Front, carryOver),
                    new(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, IntentType.Other_Refresh, Slots.Self),
                    new(spearCount, 1, IntentType.Misc_State_Sit, Slots.Self),
                    new(spearKleck, 0, null, Slots.Self),
                    new(killSpears, 0, null, Slots.Self, carryOver),
                };

            ExtraAbility_Wearable_SMS theyAreSpears = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            theyAreSpears._extraAbility = spear0.CharacterAbility();

            liveSpears._extraAbility = theyAreSpears;

            killSpears._extraAbility = theyAreSpears;

            EffectItem spear = new EffectItem();
            spear.name = "Spear";
            spear.flavorText = "\"A hostile take on slick tricks.\"";
            spear.description = "Adds ''Spear'' as an additional ability, a highly versatile attack with four uses per combat.";
            spear.sprite = ResourceLoader.LoadSprite("Spear", 1, null);
            spear.trigger = TriggerCalls.OnCombatStart;
            spear.unlockableID = (UnlockableID)999084;
            spear.namePopup = false;
            spear.itemPools = BrutalAPI.ItemPools.Shop;
            spear.shopPrice = 7;
            spear.startsLocked = false;
            spear.effects = new Effect[]
            {
                new(spearSet, 4, null, Slots.Self),
                new(liveSpears, 1, null, Slots.Self),
            };
            theyAreSpears._extraAbility.ability.specialStoredValue = (UnitStoredValueNames)567235;
            spear.AddItem();
        }
    }
}
