namespace Dui_Mauris_Furyball
{
    public class DeadCream
    {
        public static void Add()
        {
            var repeatEffect = ScriptableObject.CreateInstance<UnboundedShieldEffect>();
            repeatEffect._repeatChance = 85;

            var randomShield = new Ability();
            randomShield.name = "Dubious Rub";
            randomShield.description = "Apply at least 1 shield to this positon.";
            randomShield.cost = new ManaColorSO[] { Pigments.Blue, Pigments.Blue, Pigments.Blue };
            randomShield.sprite = ResourceLoader.LoadSprite("creamofdying");
            randomShield.effects = new Effect[]
                {
                    new(repeatEffect, 1, IntentType.Field_Shield, Slots.Self)
                };

            ExtraAbility_Wearable_SMS unbounded = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            unbounded._extraAbility = randomShield.CharacterAbility();

            var deadCream = new EffectItem();
            deadCream.name = "Dead Cream";
            deadCream.flavorText = "\"The only cream that dies for your skin.\"";
            deadCream.description = "Adds \"Dubious Rub\" as an additional ability, an ability that applies a random amount of shield.";
            deadCream.sprite = ResourceLoader.LoadSprite("DeadCream", 1, null);
            deadCream.unlockableID = (UnlockableID)176978179;
            deadCream.namePopup = false;
            deadCream.itemPools = BrutalAPI.ItemPools.Shop;
            deadCream.shopPrice = 6;
            deadCream.equippedModifiers = new WearableStaticModifierSetterSO[]
            {
                unbounded
            };
            deadCream.AddItem();

            Connection_PerformEffectPassiveAbility connection_PerformEffectPassiveAbility = LoadedAssetsHandler.GetCharcater("Doll_CH").passiveAbilities[0] as Connection_PerformEffectPassiveAbility;
            CasterAddRandomExtraAbilityEffect casterAddRandomExtraAbilityEffect = connection_PerformEffectPassiveAbility.connectionEffects[1].effect as CasterAddRandomExtraAbilityEffect;
            casterAddRandomExtraAbilityEffect._extraData = new List<ExtraAbility_Wearable_SMS>(casterAddRandomExtraAbilityEffect._extraData)
            {
                unbounded
            }.ToArray();
        }
    }
}
