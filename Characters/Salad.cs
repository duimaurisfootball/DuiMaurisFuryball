namespace Dui_Mauris_Furyball
{
    public static class Salad
    {
        public static void Add()

        {
            //stored values for metallurgy
            var setMetallurgy = ScriptableObject.CreateInstance<CasterStoredValueSetByExitValueEffect>();
            setMetallurgy._valueName = (UnitStoredValueNames)258384;
    
            //check for that doller doller bayb
            var checkDosh = ScriptableObject.CreateInstance<Check_CountCurrencyEffect>();
            checkDosh._returnPercentage = true;
            var checkCash = ScriptableObject.CreateInstance<CheckStoredValuePercentageEffect>();
            checkCash._returnPercentage = true;

            //damage and shield and health exit valyou
            var metalDamage = ScriptableObject.CreateInstance<DamageEffect>();
            metalDamage._usePreviousExitValue = true;
            ApplyShieldSlotEffect metalShield = ScriptableObject.CreateInstance<ApplyShieldSlotEffect>();
            metalShield._usePreviousExitValue = true;

            //funny animation
            var smite = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            smite._animationTarget = Slots.Self;
            smite._visuals = LoadedAssetsHandler.GetEnemyAbility("RapturousReverberation_A").visuals;

            //custom passives
            PerformEffectPassiveAbility Metallurgy = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            Metallurgy._passiveName = "Metallurgy";
            Metallurgy.type = (PassiveAbilityTypes)248684;
            Metallurgy.passiveIcon = ResourceLoader.LoadSprite("Metallurgy");
            Metallurgy._enemyDescription = "This enemy's stats are based around the number of coins at the beginning of combat.";
            Metallurgy._characterDescription = "This party member's stats are based around the number of coins at the beginning of combat.";
            Metallurgy.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new(checkDosh, 100, null, Slots.Self),
                    new(setMetallurgy, 1, null, Slots.Self),
                });
            Metallurgy._triggerOn = new TriggerCalls[]
                {
                TriggerCalls.OnFirstTurnStart
                };

            PerformEffectPassiveAbility Penalty = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            Penalty._passiveName = "Questioner's Penalty";
            Penalty.type = (PassiveAbilityTypes)248685;
            Penalty.passiveIcon = ResourceLoader.LoadSprite("Penalty");
            Penalty._enemyDescription = "It is hard for a rich man to enter into the kingdom of heaven.";
            Penalty._characterDescription = "It is hard for a rich man to enter into the kingdom of heaven. (More cash, more curse)";
            Penalty.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new(checkCash, 83, null, Slots.Self),
                    new(ScriptableObject.CreateInstance<ApplyCurseOnPercentageWithExitValueEffect>(), 1, null, Slots.Self),
                    new(smite, 1, null, Slots.Self, ScriptableObject.CreateInstance<PreviousEffectCondition>()),
                });
            Penalty._triggerOn = new TriggerCalls[]
                {
                    TriggerCalls.OnFirstTurnStart
                };

            //Salad Basics
            Character salad = new Character();
            Debug.Log("loading");
            salad.name = "Salad";
            salad.healthColor = Pigments.Purple;
            salad.entityID = (EntityIDs)248241;
            salad.frontSprite = ResourceLoader.LoadSprite("SaladFront");
            salad.backSprite = ResourceLoader.LoadSprite("SaladBack");
            salad.overworldSprite = ResourceLoader.LoadSprite("SaladOverworld", 32, new Vector2(0.5f, 0.02f));
            salad.lockedSprite = ResourceLoader.LoadSprite("SaladLocked");
            salad.unlockedSprite = ResourceLoader.LoadSprite("SaladMenu");
            salad.menuChar = true;
            salad.appearsInShops = true;
            salad.hurtSound = LoadedAssetsHandler.GetCharcater("SmokeStacks_CH").damageSound;
            salad.deathSound = LoadedAssetsHandler.GetCharcater("SmokeStacks_CH").deathSound;
            salad.dialogueSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").damageSound;
            salad.isSupport = false;
            salad.levels = new CharacterRankedData[1];
            salad.passives = new BasePassiveAbilitySO[]
            {
                Metallurgy,
                Penalty
            };


            IDetour Metallurgies = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(Salad).GetMethod("AddStoredValueName", ~BindingFlags.Default));

            //copper and rhodium
            Ability copperAndRhodium = new Ability();
            copperAndRhodium.name = "Copper and Rhodium";
            copperAndRhodium.description = "Deal damage equal to 28% of Metallurgy plus 3 to the opposing enemy.";
            copperAndRhodium.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.Yellow };
            copperAndRhodium.sprite = ResourceLoader.LoadSprite("CopperAndRhodium");
            copperAndRhodium.effects = new Effect[]
                {
                    new(checkCash, 28, null, Slots.Front),
                    new(metalDamage, 1, IntentType.Damage_7_10, Slots.Front),
                };
            copperAndRhodium.animationTarget = Slots.Front;
            copperAndRhodium.visuals = LoadedAssetsHandler.GetCharacterAbility("Skewer_1_A").visuals;


            //titanium and iridium
            Ability titaniumAndIridium = new Ability();
            titaniumAndIridium.name = "Titanium and Iridium";
            titaniumAndIridium.description = "Deal damage equal to 15% of Metallurgy plus 2 to the left and right enemies. Apply shield equal to 18% of Metallurgy plus 2 to this position.";
            titaniumAndIridium.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.Blue };
            titaniumAndIridium.sprite = ResourceLoader.LoadSprite("TitaniumAndIridium");
            titaniumAndIridium.effects = new Effect[]
                {
                    new(checkCash, 15, null, Slots.Self),
                    new(metalDamage, 1, IntentType.Damage_7_10, Slots.LeftRight),
                    new(checkCash, 18, null, Slots.Self),
                    new(metalShield, 1, IntentType.Field_Shield, Slots.Self),
                };
            titaniumAndIridium.animationTarget = Slots.Self;
            titaniumAndIridium.visuals = LoadedAssetsHandler.GetCharacterAbility("Smokescreen_1_A").visuals;


            var Brevious = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            Brevious.wasSuccessful = false;

            //mercury and technetium
            Ability mercuryAndTechnetium = new Ability();
            mercuryAndTechnetium.name = "Mercury and Technetium";
            mercuryAndTechnetium.description = "Inflict scars to the opposing enemy equal to 10% of Metallurgy plus 1.";
            mercuryAndTechnetium.cost = new ManaColorSO[] { Pigments.Red, Pigments.Purple };
            mercuryAndTechnetium.sprite = ResourceLoader.LoadSprite("MercuryAndTechnetium");
            mercuryAndTechnetium.effects = new Effect[]
                { 
                    new(checkCash, 10, null, Slots.Front),
                    new(ScriptableObject.CreateInstance<MetallurgicalScars>(), 1, IntentType.Status_Scars, Slots.Front),
                };
            mercuryAndTechnetium.animationTarget = Slots.Front;
            mercuryAndTechnetium.visuals = LoadedAssetsHandler.GetCharacterAbility("Fumes_1_A").visuals;

            //
            //
            //

            var spawnSalad = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereEffect>();
            spawnSalad._characterCopy = "Pre-Fab Salad_CH";
            spawnSalad._rank = 0;
            spawnSalad._nameAddition = NameAdditionLocID.NameAdditionNone;
            spawnSalad._permanentSpawn = false;
            spawnSalad._usePreviousAsHealth = false;
            spawnSalad._extraModifiers = new WearableStaticModifierSetterSO[]
            {
                
            };

            EffectItem hyperfixation = new EffectItem();
            hyperfixation.name = "Hyperfixation";
            hyperfixation.flavorText = "\"Hot damn!\"";
            hyperfixation.description = "Attempt to fabricate a temporary pre-powered Salad on combat start. This item is destroyed upon activation.";
            hyperfixation.sprite = ResourceLoader.LoadSprite("Hyperfixation", 1, null);
            hyperfixation.trigger = TriggerCalls.OnCombatStart;
            hyperfixation.unlockableID = (UnlockableID)3338885;
            hyperfixation.namePopup = false;
            hyperfixation.itemPools = BrutalAPI.ItemPools.Treasure;
            hyperfixation.effects = new Effect[]
            {
                new(spawnSalad, 1, null, Slots.SlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 }, true)),
                new(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, null, Slots.Self, ScriptableObject.CreateInstance<PreviousEffectCondition>()),
            };

            //
            //
            //

            IDetour Squares = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(ElementStoredValue).GetMethod("AddStoredValueName", ~BindingFlags.Default));

            var pentagon = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            pentagon._increase = true;
            pentagon._valueName = (UnitStoredValueNames)555769;

            var triangle = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            triangle._increase = false;
            triangle._valueName = (UnitStoredValueNames)555769;

            var squareRoot = ScriptableObject.CreateInstance<CasterStoreValueCheckEffect>();
            squareRoot._valueName = (UnitStoredValueNames)555769;

            var shieldPrevious = ScriptableObject.CreateInstance<ApplyShieldSlotEffect>();
            shieldPrevious._usePreviousExitValue = true;

            DoubleEffectItem element83 = new DoubleEffectItem();
            element83.name = "Element 83";
            element83.flavorText = "\"Squares eternal, colors infernal.\"";
            element83.description = "Apply 4 shield to this party member's position on turn end. 50% chance to increase the amount by 2, 60% chance to decrease it by 1.";
            element83.sprite = ResourceLoader.LoadSprite("Element83", 1, null);
            element83.unlockableID = (UnlockableID)3338886;
            element83.namePopup = true;
            element83.itemPools = BrutalAPI.ItemPools.Treasure;
            element83.trigger = TriggerCalls.OnTurnFinished;
            element83.firstEffects = new Effect[]
            {
                new(squareRoot, 1, null, Slots.Self),
                new(shieldPrevious, 1, null, Slots.Self),
                new(pentagon, 2 , null, Slots.Self, Conditions.Chance(50)),
                new(triangle, 1 , null, Slots.Self, Conditions.Chance(60)),
            };
            element83.SecondTrigger = new TriggerCalls[]
            {
                TriggerCalls.OnCombatStart,
            };
            element83.secondEffects = new Effect[]
            {
                new(pentagon, 4, null, Slots.Self),
            };


            FoolItemPairs SaladPair = new FoolItemPairs(salad, hyperfixation, element83);
            SaladPair.Add();

            Debug.Log("loading");
            salad.AddLevel(30, new Ability[3] { titaniumAndIridium, copperAndRhodium, mercuryAndTechnetium }, 0);
            salad.AddCharacter();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Salad");

        }
        public static string AddStoredValueName(
            Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
            TooltipTextHandlerSO self, UnitStoredValueNames storedValue, int value)
        {
            Color yellow = Color.yellow;
            string str1;
            if (storedValue == (UnitStoredValueNames)258384)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Metallurgy" + string.Format(" +{0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.yellow) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }
    }
}
