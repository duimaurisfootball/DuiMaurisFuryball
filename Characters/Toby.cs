namespace Dui_Mauris_Furyball
{
    public class Toby
    {
        public static void Add()
        {
            //Toby Basics
            Character toby = new Character();
            toby.name = "Toby";
            toby.healthColor = Pigments.Blue;
            toby.entityID = (EntityIDs)66126698;
            toby.frontSprite = ResourceLoader.LoadSprite("TobyFront");
            toby.backSprite = ResourceLoader.LoadSprite("TobyBack");
            toby.overworldSprite = ResourceLoader.LoadSprite("TobyOverworld", 32, new Vector2(0.5f, 0.02f));
            toby.lockedSprite = ResourceLoader.LoadSprite("TobyMenu");
            toby.unlockedSprite = ResourceLoader.LoadSprite("TobyMenu");
            toby.menuChar = true;
            toby.appearsInShops = true;
            toby.hurtSound = LoadedAssetsHandler.GetCharcater("Anton_CH").damageSound;
            toby.deathSound = LoadedAssetsHandler.GetCharcater("Anton_CH").deathSound;
            toby.dialogueSound = LoadedAssetsHandler.GetCharcater("Anton_CH").dxSound;
            toby.isSupport = true;
            toby.passives = new BasePassiveAbilitySO[]
            {

            };

            var allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;

            var allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllies = true;
            allAlly.getAllUnitSlots = false;

            var healDamage = ScriptableObject.CreateInstance<DamageEffect>();
            healDamage._usePreviousExitValue = true;

            var healPercent = ScriptableObject.CreateInstance<HealEffect>();
            healPercent.entryAsPercentage = true;

            var healVia = ScriptableObject.CreateInstance<HealEffect>();
            healVia.usePreviousExitValue = true;

            var maxHealthDown = ScriptableObject.CreateInstance<ChangeMaxHealthEffect>();
            maxHealthDown._increase = false;

            var healAnim0 = ScriptableObject.CreateInstance<AnimationVisualsCarryPreviousExitValueEffect>();
            healAnim0._visuals = LoadedAssetsHandler.GetEnemyAbility("DrippingsOfTheGarden_A").visuals;
            healAnim0._animationTarget = Slots.Front;

            var healAnim1 = ScriptableObject.CreateInstance<AnimationVisualsCarryPreviousExitValueEffect>();
            healAnim1._visuals = LoadedAssetsHandler.GetCharacterAbility("Fumes_1_A").visuals;
            healAnim0._animationTarget = Slots.Front;

            var healFail = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            healFail.wasSuccessful = false;

            //Collection
            var collection0 = new Ability();
            collection0.name = "Dripping Collection";
            collection0.description = "Heal all allies 3 health. Deal an equivalent amount of damage to the opposing enemy. Decrease all allies max health by 1.";
            collection0.cost = new ManaColorSO[] { Pigments.Red, Pigments.Purple, Pigments.Blue };
            collection0.sprite = ResourceLoader.LoadSprite("collection");
            collection0.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<HealEffect>(), 3, IntentType.Heal_1_4, allAlly),
                new(healAnim0, 1, null, Slots.Front),
                new(healDamage, 1, IntentType.Damage_3_6, Slots.Front),
                new(maxHealthDown, 1, IntentType.Other_MaxHealth_Alt, allAlly),
            };

            var collection1 = collection0.Duplicate();
            collection1.name = "Spilling Collection";
            collection1.description = "Heal all allies 4 health. Deal an equivalent amount of damage to the opposing enemy. Decrease all allies max health by 1.";
            collection1.effects[0]._entryVariable = 4;

            var collection2 = collection1.Duplicate();
            collection2.name = "Bubbling Collection";
            collection2.description = "Heal all allies 5 health. Deal an equivalent amount of damage to the opposing enemy. Decrease all allies max health by 1.";
            collection2.effects[0]._entryVariable = 5;
            collection2.effects[0]._intent = IntentType.Heal_5_10;

            var collection3 = collection2.Duplicate();
            collection3.name = "Flooding Collection";
            collection3.description = "Heal all allies 5 health. Deal an equivalent amount of damage to the opposing enemy. Decrease all allies max health by 1.";
            collection3.cost = new ManaColorSO[] { Pigments.Red, Pigments.SplitPigment( Pigments.Blue, Pigments.Purple ), Pigments.Blue };
            collection3.effects[0]._entryVariable = 5;


            //Blood
            var blood0 = new Ability();
            blood0.name = "Blood Mover";
            blood0.description = "Heal the Left ally 40% of their health. If no health is restored, heal this party member instead. Deal an equivalent amount of damage to the Opposing enemy.";
            blood0.cost = new ManaColorSO[] { Pigments.Blue, Pigments.Blue, Pigments.Blue };
            blood0.sprite = ResourceLoader.LoadSprite("blood");
            blood0.effects = new Effect[]
            {
                new(healPercent, 40, IntentType.Heal_5_10, Slots.SlotTarget(new int[] { -1 }, true)),
                new(healPercent, 40, IntentType.Heal_5_10, Slots.SlotTarget(new int[] { 0 }, true), healFail),
                new(healAnim1, 1, null, Slots.Front),
                new(healDamage, 1, IntentType.Damage_3_6, Slots.Front),
            };

            var blood1 = blood0.Duplicate();
            blood1.name = "Blood Talker";
            blood1.description = "Heal the Left ally 50% of their health. If no health is restored, heal this party member instead. Deal an equivalent amount of damage to the Opposing enemy.";
            blood1.effects[0]._entryVariable = 50;
            blood1.effects[1]._entryVariable = 50;

            var blood2 = blood1.Duplicate();
            blood2.name = "Blood Conductor";
            blood2.description = "Heal the Left ally 60% of their health. If no health is restored, heal this party member instead. Deal an equivalent amount of damage to the Opposing enemy.";
            blood2.effects[0]._entryVariable = 60;
            blood2.effects[1]._entryVariable = 60;

            var blood3 = blood2.Duplicate();
            blood3.name = "Blood Creator";
            blood3.description = "Heal the Left ally 60% of their health. If no health is restored, heal this party member instead. Deal an equivalent amount of damage to the Opposing enemy.";
            blood3.cost = new ManaColorSO[] { Pigments.Blue, Pigments.Blue };

            //Popping
            var popping0 = new Ability();
            popping0.name = "Popping Boils";
            popping0.description = "Deal 2 damage to all enemies. Heal the Left ally by an equivalent amount.";
            popping0.cost = new ManaColorSO[] { Pigments.Blue, Pigments.Blue };
            popping0.sprite = ResourceLoader.LoadSprite("popping");
            popping0.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<DamageEffect>(), 2, IntentType.Damage_1_2, allEnemy),
                new(healVia, 1, IntentType.Heal_1_4, Slots.SlotTarget(new int[] { -1 }, true)),
            };
            popping0.animationTarget = allEnemy;
            popping0.visuals = LoadedAssetsHandler.GetCharacterAbility("Wrath_1_A").visuals;

            var popping1 = popping0.Duplicate();
            popping1.name = "Popping Tendons";
            popping1.description = "Deal 4 damage to all enemies. Heal the Left ally by an equivalent amount.";
            popping1.effects[0]._entryVariable = 4;
            popping1.effects[0]._intent = IntentType.Damage_3_6;

            var popping2 = popping1.Duplicate();
            popping2.name = "Popping Skulls";
            popping2.description = "Deal 5 damage to all enemies. Heal the Left and Right allies by an equivalent amount.";
            popping2.effects[0]._entryVariable = 5;
            popping2.effects[1]._target = Slots.SlotTarget(new int[] { -1, 1 }, true);

            var popping3 = popping2.Duplicate();
            popping3.name = "Popping Hearts";
            popping3.description = "Deal 6 damage to all enemies. Heal the Left and Right allies by an equivalent amount.";
            popping3.effects[0]._entryVariable = 6;
            popping3.effects[1]._intent = IntentType.Heal_5_10;

            //
            //
            //

            var objectProjection = new Ability();
            objectProjection.name = "Object Projection";
            objectProjection.description = "Fully heal this party member. Deal an equivalent amount of damage to the opposing enemy.";
            objectProjection.cost = new ManaColorSO[] { Pigments.Purple, Pigments.Purple, Pigments.Purple };
            objectProjection.sprite = ResourceLoader.LoadSprite("projectObjection");
            objectProjection.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<FullHealEffect>(), 1, IntentType.Heal_21, Slots.Self),
                new(healDamage, 1, IntentType.Damage_1_2, Slots.Front),
            };
            objectProjection.animationTarget = Slots.Self;
            objectProjection.visuals = LoadedAssetsHandler.GetEnemyAbility("DrippingsOfTheGarden_A").visuals;

            ExtraAbility_Wearable_SMS iGiveUpAll = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            iGiveUpAll._extraAbility = objectProjection.CharacterAbility();

            var gabrielsBlindness = new EffectItem();
            gabrielsBlindness.name = "Gabriel's Blindness";
            gabrielsBlindness.flavorText = "\"Keep it in.\"";
            gabrielsBlindness.description = "Adds \"Object Projection\" as an additional ability, an extremely powerful self heal that demands blood.";
            gabrielsBlindness.sprite = ResourceLoader.LoadSprite("GabrielsBlindness", 1, null);
            gabrielsBlindness.trigger = TriggerCalls.OnCombatStart;
            gabrielsBlindness.unlockableID = (UnlockableID)5095084;
            gabrielsBlindness.namePopup = false;
            gabrielsBlindness.itemPools = BrutalAPI.ItemPools.Treasure;
            gabrielsBlindness.equippedModifiers = new WearableStaticModifierSetterSO[]
            {
                iGiveUpAll
            };

            //
            //
            //


            var frenchKiss = new Ability();
            frenchKiss.name = "French Kiss";
            frenchKiss.description = "Deal 4 damage to the Opposing enemy. Increase this party member's max health by an equivalent amount. Increase this party member's health by 7 if successful.";
            frenchKiss.cost = new ManaColorSO[] { Pigments.Red };
            frenchKiss.sprite = ResourceLoader.LoadSprite("FrenchKiss");
            frenchKiss.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<DamageEffect>(), 4, IntentType.Damage_3_6, Slots.Front),
                new(ScriptableObject.CreateInstance<ChangeMaxHealthByPreviousExitValueEffect>(), 1, IntentType.Other_MaxHealth, Slots.Self),
                new(ScriptableObject.CreateInstance<HealIgnoreMaxHealthEffect>(), 7, IntentType.Heal_5_10, Slots.Self, ScriptableObject.CreateInstance<PreviousEffectCondition>()),
            };
            frenchKiss.animationTarget = Slots.Front;
            frenchKiss.visuals = LoadedAssetsHandler.GetEnemyAbility("TraumaBond_A").visuals;

            ExtraAbility_Wearable_SMS ahhhTheFrench = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            ahhhTheFrench._extraAbility = frenchKiss.CharacterAbility();

            var loversTongue = new EffectItem();
            loversTongue.name = "Lover's Tongue";
            loversTongue.flavorText = "\"Round and round we go!\"";
            loversTongue.description = "Adds \"French Kiss\" as an additional ability, a health increasing attack.";
            loversTongue.sprite = ResourceLoader.LoadSprite("LoversTongue", 1, null);
            loversTongue.trigger = TriggerCalls.OnCombatStart;
            loversTongue.unlockableID = (UnlockableID)5095085;
            loversTongue.namePopup = false;
            loversTongue.itemPools = BrutalAPI.ItemPools.Treasure;
            loversTongue.equippedModifiers = new WearableStaticModifierSetterSO[]
            {
                ahhhTheFrench
            };

            FoolItemPairs TobyPair = new FoolItemPairs(toby, gabrielsBlindness, loversTongue);
            TobyPair.Add();

            toby.AddLevel(8, new Ability[3] { collection0, blood0, popping0 }, 0);
            toby.AddLevel(10, new Ability[3] { collection1, blood1, popping1 }, 1);
            toby.AddLevel(11, new Ability[3] { collection2, blood2, popping2 }, 2);
            toby.AddLevel(12, new Ability[3] { collection3, blood3, popping3 }, 3);
            toby.AddCharacter();

            Connection_PerformEffectPassiveAbility connection_PerformEffectPassiveAbility = LoadedAssetsHandler.GetCharcater("Doll_CH").passiveAbilities[0] as Connection_PerformEffectPassiveAbility;
            CasterAddRandomExtraAbilityEffect casterAddRandomExtraAbilityEffect = connection_PerformEffectPassiveAbility.connectionEffects[1].effect as CasterAddRandomExtraAbilityEffect;
            casterAddRandomExtraAbilityEffect._extraData = new List<ExtraAbility_Wearable_SMS>(casterAddRandomExtraAbilityEffect._extraData)
            {
                iGiveUpAll,
                ahhhTheFrench
            }.ToArray();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Toby");
        }
    }
}
