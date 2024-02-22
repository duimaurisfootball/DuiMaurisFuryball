namespace Dui_Mauris_Furyball
{
    public static class PreFabSalad
    {
        public static void Add()

        {
            //stored values for metallurgy
            var setMetallurgy = ScriptableObject.CreateInstance<CasterStoredValueSetByExitValueEffect>();
            setMetallurgy._valueName = (UnitStoredValueNames)258385;
            setMetallurgy._randomBetweenEntryAndPrevious = true;

            //check for that doller doller bayb
            var checkCash = ScriptableObject.CreateInstance<CheckStoredValuePercentageEffect>();
            checkCash._returnPercentage = true;
            checkCash._valueName = (UnitStoredValueNames)258385;


            //damage and shield and health exit valyou
            var MetalDamage = ScriptableObject.CreateInstance<DamageEffect>();
            MetalDamage._usePreviousExitValue = true;
            ApplyShieldSlotEffect MetalShield = ScriptableObject.CreateInstance<ApplyShieldSlotEffect>();
            MetalShield._usePreviousExitValue = true;

            //funny animation
            var smite = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            smite._animationTarget = Slots.Self;
            smite._visuals = LoadedAssetsHandler.GetEnemyAbility("RapturousReverberation_A").visuals;

            //custom passives
            var Metallurgy = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            Metallurgy._passiveName = "Metallurgy";
            Metallurgy.type = (PassiveAbilityTypes)24821384;
            Metallurgy.passiveIcon = ResourceLoader.LoadSprite("Metallurgy");
            Metallurgy._enemyDescription = "This enemy's stats are based around this number.";
            Metallurgy._characterDescription = "This party member's stats are based around this number.";
            Metallurgy.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 50, null, Slots.Self),
                    new(setMetallurgy, 83, null, Slots.Self),
                });
            Metallurgy.disconnectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[0]);
            Metallurgy._triggerOn = new TriggerCalls[0];

            var Penalty = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            Penalty._passiveName = "Questioner's Penalty";
            Penalty.type = (PassiveAbilityTypes)24862135;
            Penalty.passiveIcon = ResourceLoader.LoadSprite("Penalty");
            Penalty._enemyDescription = "It is hard for a rich man to enter into the kingdom of heaven.";
            Penalty._characterDescription = "It is hard for a rich man to enter into the kingdom of heaven.";
            Penalty.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new(checkCash, 83, null, Slots.Self),
                    new(ScriptableObject.CreateInstance<ApplyCurseOnPercentageWithExitValueEffect>(), 1, null, Slots.Self),
                    new(smite, 1, null, Slots.Self, ScriptableObject.CreateInstance<PreviousEffectCondition>()),
                });
            Penalty.disconnectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[0]);
            Penalty._triggerOn = new TriggerCalls[0];

            //Salad Basics
            Character salad2 = new Character();
            
            salad2.name = "Pre-Fab Salad";
            salad2.healthColor = Pigments.Purple;
            salad2.entityID = (EntityIDs)258995;
            salad2.frontSprite = ResourceLoader.LoadSprite("SaladFront");
            salad2.backSprite = ResourceLoader.LoadSprite("SaladBack");
            salad2.overworldSprite = ResourceLoader.LoadSprite("SaladOverworld", 32, new Vector2(0.5f, 0.02f));
            salad2.lockedSprite = ResourceLoader.LoadSprite("SaladLocked");
            salad2.unlockedSprite = ResourceLoader.LoadSprite("SaladMenu");
            salad2.menuChar = false;
            salad2.appearsInShops = false;
            salad2.isSecret = true;
            salad2.hurtSound = LoadedAssetsHandler.GetCharcater("SmokeStacks_CH").damageSound;
            salad2.deathSound = LoadedAssetsHandler.GetCharcater("SmokeStacks_CH").deathSound;
            salad2.dialogueSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").damageSound;
            salad2.isSupport = false;
            salad2.usesAllAbilities = true;
            salad2.usesBaseAbility = false;
            salad2.levels = new CharacterRankedData[1];
            salad2.passives = new BasePassiveAbilitySO[]
            {
                Metallurgy,
                Penalty
            };

            var copperDamage = ScriptableObject.CreateInstance<DamageFromPreviousAddEntryCustomAnimationsEffect_A>();
            copperDamage._animationTarget = Slots.Front;

            var titaniumDamage = ScriptableObject.CreateInstance<DamageFromPreviousAddEntryCustomAnimationsEffect_B>();
            titaniumDamage._animationTarget = Slots.SlotTarget(new int[] { -1, 1 }, false);

            var iridiumShield = ScriptableObject.CreateInstance<ApplyShieldFromPreviousAddEntryCustomAnimationsEffect>();
            iridiumShield._animationTarget = Slots.Self;

            var mercuryScars = ScriptableObject.CreateInstance<ApplyScarsFromPreviousAddEntryCustomAnimationsEffect>();
            mercuryScars._animationTarget = Slots.Front;


            IDetour Metallurgies = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(PreFabSalad).GetMethod("AddStoredValueName", ~BindingFlags.Default));

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


            salad2.AddLevel(30, new Ability[3] { copperAndRhodium, titaniumAndIridium, mercuryAndTechnetium }, 0);
            salad2.levels[0].rankAbilities[0].ability.specialStoredValue = (UnitStoredValueNames)258385;
            salad2.levels[0].rankAbilities[1].ability.specialStoredValue = (UnitStoredValueNames)258385;
            salad2.levels[0].rankAbilities[2].ability.specialStoredValue = (UnitStoredValueNames)258385;
            salad2.AddCharacter();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Pre-Fab Salad");

        }

        public static string AddStoredValueName(
            Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
            TooltipTextHandlerSO self, UnitStoredValueNames storedValue, int value)
        {
            Color yellow = Color.yellow;
            string str1;
            if (storedValue == (UnitStoredValueNames)258385)
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
