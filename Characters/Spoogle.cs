namespace Dui_Mauris_Furyball
{
    public static class Spoogle
    {
        public static void Add()

        {
            //stored values for leaky
            CasterStoredValueChangeEffect LeakinessUp = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            LeakinessUp._increase = true;
            LeakinessUp._valueName = (UnitStoredValueNames)888833;
            CasterStoredValueChangeEffect LeakinessDown = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            LeakinessDown._increase = false;
            LeakinessDown._minimumValue = 0;
            LeakinessDown._valueName = (UnitStoredValueNames)888833;


            //custom passives
            PerformEffectPassiveAbility Leaky1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            Leaky1._passiveName = "Leaky (1)";
            Leaky1.type = (PassiveAbilityTypes)833333;
            Leaky1.passiveIcon = Passives.Leaky.passiveIcon;
            Leaky1._enemyDescription = "Upon receiving direct damage, this enemy generates extra pigment of its health colour.";
            Leaky1._characterDescription = "Upon receiving direct damage, this character generates extra pigment of its health colour.";
            Leaky1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new Effect(ScriptableObject.CreateInstance<LeakingLeakingLeaking>(), 0, null, Slots.Self),
                });
            Leaky1._triggerOn = new TriggerCalls[]
                {
                    TriggerCalls.OnDirectDamaged
                };


            PerformEffectPassiveAbility Solidifying = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            Solidifying._passiveName = "Solidifying";
            Solidifying.type = (PassiveAbilityTypes)883333;
            Solidifying.passiveIcon = ResourceLoader.LoadSprite("SolidifyingPassiveIcon");
            Solidifying._enemyDescription = "At the start of this enemy's turn, reduce this enemy's leaky by 1.";
            Solidifying._characterDescription = "At the start of this character's turn, reduce this character's leaky by 1.";
            Solidifying.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new Effect(LeakinessDown, 1, null, Slots.Self),
                });
            Solidifying._triggerOn = new TriggerCalls[]
                {
                    TriggerCalls.OnTurnStart
                };

            //Spoogle Basics
            Character spoogle = new Character();
            
            spoogle.name = "Spoogle";
            spoogle.healthColor = Pigments.Yellow;
            spoogle.entityID = (EntityIDs)838383;
            spoogle.frontSprite = ResourceLoader.LoadSprite("SpoogleFront");
            spoogle.backSprite = ResourceLoader.LoadSprite("SpoogleBack");
            spoogle.overworldSprite = ResourceLoader.LoadSprite("SpoogleOverworld", 32, new Vector2(0.5f, 0.02f));
            spoogle.lockedSprite = ResourceLoader.LoadSprite("SpoogleLocked");
            spoogle.unlockedSprite = ResourceLoader.LoadSprite("SpoogleMenu");
            spoogle.menuChar = true;
            spoogle.appearsInShops = true;
            spoogle.hurtSound = LoadedAssetsHandler.GetEnemy("GildedGulper_EN").deathSound;
            spoogle.deathSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").deathSound;
            spoogle.dialogueSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").damageSound;
            spoogle.isSupport = false;
            spoogle.passives = new BasePassiveAbilitySO[]
            {
                Solidifying,
                Leaky1
            };

            IDetour Leakiness = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(Spoogle).GetMethod("AddStoredValueName", ~BindingFlags.Default));


            //mm yumby yellow pigmento :Q
            ConsumeAllColorManaEffect YummyYellow = ScriptableObject.CreateInstance<ConsumeAllColorManaEffect>();
            YummyYellow._consumeMana = Pigments.Yellow;
            YummyYellow._includeGenerator = true;


            //indirect damage because generating pigment other than yellow is horrid
            DamageEffect IndirectDamage = ScriptableObject.CreateInstance<DamageEffect>();
            IndirectDamage._indirect = true;


            //vomit
            Ability vomit0 = new Ability();
            vomit0.name = "Vomit up Dinner";
            vomit0.description = "Increase Leaky by 1. Deal 1 self damage. Deal 2 indirect damage to the opposing enemy. 80% chance to refresh this party member.";
            vomit0.cost = new ManaColorSO[] { Pigments.SplitPigment(Pigments.Blue, Pigments.Yellow) };
            vomit0.sprite = ResourceLoader.LoadSprite("vomit");
            vomit0.effects = new Effect[]
                {
                    new (LeakinessUp, 1, null, Slots.Self),
                    new (ScriptableObject.CreateInstance<DamageEffect>(), 1, IntentType.Damage_1_2, Slots.Self),
                    new (IndirectDamage, 2, IntentType.Damage_1_2, Slots.Front),
                    new (ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, IntentType.Other_Refresh, Slots.Self, Conditions.Chance(80)),
                };
            vomit0.animationTarget = Slots.Self;
            vomit0.visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals;

            Ability vomit1 = vomit0.Duplicate();
            vomit1.name = "Vomit up Lunch";
            vomit1.description = "Increase Leaky by 1. Deal 1 self damage. Deal 3 indirect damage to the opposing enemy. 83% chance to refresh this party member.";
            vomit1.effects[2]._entryVariable = 3;
            vomit1.effects[3] = new Effect(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(),
                1, IntentType.Other_Refresh, Slots.Self, Conditions.Chance(83));

            Ability vomit2 = vomit1.Duplicate();
            vomit2.name = "Vomit up Breakfast";
            vomit2.description = "Increase Leaky by 1. Deal 1 self damage. Deal 4 indirect damage to the opposing enemy. 88% chance to refresh this party member.";
            vomit2.effects[2]._entryVariable = 4;
            vomit0.effects[2]._intent = IntentType.Damage_3_6;
            vomit2.effects[3] = new Effect(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(),
                1, IntentType.Other_Refresh, Slots.Self, Conditions.Chance(88));

            Ability vomit3 = vomit2.Duplicate();
            vomit3.name = "Vomit up Yesterday's Dinner";
            vomit3.description = "Increase Leaky by 1. Deal 1 self damage. Deal 5 indirect damage to the opposing enemy. 90% chance to refresh this party member.";
            vomit3.effects[2]._entryVariable = 5;
            vomit3.effects[3] = new Effect(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(),
                1, IntentType.Other_Refresh, Slots.Self, Conditions.Chance(90));


            //ablate
            DamageEffect AblateDamage = ScriptableObject.CreateInstance<DamageEffect>();
            AblateDamage._usePreviousExitValue = true;

            Ability ablate0 = new Ability();
            ablate0.name = "Feebly Ablate";
            ablate0.description = "Increase Leaky by 3, then heal 1. Consume all yellow pigment. Deal 1 damage for each pigment consumed to the Opposing enemy.";
            ablate0.cost = new ManaColorSO[] { Pigments.SplitPigment(Pigments.Red, Pigments.Yellow), Pigments.SplitPigment(Pigments.Red, Pigments.Yellow) };
            ablate0.sprite = ResourceLoader.LoadSprite("ablate");
            ablate0.effects = new Effect[]
                {
                    new(LeakinessUp, 3, null, Slots.Self),
                    new(ScriptableObject.CreateInstance<HealEffect>(), 1, IntentType.Heal_1_4, Slots.Self),
                    new(YummyYellow, 0, IntentType.Mana_Consume, Slots.Self),
                    new(ScriptableObject.CreateInstance<PreviousExitPercentage>(), 100, null, Slots.Self),
                    new(AblateDamage, 1, IntentType.Damage_7_10, Slots.Front),
                };
            ablate0.animationTarget = Slots.Self;
            ablate0.visuals = LoadedAssetsHandler.GetCharacterAbility("Wrath_1_A").visuals;

            Ability ablate1 = ablate0.Duplicate();
            ablate1.name = "Fiercely Ablate";
            ablate1.description = "Increase Leaky by 3, then heal 1. Consume all yellow pigment. Deal 1.3 damage for each pigment consumed to the Opposing enemy.";
            ablate1.effects[3]._entryVariable = 130;
            ablate1.effects[4]._intent = IntentType.Damage_11_15;

            Ability ablate2 = ablate1.Duplicate();
            ablate2.name = "Frightfully Ablate";
            ablate2.description = "Increase Leaky by 3, then heal 2. Consume all yellow pigment. Deal 1.6 damage for each pigment consumed to the Opposing enemy.";
            ablate2.effects[3]._entryVariable = 160;
            ablate2.effects[4]._intent = IntentType.Damage_16_20;

            Ability ablate3 = ablate2.Duplicate();
            ablate3.name = "Fantasmagorically Ablate";
            ablate3.description = "Increase Leaky by 3, then heal 2. Consume all yellow pigment. Deal 1.8 damage for each pigment consumed to the Opposing enemy.";
            ablate3.effects[1]._entryVariable = 3;
            ablate3.effects[3]._entryVariable = 180;

            //concatenation
            HealEffect ConcatenationHeal = ScriptableObject.CreateInstance<HealEffect>();
            ConcatenationHeal.usePreviousExitValue = true;

            Ability concatenation0 = new Ability();
            concatenation0.name = "Reduction Concatenation";
            concatenation0.description = "Decrease leaky by 2. Deal 1 self damage. Consume all yellow pigment, then heal 1 for every pigment consumed.";
            concatenation0.cost = new ManaColorSO[] { Pigments.SplitPigment(Pigments.Purple, Pigments.Yellow), Pigments.SplitPigment(Pigments.Purple, Pigments.Yellow), Pigments.SplitPigment(Pigments.Purple, Pigments.Yellow) };
            concatenation0.sprite = ResourceLoader.LoadSprite("concatenation");
            concatenation0.effects = new Effect[]
                {
                    new(LeakinessDown, 2, null, Slots.Self),
                    new(ScriptableObject.CreateInstance<DamageEffect>(), 1, IntentType.Damage_1_2, Slots.Self),
                    new(YummyYellow, 0, IntentType.Mana_Consume, Slots.Self),
                    new(ScriptableObject.CreateInstance<PreviousExitPercentage>(), 100, null, Slots.Self),
                    new(ConcatenationHeal, 1, IntentType.Heal_1_4, Slots.Self),
                };
            concatenation0.animationTarget = Slots.Self;
            concatenation0.visuals = LoadedAssetsHandler.GetCharacterAbility("Huff_1_A").visuals;

            Ability concatenation1 = concatenation0.Duplicate();
            concatenation1.name = "Oxidation Concatenation";
            concatenation1.description = "Decrease leaky by 2. Deal 1 self damage. Consume all yellow pigment, then heal 1.3 for every pigment consumed.";
            concatenation1.effects[3]._entryVariable = 130;
            concatenation1.effects[4]._intent = IntentType.Heal_5_10;

            Ability concatenation2 = concatenation1.Duplicate();
            concatenation2.name = "Coagulation Concatenation";
            concatenation2.description = "Decrease leaky by 2. Deal 1 self damage. Consume all yellow pigment, then heal 1.6 for every pigment consumed.";
            concatenation2.effects[3]._entryVariable = 160;
            concatenation2.effects[4]._intent = IntentType.Heal_11_20;

            Ability concatenation3 = concatenation2.Duplicate();
            concatenation3.name = "Imagination Concatentation";
            concatenation3.description = "Decrease leaky by 2. Deal 1 self damage. Consume all yellow pigment, then heal 2 for every pigment consumed.";
            concatenation3.effects[3]._entryVariable = 200;
            concatenation3.effects[4]._intent = IntentType.Heal_21;

            //
            //
            //

            var checkTwo = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            checkTwo.previousAmount = new int[] { 1, 3 };
            checkTwo.wasSuccessful = new bool[] { true, true };

            var aestheticCheck = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            aestheticCheck.previousAmount = 3;

            var rainbowmize = ScriptableObject.CreateInstance<RandomizeAllManaEffect>();
            rainbowmize.manaRandomOptions = new ManaColorSO[] { Pigments.Yellow, Pigments.Red, Pigments.Blue, Pigments.Purple };

            EffectItem iridescentCrystal = new EffectItem();
            iridescentCrystal.name = "Iridescent Crystal";
            iridescentCrystal.flavorText = "\"The most angular rainbow in nature.\"";
            iridescentCrystal.description = "Upon any ally action being performed, absorb 1 pigment and roll a 28% chance to refill the pigment generator.";
            iridescentCrystal.sprite = ResourceLoader.LoadSprite("IridescentCrystal", 1, null);
            iridescentCrystal.trigger = TriggerCalls.OnAnyAbilityUsed;
            iridescentCrystal.unlockableID = (UnlockableID)2226355;
            iridescentCrystal.namePopup = false;
            iridescentCrystal.itemPools = BrutalAPI.ItemPools.Treasure;
            iridescentCrystal.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<CheckIsPlayerTurnEffect>(), 1, null, Slots.Self),
                new(ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 1, null, Slots.Self, ScriptableObject.CreateInstance<PreviousEffectCondition>()),
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, Conditions.Chance(28)),
                new(ScriptableObject.CreateInstance<FillYellowManaBar_Effect>(), 1, null, Slots.Self, checkTwo),
                new(ScriptableObject.CreateInstance<PopUpCasterItemInfoEffect>(), 1, null, Slots.Self, aestheticCheck),
            };

            //
            //
            //

            var makeYellow = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            makeYellow.mana = Pigments.Yellow;

            var changeYellow = ScriptableObject.CreateInstance<BismuthCostReroll>();
            changeYellow._newCosts = new()
            {
                Pigments.SplitPigment(Pigments.Red, Pigments.Yellow),
            };

            DoubleEffectItem bismuthSubsalicylate = new DoubleEffectItem();
            bismuthSubsalicylate.name = "Bismuth Subsalicylate";
            bismuthSubsalicylate.flavorText = "\"No more tummy aches.\"";
            bismuthSubsalicylate.description = "Generate one yellow pigment at the start of each turn. This party member's costs are now all split yellow red.";
            bismuthSubsalicylate.sprite = ResourceLoader.LoadSprite("BismuthSubsalicylate", 1, null);
            bismuthSubsalicylate.unlockableID = (UnlockableID)2226356;
            bismuthSubsalicylate.itemPools = BrutalAPI.ItemPools.Shop;
            bismuthSubsalicylate.shopPrice = 6;
            bismuthSubsalicylate.trigger = TriggerCalls.OnCombatStart;
            bismuthSubsalicylate.firstEffects = new Effect[]
            {
                new(changeYellow, 1, null, Slots.Self),
            };
            bismuthSubsalicylate.SecondTrigger = new TriggerCalls[]
            {
                TriggerCalls.OnTurnStart,
            };
            bismuthSubsalicylate.secondEffects = new Effect[]
            {
                new(makeYellow, 1, null, Slots.Self),
            };

            FoolItemPairs SpooglePair = new FoolItemPairs(spoogle, iridescentCrystal, bismuthSubsalicylate);
            SpooglePair.Add();

            
            spoogle.AddLevel(10, new Ability[3] { ablate0, vomit0, concatenation0 }, 0);
            spoogle.AddLevel(12, new Ability[3] { ablate1, vomit1, concatenation1 }, 1);
            spoogle.AddLevel(13, new Ability[3] { ablate2, vomit2, concatenation2 }, 2);
            spoogle.AddLevel(15, new Ability[3] { ablate3, vomit3, concatenation3 }, 3);
            spoogle.AddCharacter();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Spoogle");

        }

        public static string AddStoredValueName(
            Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
            TooltipTextHandlerSO self, UnitStoredValueNames storedValue, int value)
        {
            Color yellow = Color.yellow;
            string str1;
            if (storedValue == (UnitStoredValueNames)888833)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Leaky" + string.Format(" +{0}", (object)value);
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
