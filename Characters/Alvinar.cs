namespace Dui_Mauris_Furyball
{
    public static class Alvinar
    {
        public static void Add()
        {
            //Custom Passive
            var Connoisseur = ScriptableObject.CreateInstance<SeasoningDamage>();
            Connoisseur._passiveName = "Connoisseur";
            Connoisseur.type = (PassiveAbilityTypes)091273;
            Connoisseur.passiveIcon = ResourceLoader.LoadSprite("connoiseur");
            Connoisseur._enemyDescription = "This enemy deals 30% extra damage for each status effect on targets.";
            Connoisseur._characterDescription = "This party member deals 30% extra damage for each status effect on targets.";
            Connoisseur._triggerOn = new TriggerCalls[0];
            
            //prepare
            Ability prepare = new Ability();
            prepare.name = "Prepare";
            prepare.description = "Deal 1 damage to the opposing enemy. Inflict 4 oil slicked to the opposing enemy.";
            prepare.cost = new ManaColorSO[] { Pigments.Yellow };
            prepare.sprite = ResourceLoader.LoadSprite("prepare");
            prepare.effects = new Effect[]
            {
              new(ScriptableObject.CreateInstance<DamageEffect>(), 1, IntentType.Damage_1_2, Slots.Front),
              new(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 4, IntentType.Status_OilSlicked, Slots.Front),
            };
            prepare.animationTarget = Slots.Front;
            prepare.visuals = LoadedAssetsHandler.GetCharacterAbility("Oil_1_A").visuals;

            //Alvinar Basics
            Character alvinar = new Character();
            
            alvinar.name = "Alvinar";
            alvinar.healthColor = Pigments.Purple;
            alvinar.entityID = (EntityIDs)991293;
            alvinar.frontSprite = ResourceLoader.LoadSprite("AlvinarFront");
            alvinar.backSprite = ResourceLoader.LoadSprite("AlvinarBack");
            alvinar.overworldSprite = ResourceLoader.LoadSprite("AlvinarOverworld", 32, new Vector2(0.5f, 0.02f));
            alvinar.lockedSprite = ResourceLoader.LoadSprite("AlvinarLocked");
            alvinar.unlockedSprite = ResourceLoader.LoadSprite("AlvinarMenu");
            alvinar.menuChar = true;
            alvinar.appearsInShops = true;
            alvinar.hurtSound = LoadedAssetsHandler.GetCharcater("Boyle_CH").damageSound;
            alvinar.deathSound = LoadedAssetsHandler.GetCharcater("Boyle_CH").deathSound;
            alvinar.dialogueSound = LoadedAssetsHandler.GetCharcater("Boyle_CH").dxSound;
            alvinar.isSupport = false;
            alvinar.baseAbility = prepare;
            alvinar.passives = new BasePassiveAbilitySO[]
            {
                Connoisseur,
            };

            //Just for you! special indirect damage :3
            SpecialDamageShieldBlockedEffect IndirectDamage = ScriptableObject.CreateInstance<SpecialDamageShieldBlockedEffect>();
            IndirectDamage._indirect = true;

            //Frenzy
            Ability frenzy0 = new Ability();
            frenzy0.name = "Chewing Frenzy";
            frenzy0.description = "Deal 1 indirect damage to the opposing enemy 3 times, then deal 1 direct damage. Inflict 1 scar to the opposing enemy. This ability is completely blocked by shield.";
            frenzy0.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.Purple };
            frenzy0.sprite = ResourceLoader.LoadSprite("frenzy");
            frenzy0.effects = new Effect[]
            {
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(ScriptableObject.CreateInstance<DamageShieldBlockedAndGibEffect>(), 1, IntentType.Damage_1_2, Slots.Front),
                new(ScriptableObject.CreateInstance<ApplyScarsEffectShieldBlocked>(), 1, IntentType.Status_Scars, Slots.Front),
            };
            frenzy0.animationTarget = Slots.Front;
            frenzy0.visuals = LoadedAssetsHandler.GetEnemyAbility("Gnaw_A").visuals;

            Ability frenzy1 = frenzy0.Duplicate();
            frenzy1.name = "Biting Frenzy";
            frenzy1.description = "Deal 1 indirect damage to the opposing enemy 3 times, then deal 3 direct damage. Inflict 1 scar to the opposing enemy. This ability is completely blocked by shield.";
            frenzy1.effects[3]._entryVariable = 3;
            frenzy1.effects[3]._intent = IntentType.Damage_3_6;

            Ability frenzy2 = frenzy1.Duplicate();
            frenzy2.name = "Wounding Frenzy";
            frenzy2.description = "Deal 1 indirect damage to the opposing enemy 3 times, then deal 5 direct damage. Inflict 1 scar to the opposing enemy. This ability is completely blocked by shield.";
            frenzy2.effects[3]._entryVariable = 5;

            Ability frenzy3 = frenzy2.Duplicate();
            frenzy3.name = "Masticating Frenzy";
            frenzy3.description = "Deal 1 indirect damage to the opposing enemy 3 times, then deal 6 direct damage. Inflict 1 scar to the opposing enemy. This ability is completely blocked by shield.";
            frenzy3.effects = new Effect[]
            {
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(ScriptableObject.CreateInstance<DamageShieldBlockedAndGibEffect>(), 5, IntentType.Damage_3_6, Slots.Front),
                new(ScriptableObject.CreateInstance<ApplyScarsEffectShieldBlocked>(), 1, IntentType.Status_Scars, Slots.Front),
            };

            //feast
            Ability feast0 = new Ability();
            feast0.name = "Nice Feast";
            feast0.description = "Deal 5 damage to the opposing enemy. Inflict 3 ruptured to the opposing enemy. This ability is completely blocked by shield.";
            feast0.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.Blue };
            feast0.sprite = ResourceLoader.LoadSprite("feast");
            feast0.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<DamageShieldBlockedAndGibEffect>(), 5, IntentType.Damage_3_6, Slots.Front),
                new(ScriptableObject.CreateInstance<ApplyRupturedEffectShieldBlocked>(), 3, IntentType.Status_Ruptured, Slots.Front),
            };
            feast0.animationTarget = Slots.Front;
            feast0.visuals = LoadedAssetsHandler.GetEnemyAbility("Devour_A").visuals;

            Ability feast1 = feast0.Duplicate();
            feast1.name = "Big Feast";
            feast1.description = "Deal 6 damage to the opposing enemy. Inflict 3 ruptured to the opposing enemy. This ability is completely blocked by shield.";
            feast1.effects[0]._entryVariable = 6;

            Ability feast2 = feast1.Duplicate();
            feast2.name = "Hearty Feast";
            feast2.description = "Deal 8 damage to the opposing enemy. Inflict 3 ruptured to the opposing enemy. This ability is completely blocked by shield.";
            feast2.effects[0]._entryVariable = 8;
            feast2.effects[0]._intent = IntentType.Damage_7_10;

            Ability feast3 = feast2.Duplicate();
            feast3.name = "Family Feast";
            feast3.description = "Deal 10 damage to the opposing enemy. Inflict 3 ruptured to the opposing enemy. This ability is completely blocked by shield.";
            feast3.effects[0]._entryVariable = 10;

            //tear
            Ability breaker0 = new Ability();
            breaker0.name = "Face Breaker";
            breaker0.description = "Deal 5 damage to the opposing enemy. Inflict 4 gutted to the opposing enemy. This ability is completely blocked by shield.";
            breaker0.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.Yellow };
            breaker0.sprite = ResourceLoader.LoadSprite("breaker");
            breaker0.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<DamageShieldBlockedAndGibEffect>(), 5, IntentType.Damage_3_6, Slots.Front),
                new(ScriptableObject.CreateInstance<ApplyGuttedEffectShieldBlocked>(), 4, IntentType.Status_Gutted, Slots.Front),
            };
            breaker0.animationTarget = Slots.Front;
            breaker0.visuals = LoadedAssetsHandler.GetCharacterAbility("Decimation_1_A").visuals;

            Ability breaker1 = breaker0.Duplicate();
            breaker1.name = "Skull Breaker";
            breaker1.description = "Deal 6 damage to the opposing enemy. Inflict 4 gutted to the opposing enemy. This ability is completely blocked by shield.";
            breaker1.effects[0]._entryVariable = 6;

            Ability breaker2 = breaker1.Duplicate();
            breaker2.name = "Chest Breaker";
            breaker2.description = "Deal 8 damage to the opposing enemy. Inflict 4 gutted to the opposing enemy. This ability is completely blocked by shield.";
            breaker2.effects[0]._entryVariable = 8;
            breaker2.effects[0]._intent = IntentType.Damage_7_10;

            Ability breaker3 = breaker2.Duplicate();
            breaker3.name = "Body Breaker";
            breaker3.description = "Deal 10 damage to the opposing enemy. Inflict 4 gutted to the opposing enemy. This ability is completely blocked by shield.";
            breaker3.effects[0]._entryVariable = 10;

            //
            //
            //

            var eatinGood = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            eatinGood._extraPassiveAbility = Connoisseur;

            var bavarianPretzel = new EffectItem();
            bavarianPretzel.name = "Bavarian Pretzel";
            bavarianPretzel.flavorText = "\"Specialty of the 49th state! Pairs amazingly with beer cheese.\"";
            bavarianPretzel.description = "This party member has Connoisseur as a passive.";
            bavarianPretzel.sprite = ResourceLoader.LoadSprite("BavarianPretzel", 1, null);
            bavarianPretzel.unlockableID = (UnlockableID)55262722;
            bavarianPretzel.namePopup = false;
            bavarianPretzel.itemPools = BrutalAPI.ItemPools.Shop;
            bavarianPretzel.shopPrice = 10;
            bavarianPretzel.immediate = true;
            bavarianPretzel.equippedModifiers = new WearableStaticModifierSetterSO[]
            {
                eatinGood
            };

            //
            //
            //

            LootItemProbability food0;
            food0.itemName = "BalticBrine_SW";
            food0.probability = 20;
            LootItemProbability food1;
            food1.itemName = "Cano'Worms_SW";
            food1.probability = 20;
            LootItemProbability food2;
            food2.itemName = "MysteryRation_SW";
            food2.probability = 20;
            LootItemProbability food3;
            food3.itemName = "Vyacheslav'sLastsip_SW";
            food3.probability = 10;
            LootItemProbability food4;
            food4.itemName = "FunnyMushrooms_TW";
            food4.probability = 14;
            LootItemProbability food5;
            food5.itemName = "LumpofLamb_TW";
            food5.probability = 2;
            LootItemProbability food6;
            food6.itemName = "MommaNooty_TW";
            food6.probability = 15;
            LootItemProbability food7;
            food7.itemName = "RuntyRotter_TW";
            food7.probability = 5;
            LootItemProbability food8;
            food8.itemName = "TaintedApple_TW";
            food8.probability = 20;
            LootItemProbability food9;
            food9.itemName = "AGift?_TW";
            food9.probability = 20;
            LootItemProbability food10;
            food10.itemName = "AsceticEgg_TW";
            food10.probability = 5;
            LootItemProbability food11;
            food11.itemName = "Bananas_TW";
            food11.probability = 20;
            LootItemProbability food12;
            food12.itemName = "DivineMud_TW";
            food12.probability = 10;
            LootItemProbability food13;
            food13.itemName = "EggofIncubus_TW";
            food13.probability = 2;
            LootItemProbability food14;
            food14.itemName = "GamifiedCephalopod_TW";
            food14.probability = 20;
            LootItemProbability food15;
            food15.itemName = "HarvestandPlenty_TW";
            food15.probability = 10;
            LootItemProbability food16;
            food16.itemName = "HolyChalice_TW";
            food16.probability = 10;
            LootItemProbability food17;
            food17.itemName = "LustPudding_TW";
            food17.probability = 10;
            LootItemProbability food18;
            food18.itemName = "MeatreWorm_TW";
            food18.probability = 10;
            LootItemProbability food19;
            food19.itemName = "OpulentEgg_TW";
            food19.probability = 2;
            LootItemProbability food20;
            food20.itemName = "SeedsoftheConsumed_TW";
            food20.probability = 20;
            LootItemProbability food21;
            food21.itemName = "SkinnedSkate_TW";
            food21.probability = 20;
            LootItemProbability food22;
            food22.itemName = "StarvingApples_TW";
            food22.probability = 18;
            LootItemProbability food23;
            food23.itemName = "StrangeFruit_TW";
            food23.probability = 20;
            LootItemProbability food24;
            food24.itemName = "TheApple_TW";
            food24.probability = 14;
            LootItemProbability food25;
            food25.itemName = "TheFirstBorn_TW";
            food25.probability = 5;
            LootItemProbability food26;
            food26.itemName = "BavarianPretzel_TW";
            food26.probability = 3;
            LootItemProbability food27;
            food27.itemName = "CheesePlate_TW";
            food27.probability = 2;
            LootItemProbability food28;
            food28.itemName = "FesterFlesh_TW";
            food28.probability = 5;
            LootItemProbability food29;
            food29.itemName = "OneThousandFish_TW";
            food29.probability = 2;
            LootItemProbability food30;
            food30.itemName = "LilOrro_TW";
            food30.probability = 5;
            LootItemProbability food31;
            food31.itemName = "BloodBottle_SW";
            food31.probability = 20;
            LootItemProbability food32;
            food32.itemName = "MedicalLeeches_SW";
            food32.probability = 10;
            LootItemProbability food33;
            food33.itemName = "LilHomunculus_TW";
            food33.probability = 5;
            LootItemProbability food34;
            food34.itemName = "PickledBeets_SW";
            food34.probability = 19;
            LootItemProbability food35;
            food35.itemName = "Sauerkraut_SW";
            food35.probability = 18;
            LootItemProbability food36;
            food36.itemName = "AppleCiderVinegar_SW";
            food36.probability = 19;
            LootItemProbability food37;
            food37.itemName = "AlumSalt_SW";
            food37.probability = 19;
            LootItemProbability food38;
            food38.itemName = "TheSquirrel_TW";
            food38.probability = 10;
            LootItemProbability food39;
            food39.itemName = "ConjoinedFungi_TW";
            food39.probability = 10;
            LootItemProbability food40;
            food40.itemName = "MiracleBerry_SW";
            food40.probability = 10;
            LootItemProbability food41;
            food41.itemName = "Sandvich_SW";
            food41.probability = 20;
            LootItemProbability food42;
            food42.itemName = "MiracleBerry_SW";
            food42.probability = 10;
            LootItemProbability food43;
            food43.itemName = "Cranes'Flesh_TW";
            food43.probability = 14;
            LootItemProbability food44;
            food44.itemName = "MetabolicPigeons_TW";
            food44.probability = 7;
            LootItemProbability food45;
            food45.itemName = "Prometheus_TW";
            food45.probability = 16;
            LootItemProbability food46;
            food46.itemName = "PotassiumNightcap_TW";
            food46.probability = 17;
            LootItemProbability food47;
            food47.itemName = "FunkyCornucopia_TW";
            food47.probability = 18;
            LootItemProbability food48;
            food48.itemName = "NightOil_SW";
            food48.probability = 8;

            var foodList = ScriptableObject.CreateInstance<ExtraLootListCheckLockedEffect>();
            foodList._lootableItems = new LootItemProbability[]
            {
                food0,
                food1,
                food2,
                food3,
                food4,
                food5,
                food6,
                food7,
                food8,
                food9,
                food10,
                food11,
                food12,
                food13,
                food14,
                food15,
                food16,
                food17,
                food18,
                food19,
                food20,
                food21,
                food22,
                food23,
                food24,
                food25,
                food26,
                food27,
                food28,
                food29,
                food30,
                food31,
                food32,
                food33,
                food34,
                food35,
                food36,
                food37,
                food38,
                food39,
                food40,
                food41,
                food42,
                food43,
                food44,
                food45,
                food46,
                food47,
                food48,
            };

            var cheesePlate = new EffectItem();
            cheesePlate.name = "Cheese Plate";
            cheesePlate.flavorText = "\"Also has olives and capers.\"";
            cheesePlate.description = "Cooks 0-3 \"Food\" items at the end of combat.";
            cheesePlate.sprite = ResourceLoader.LoadSprite("CheesePlate", 1, null);
            cheesePlate.unlockableID = (UnlockableID)55262723;
            cheesePlate.namePopup = true;
            cheesePlate.itemPools = BrutalAPI.ItemPools.Shop;
            cheesePlate.shopPrice = 10;
            cheesePlate.trigger = TriggerCalls.OnCombatEnd;
            cheesePlate.effects = new Effect[]
            {
                new(foodList, 1, null, Slots.Self, Conditions.Chance(50)),
                new(foodList, 2, null, Slots.Self, Conditions.Chance(50)),
            };

            FoolItemPairs AlvinarPair = new FoolItemPairs(alvinar, bavarianPretzel, cheesePlate);
            AlvinarPair.Add();

            
            alvinar.AddLevel(12, new Ability[3] { frenzy0, feast0, breaker0 }, 0);
            alvinar.AddLevel(12, new Ability[3] { frenzy1, feast1, breaker1 }, 1);
            alvinar.AddLevel(14, new Ability[3] { frenzy2, feast2, breaker2 }, 2);
            alvinar.AddLevel(16, new Ability[3] { frenzy3, feast3, breaker3 }, 3);
            alvinar.AddCharacter();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Alvinar");
        }
    }
}
