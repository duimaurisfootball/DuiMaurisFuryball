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
            checkCash._valueName = (UnitStoredValueNames)258384;

            //funny animation
            var smite = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            smite._animationTarget = Slots.Self;
            smite._visuals = LoadedAssetsHandler.GetEnemyAbility("RapturousReverberation_A").visuals;

            //custom passives
            var Metallurgy = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            Metallurgy._passiveName = "Metallurgy";
            Metallurgy.type = (PassiveAbilityTypes)248684;
            Metallurgy.passiveIcon = ResourceLoader.LoadSprite("Metallurgy");
            Metallurgy._enemyDescription = "This enemy's stats are based around the number of coins at the beginning of combat.";
            Metallurgy._characterDescription = "This party member's stats are based around the number of coins at the beginning of combat.";
            Metallurgy.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new(checkDosh, 100, null, Slots.Self),
                    new(setMetallurgy, 1, null, Slots.Self),
                });
            Metallurgy.disconnectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[0]);
            Metallurgy._triggerOn = new TriggerCalls[0];

            var Penalty = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            Penalty._passiveName = "Questioner's Penalty";
            Penalty.type = (PassiveAbilityTypes)248685;
            Penalty.passiveIcon = ResourceLoader.LoadSprite("Penalty");
            Penalty._enemyDescription = "It is hard for a rich man to enter into the kingdom of heaven.";
            Penalty._characterDescription = "It is hard for a rich man to enter into the kingdom of heaven. (More cash, more curse)";
            Penalty.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new(checkCash, 83, null, Slots.Self),
                    new(ScriptableObject.CreateInstance<ApplyCurseOnPercentageWithExitValueEffect>(), 1, null, Slots.Self),
                    new(smite, 1, null, Slots.Self, ScriptableObject.CreateInstance<PreviousEffectCondition>()),
                });
            Penalty.disconnectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[0]);
            Penalty._triggerOn = new TriggerCalls[0];

            //Salad Basics
            Character salad = new Character();
            
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
            salad.dialogueSound = LoadedAssetsHandler.GetCharcater("SmokeStacks_CH").dxSound;
            salad.isSupport = false;
            salad.levels = new CharacterRankedData[1];
            salad.passives = new BasePassiveAbilitySO[]
            {
                Metallurgy,
                Penalty,
            };

            var copperDamage = ScriptableObject.CreateInstance<DamageFromPreviousAddEntryCustomAnimationsEffect_A>();
            copperDamage._animationTarget = Slots.Front;

            var titaniumDamage = ScriptableObject.CreateInstance<DamageFromPreviousAddEntryCustomAnimationsEffect_B>();
            titaniumDamage._animationTarget = Slots.SlotTarget(new int[] {-1, 1}, false);

            var iridiumShield = ScriptableObject.CreateInstance<ApplyShieldFromPreviousAddEntryCustomAnimationsEffect>();
            iridiumShield._animationTarget = Slots.Self;

            var mercuryScars = ScriptableObject.CreateInstance<ApplyScarsFromPreviousAddEntryCustomAnimationsEffect>();
            mercuryScars._animationTarget = Slots.Front;


            IDetour Metallurgies = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(Salad).GetMethod("AddStoredValueName", ~BindingFlags.Default));


            //copper and rhodium
            var copperAndRhodium = new Ability();
            copperAndRhodium.name = "Copper and Rhodium";
            copperAndRhodium.description = "Deal damage equal to 28% of Metallurgy + 3 to the opposing enemy.";
            copperAndRhodium.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.Yellow };
            copperAndRhodium.sprite = ResourceLoader.LoadSprite("CopperAndRhodium");
            copperAndRhodium.effects = new Effect[]
                {
                    new(checkCash, 28, null, Slots.Front),
                    new(copperDamage, 3, IntentType.Damage_7_10, Slots.Front),
                };

            //titanium and iridium
            var titaniumAndIridium = new Ability();
            titaniumAndIridium.name = "Titanium and Iridium";
            titaniumAndIridium.description = "Deal damage equal to 15% of Metallurgy + 2 to the left and right enemies. Apply shield equal to 18% of Metallurgy + 2 to this position.";
            titaniumAndIridium.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.Blue };
            titaniumAndIridium.sprite = ResourceLoader.LoadSprite("TitaniumAndIridium");
            titaniumAndIridium.effects = new Effect[]
                {
                    new(checkCash, 15, null, Slots.Self),
                    new(titaniumDamage, 2, IntentType.Damage_7_10, Slots.LeftRight),
                    new(checkCash, 18, null, Slots.Self),
                    new(iridiumShield, 2, IntentType.Field_Shield, Slots.Self),
                };


            var Brevious = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            Brevious.wasSuccessful = false;

            //mercury and technetium
            var mercuryAndTechnetium = new Ability();
            mercuryAndTechnetium.name = "Mercury and Technetium";
            mercuryAndTechnetium.description = "Inflict scars to the opposing enemy equal to 10% of Metallurgy + 1.";
            mercuryAndTechnetium.cost = new ManaColorSO[] { Pigments.Red, Pigments.Purple };
            mercuryAndTechnetium.sprite = ResourceLoader.LoadSprite("MercuryAndTechnetium");
            mercuryAndTechnetium.effects = new Effect[]
                {
                    new(checkCash, 10, null, Slots.Front),
                    new(mercuryScars, 1, IntentType.Status_Scars, Slots.Front),
                };

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

            
            salad.AddLevel(30, new Ability[3] { copperAndRhodium, titaniumAndIridium, mercuryAndTechnetium }, 0);
            salad.levels[0].rankAbilities[0].ability.specialStoredValue = (UnitStoredValueNames)258384;
            salad.levels[0].rankAbilities[1].ability.specialStoredValue = (UnitStoredValueNames)258384;
            salad.levels[0].rankAbilities[2].ability.specialStoredValue = (UnitStoredValueNames)258384;
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
                    string str2 = "Metallurgy" + string.Format(" {0}", (object)value);
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
