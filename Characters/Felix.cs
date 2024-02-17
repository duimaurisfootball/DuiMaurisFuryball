namespace Dui_Mauris_Furyball
{
    public static class Felix
    {
        public static void Add()
        {
            //changes vandander's sprites hopefully
            ExtraCCSprites_ArraySO clockHandsMovin = ScriptableObject.CreateInstance<ExtraCCSprites_ArraySO>();
            clockHandsMovin._useDefault = ExtraSpriteType.None;
            clockHandsMovin._doesLoop = true;
            clockHandsMovin._useSpecial = (ExtraSpriteType)104509;
            clockHandsMovin._frontSprite = new Sprite[]
            {
                ResourceLoader.LoadSprite("FelixFront0015", 1, null),
                ResourceLoader.LoadSprite("FelixFront0030", 1, null),
                ResourceLoader.LoadSprite("FelixFront0045", 1, null),
                ResourceLoader.LoadSprite("FelixFront0100", 1, null),
                ResourceLoader.LoadSprite("FelixFront0115", 1, null),
                ResourceLoader.LoadSprite("FelixFront0130", 1, null),
                ResourceLoader.LoadSprite("FelixFront0145", 1, null),
                ResourceLoader.LoadSprite("FelixFront0200", 1, null),
                ResourceLoader.LoadSprite("FelixFront0215", 1, null),
                ResourceLoader.LoadSprite("FelixFront0230", 1, null),
                ResourceLoader.LoadSprite("FelixFront0245", 1, null),
                ResourceLoader.LoadSprite("FelixFront0300", 1, null),
                ResourceLoader.LoadSprite("FelixFront0315", 1, null),
                ResourceLoader.LoadSprite("FelixFront0330", 1, null),
                ResourceLoader.LoadSprite("FelixFront0345", 1, null),
                ResourceLoader.LoadSprite("FelixFront0400", 1, null),
                ResourceLoader.LoadSprite("FelixFront0415", 1, null),
                ResourceLoader.LoadSprite("FelixFront0430", 1, null),
                ResourceLoader.LoadSprite("FelixFront0445", 1, null),
                ResourceLoader.LoadSprite("FelixFront0500", 1, null),
                ResourceLoader.LoadSprite("FelixFront0515", 1, null),
                ResourceLoader.LoadSprite("FelixFront0530", 1, null),
                ResourceLoader.LoadSprite("FelixFront0545", 1, null),
                ResourceLoader.LoadSprite("FelixFront0600", 1, null),
                ResourceLoader.LoadSprite("FelixFront0615", 1, null),
                ResourceLoader.LoadSprite("FelixFront0630", 1, null),
                ResourceLoader.LoadSprite("FelixFront0645", 1, null),
                ResourceLoader.LoadSprite("FelixFront0700", 1, null),
                ResourceLoader.LoadSprite("FelixFront0715", 1, null),
                ResourceLoader.LoadSprite("FelixFront0730", 1, null),
                ResourceLoader.LoadSprite("FelixFront0745", 1, null),
                ResourceLoader.LoadSprite("FelixFront0800", 1, null),
                ResourceLoader.LoadSprite("FelixFront0815", 1, null),
                ResourceLoader.LoadSprite("FelixFront0830", 1, null),
                ResourceLoader.LoadSprite("FelixFront0845", 1, null),
                ResourceLoader.LoadSprite("FelixFront0900", 1, null),
                ResourceLoader.LoadSprite("FelixFront0915", 1, null),
                ResourceLoader.LoadSprite("FelixFront0930", 1, null),
                ResourceLoader.LoadSprite("FelixFront0945", 1, null),
                ResourceLoader.LoadSprite("FelixFront1000", 1, null),
                ResourceLoader.LoadSprite("FelixFront1015", 1, null),
                ResourceLoader.LoadSprite("FelixFront1030", 1, null),
                ResourceLoader.LoadSprite("FelixFront1045", 1, null),
                ResourceLoader.LoadSprite("FelixFront1100", 1, null),
                ResourceLoader.LoadSprite("FelixFront1115", 1, null),
                ResourceLoader.LoadSprite("FelixFront1130", 1, null),
                ResourceLoader.LoadSprite("FelixFront1145", 1, null),
                ResourceLoader.LoadSprite("FelixFront0000", 1, null),
            };
            clockHandsMovin._backSprite = new Sprite[]
            {
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
                ResourceLoader.LoadSprite("FelixBack", 1, null),
            };
            var moveTheClockForward = ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>();
            moveTheClockForward._spriteType = (ExtraSpriteType)104509;


            //chaos random health color effect
            var chaosHealth = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
            chaosHealth._healthColors = new ManaColorSO[] { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple };


            var Chaos = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            Chaos._passiveName = "Chaos";
            Chaos.type = (PassiveAbilityTypes)2789774;
            Chaos.passiveIcon = ResourceLoader.LoadSprite("chaos");
            Chaos._enemyDescription = "This enemy's health is randomized at the start of combat.";
            Chaos._characterDescription = "This party member's health and costs are randomized at the start of combat.";
            Chaos.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new Effect(chaosHealth, 1, null, Slots.Self),
                    new Effect(ScriptableObject.CreateInstance<CostRerollEffect>(), 1, null, Slots.Self),
                });
            Chaos._triggerOn = new TriggerCalls[0];

            var slapy = ScriptableObject.CreateInstance<RandomDamageBetweenPreviousAndEntryEffect>();
            slapy._deathType = DeathType.Slap;

            Ability slaph = new Ability();
            slaph.name = "Slap";
            slaph.description = "Deal 1-2 damage to the Opposing enemy.";
            slaph.cost = new ManaColorSO[] { Pigments.Green };
            slaph.sprite = ResourceLoader.LoadSprite("slaph");
            slaph.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self),
                    new(slapy, 2, IntentType.Damage_1_2, Slots.Front),
                    new(moveTheClockForward, 1, null, Slots.Self),
                };
            slaph.animationTarget = Slots.Front;
            slaph.visuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;


            //Vandander Basics
            Character felix = new Character();
            
            felix.name = "Felix";
            felix.healthColor = Pigments.Green;
            felix.entityID = (EntityIDs)5455921;
            felix.frontSprite = ResourceLoader.LoadSprite("FelixFront0000");
            felix.backSprite = ResourceLoader.LoadSprite("FelixBack");
            felix.overworldSprite = ResourceLoader.LoadSprite("FelixOverworld", 32, new Vector2(0.5f, 0.02f));
            felix.lockedSprite = ResourceLoader.LoadSprite("VandanderLocked");
            felix.unlockedSprite = ResourceLoader.LoadSprite("FelixMenu");
            felix.extraSprites = clockHandsMovin;
            felix.menuChar = true;
            felix.appearsInShops = true;
            felix.baseAbility = slaph;
            felix.hurtSound = LoadedAssetsHandler.GetCharcater("Doll_CH").deathSound;
            felix.deathSound = LoadedAssetsHandler.GetCharcater("Doll_CH").deathSound;
            felix.dialogueSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").deathSound;
            felix.isSupport = true;
            felix.passives = new BasePassiveAbilitySO[]
            {
                Chaos,
                Passives.Delicate
            };

            //stored values (wow four of them!!) detours
            IDetour ButtMax = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(ButterfliesMaximumStoredValue).GetMethod("AddStoredValueName", ~BindingFlags.Default));
            IDetour ButtMin = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(ButterfliesMinimumStoredValue).GetMethod("AddStoredValueName", ~BindingFlags.Default));
            IDetour PendMax = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(PendulumMaximumStoredValue).GetMethod("AddStoredValueName", ~BindingFlags.Default));
            IDetour PendMin = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(PendulumMinimumStoredValue).GetMethod("AddStoredValueName", ~BindingFlags.Default));

            //stored values up and down
            CasterStoredValueChangeEffect butterflyMaxUp = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            butterflyMaxUp._randomBetweenPrevious = true;
            butterflyMaxUp._increase = true;
            butterflyMaxUp._valueName = (UnitStoredValueNames)222761;
            CasterStoredValueChangeEffect butterflyMinDown = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            butterflyMinDown._randomBetweenPrevious = true;
            butterflyMinDown._increase = true;
            butterflyMinDown._valueName = (UnitStoredValueNames)222762;
            CasterStoredValueChangeEffect pendulumMaxUp = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            pendulumMaxUp._randomBetweenPrevious = true;
            pendulumMaxUp._increase = true;
            pendulumMaxUp._valueName = (UnitStoredValueNames)222763;
            CasterStoredValueChangeEffect pendulumMinDown = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            pendulumMinDown._randomBetweenPrevious = true;
            pendulumMinDown._increase = true;
            pendulumMinDown._valueName = (UnitStoredValueNames)222764;


            //butterfly healing
            var butterflyHeal = ScriptableObject.CreateInstance<ButterflyHeal>();
            butterflyHeal._valueNameTop = (UnitStoredValueNames)222761;
            butterflyHeal._valueNameBottom = (UnitStoredValueNames)222762;


            //pendulum damage
            var pendulumDamage = ScriptableObject.CreateInstance<PendulumDamage>();
            pendulumDamage._valueNameTop = (UnitStoredValueNames)222763;
            pendulumDamage._valueNameBottom = (UnitStoredValueNames)222764;


            //butterfly
            var butterfly0 = new AbilityAdvanced();
            butterfly0.name = "Tummy Butterfly";
            butterfly0.description = "Heal this party member and Right ally 3-4 health. Decrease this ability's minimum healing by 1-2.";
            butterfly0.cost = new ManaColorSO[] { Pigments.Green, Pigments.Green };
            butterfly0.sprite = ResourceLoader.LoadSprite("butterflies");
            butterfly0.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 3, null, Slots.Self),
                    new(butterflyHeal, 4, IntentType.Heal_1_4, Slots.SlotTarget(new int[] { 0, 1 }, true)),
                    new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self),
                    new(butterflyMinDown, 2, IntentType.Misc_State_Sit, Slots.Self),
                    new(moveTheClockForward, 1, null, Slots.Self),
                };
            butterfly0.animationTarget = Slots.Self;
            butterfly0.visuals = LoadedAssetsHandler.GetCharacterAbility("WholeAgain_1_A").visuals;
            var butterfly0_a = butterfly0.CharacterAdvancedAbility<MultiSpecialStoredValueAbilitySO>(out var butterfly0_SO);
            butterfly0_SO.extraStoredValues = new UnitStoredValueNames[]
            {
                (UnitStoredValueNames)222761,
                (UnitStoredValueNames)222762,
            };

            var butterfly1 = butterfly0.DuplicateAdvanced();
            butterfly1.name = "Incense Butterfly";
            butterfly1.description = "Heal this party member and Right ally 5-6 health. Decrease this ability's minimum healing by 1-2.";
            butterfly1.effects[0]._entryVariable = 5;
            butterfly1.effects[1]._entryVariable = 6;
            butterfly1.effects[1]._intent = IntentType.Heal_5_10;
            var butterfly1_a = butterfly1.CharacterAdvancedAbility<MultiSpecialStoredValueAbilitySO>(out var butterfly1_SO);
            butterfly1_SO.extraStoredValues = new UnitStoredValueNames[]
            {
                (UnitStoredValueNames)222761,
                (UnitStoredValueNames)222762,
            };

            var butterfly2 = butterfly1.DuplicateAdvanced();
            butterfly2.name = "Monarch Butterfly";
            butterfly2.description = "Heal this party member and Right ally 7-8 health. Decrease this ability's minimum healing by 1-2.";
            butterfly2.effects[0]._entryVariable = 7;
            butterfly2.effects[1]._entryVariable = 8;
            var butterfly2_a = butterfly2.CharacterAdvancedAbility<MultiSpecialStoredValueAbilitySO>(out var butterfly2_SO);
            butterfly2_SO.extraStoredValues = new UnitStoredValueNames[]
            {
                (UnitStoredValueNames)222761,
                (UnitStoredValueNames)222762,
            };

            var butterfly3 = butterfly2.DuplicateAdvanced();
            butterfly3.name = "The Butterfly Effect";
            butterfly3.description = "Heal this party member and Right ally 9-10 health. Decrease this ability's minimum healing by 1-2.";
            butterfly3.effects[0]._entryVariable = 9;
            butterfly3.effects[1]._entryVariable = 10;
            var butterfly3_a = butterfly3.CharacterAdvancedAbility<MultiSpecialStoredValueAbilitySO>(out var butterfly3_SO);
            butterfly3_SO.extraStoredValues = new UnitStoredValueNames[]
            {
                (UnitStoredValueNames)222761,
                (UnitStoredValueNames)222762,
            };


            //determinism
            var determinism0 = new AbilityAdvanced();
            determinism0.name = "Fast Determinism";
            determinism0.description = "Reroll this party member's costs. Increase butterfly max healing by 0-2. Increase pendulum max damage by 0-2.";
            determinism0.cost = new ManaColorSO[] { Pigments.Green };
            determinism0.sprite = ResourceLoader.LoadSprite("determinism");
            determinism0.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<CostRerollEffect>(), 1, IntentType.Mana_Randomize, Slots.Self),
                    new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, null, Slots.Self),
                    new(butterflyMaxUp, 2, IntentType.Misc_State_Stand, Slots.Self),
                    new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, null, Slots.Self),
                    new(pendulumMaxUp, 2, IntentType.Misc_State_Stand, Slots.Self),
                    new(moveTheClockForward, 1, null, Slots.Self),
                };
            determinism0.animationTarget = Slots.Self;
            determinism0.visuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;
            var determinism0_a = determinism0.CharacterAdvancedAbility<MultiSpecialStoredValueAbilitySO>(out var determinism0_SO);
            determinism0_SO.extraStoredValues = new UnitStoredValueNames[]
            {
                (UnitStoredValueNames)222761,
                (UnitStoredValueNames)222762,
                (UnitStoredValueNames)222763,
                (UnitStoredValueNames)222764,
            };

            var determinism1 = determinism0.DuplicateAdvanced();
            determinism1.name = "Broken Determinism";
            determinism1.description = "Reroll this party member's costs. Increase butterfly max healing by 0-3. Increase pendulum max damage by 0-3.";
            determinism1.effects[2]._entryVariable = 3;
            determinism1.effects[4]._entryVariable = 3;
            var determinism1_a = determinism1.CharacterAdvancedAbility<MultiSpecialStoredValueAbilitySO>(out var determinism1_SO);
            determinism1_SO.extraStoredValues = new UnitStoredValueNames[]
            {
                (UnitStoredValueNames)222761,
                (UnitStoredValueNames)222762,
                (UnitStoredValueNames)222763,
                (UnitStoredValueNames)222764,
            };

            var determinism2 = determinism1.DuplicateAdvanced();
            determinism2.name = "Slow Determinism";
            determinism2.description = "Reroll this party member's costs. Increase butterfly max healing by 0-4. Increase pendulum max damage by 0-4.";
            determinism2.effects[2]._entryVariable = 4;
            determinism2.effects[4]._entryVariable = 4;
            var determinism2_a = determinism2.CharacterAdvancedAbility<MultiSpecialStoredValueAbilitySO>(out var determinism2_SO);
            determinism2_SO.extraStoredValues = new UnitStoredValueNames[]
            {
                (UnitStoredValueNames)222761,
                (UnitStoredValueNames)222762,
                (UnitStoredValueNames)222763,
                (UnitStoredValueNames)222764,
            };

            var determinism3 = determinism2.DuplicateAdvanced();
            determinism3.name = "Stopped Determinism";
            determinism3.description = "Reroll this party member's costs. Increase butterfly max healing by 1-4. Increase pendulum max damage by 1-4.";
            determinism3.effects[1]._entryVariable = 1;
            determinism3.effects[3]._entryVariable = 1;
            var determinism3_a = determinism3.CharacterAdvancedAbility<MultiSpecialStoredValueAbilitySO>(out var determinism3_SO);
            determinism3_SO.extraStoredValues = new UnitStoredValueNames[]
            {
                (UnitStoredValueNames)222761,
                (UnitStoredValueNames)222762,
                (UnitStoredValueNames)222763,
                (UnitStoredValueNames)222764,
            };


            //pendulum
            var pendulum0 = new AbilityAdvanced();
            pendulum0.name = "Grandfather Pendulum";
            pendulum0.description = "Deal 6-7 damage to the Opposing enemy. Decrease this ability's minimum damage by 2-3.";
            pendulum0.cost = new ManaColorSO[] { Pigments.Green, Pigments.Green, Pigments.Green };
            pendulum0.sprite = ResourceLoader.LoadSprite("pendulum");
            pendulum0.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 6, null, Slots.Self),
                    new(pendulumDamage, 7, IntentType.Damage_3_6, Slots.Front),
                    new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 2, null, Slots.Self),
                    new(pendulumMinDown, 3, IntentType.Misc_State_Sit, Slots.Self),
                    new(moveTheClockForward, 1, null, Slots.Self),
                };
            pendulum0.animationTarget = Slots.Front;
            pendulum0.visuals = LoadedAssetsHandler.GetEnemyAbility("Extrusion_A").visuals;
            var pendulum0_a = pendulum0.CharacterAdvancedAbility<MultiSpecialStoredValueAbilitySO>(out var pendulum0_SO);
            pendulum0_SO.extraStoredValues = new UnitStoredValueNames[]
            {
                (UnitStoredValueNames)222763,
                (UnitStoredValueNames)222764,
            };

            var pendulum1 = pendulum0.DuplicateAdvanced();
            pendulum1.name = "Foucalt Pendulum";
            pendulum1.description = "Deal 8-9 damage to the Opposing enemy. Decrease this ability's minimum damage by 2-3.";
            pendulum1.effects[0]._entryVariable = 8;
            pendulum1.effects[1]._entryVariable = 9;
            pendulum1.effects[1]._intent = IntentType.Damage_7_10;
            var pendulum1_a = pendulum1.CharacterAdvancedAbility<MultiSpecialStoredValueAbilitySO>(out var pendulum1_SO);
            pendulum1_SO.extraStoredValues = new UnitStoredValueNames[]
            {
                (UnitStoredValueNames)222763,
                (UnitStoredValueNames)222764,
            };

            var pendulum2 = pendulum1.DuplicateAdvanced();
            pendulum2.name = "Damped Pendulum";
            pendulum2.description = "Deal 11-12 damage to the Opposing enemy. Decrease this ability's minimum damage by 2-3.";
            pendulum2.effects[0]._entryVariable = 11;
            pendulum2.effects[1]._entryVariable = 12;
            pendulum2.effects[1]._intent = IntentType.Damage_11_15;
            var pendulum2_a = pendulum2.CharacterAdvancedAbility<MultiSpecialStoredValueAbilitySO>(out var pendulum2_SO);
            pendulum2_SO.extraStoredValues = new UnitStoredValueNames[]
            {
                (UnitStoredValueNames)222763,
                (UnitStoredValueNames)222764,
            };

            var pendulum3 = pendulum2.DuplicateAdvanced();
            pendulum3.name = "Double Pendulum";
            pendulum3.description = "Deal 13-14 damage to the Opposing enemy. Decrease this ability's minimum damage by 2-3.";
            pendulum3.effects[0]._entryVariable = 13;
            pendulum3.effects[1]._entryVariable = 14;
            var pendulum3_a = pendulum3.CharacterAdvancedAbility<MultiSpecialStoredValueAbilitySO>(out var pendulum3_SO);
            pendulum3_SO.extraStoredValues = new UnitStoredValueNames[]
            {
                (UnitStoredValueNames)222763,
                (UnitStoredValueNames)222764,
            };

            
            felix.AddLevelWithCustomAbilities(12, [butterfly0_a, determinism0_a, pendulum0_a], 0);
            felix.AddLevelWithCustomAbilities(15, [butterfly1_a, determinism1_a, pendulum1_a], 1);
            felix.AddLevelWithCustomAbilities(17, [butterfly2_a, determinism2_a, pendulum2_a], 2);
            felix.AddLevelWithCustomAbilities(19, [butterfly3_a, determinism3_a, pendulum3_a], 3);
            felix.AddCharacter();

            //
            //
            //

            EffectItem bowlingBall = new EffectItem();
            bowlingBall.name = "Bowling Ball";
            bowlingBall.flavorText = "\"Knock 'em down!\"";
            bowlingBall.description = "Reroll this party member's worst pigment cost on each of their abilities to a better one.";
            bowlingBall.sprite = ResourceLoader.LoadSprite("BowlingBall", 1, null);
            bowlingBall.trigger = TriggerCalls.OnCombatStart;
            bowlingBall.unlockableID = (UnlockableID)456468;
            bowlingBall.namePopup = true;
            bowlingBall.itemPools = BrutalAPI.ItemPools.Shop;
            bowlingBall.shopPrice = 3;
            bowlingBall.immediate = false;
            bowlingBall.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<BowlingReroll>(), 1, null, Slots.Self),
            };

            //
            //
            //

            IDetour BellMin = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(BellMinimumStoredValue).GetMethod("AddStoredValueName", ~BindingFlags.Default));
            IDetour BellMax = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(BellMaximumStoredValue).GetMethod("AddStoredValueName", ~BindingFlags.Default));

            //bell values
            var bellUp = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            bellUp._increase = true;
            bellUp._valueName = (UnitStoredValueNames)555763;
            var bellDown = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            bellDown._increase = true;
            bellDown._valueName = (UnitStoredValueNames)555762;

            //bell damage
            var bellDamage = ScriptableObject.CreateInstance<PendulumDamage>();
            bellDamage._valueNameTop = (UnitStoredValueNames)555763;
            bellDamage._valueNameBottom = (UnitStoredValueNames)555762;

            //ability
            var ring = new AbilityAdvanced();
            ring.name = "Dead Ring";
            ring.description = "Deal 6-7 damage to the Opposing enemy. Decrease the minimum damage of this ability by 1. Increase the maximum damage of this ability by 2.";
            ring.cost = new ManaColorSO[] { Pigments.SplitPigment(Pigments.Red, Pigments.Yellow), Pigments.SplitPigment(Pigments.Red, Pigments.Blue) };
            ring.sprite = ResourceLoader.LoadSprite("BellAttack");
            ring.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 6, null, Slots.Self),
                    new(bellDamage, 7, IntentType.Damage_7_10, Slots.Front),
                    new(bellUp, 2, IntentType.Misc_State_Stand, Slots.Self),
                    new(bellDown, 1, IntentType.Misc_State_Sit, Slots.Self),
                };
            ring.animationTarget = Slots.Front;
            ring.visuals = LoadedAssetsHandler.GetEnemyAbility("RingABell_A").visuals;
            var ring_a = ring.CharacterAdvancedAbility<MultiSpecialStoredValueAbilitySO>(out var ring_SO);
            ring_SO.extraStoredValues = new UnitStoredValueNames[]
            {
                (UnitStoredValueNames)222763,
                (UnitStoredValueNames)222764,
            };


            ExtraAbility_Wearable_SMS theyAreBells = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            theyAreBells._extraAbility = ring.CharacterAbility();

            EffectItem tollBell = new EffectItem();
            tollBell.name = "The Bell Tolls";
            tollBell.flavorText = "\"Ring ring! It's for you!\"";
            tollBell.description = "Adds the ability \"Dead Ring\" to this party member, a relatively strong attack that becomes more inconsistent the more it is used.";
            tollBell.sprite = ResourceLoader.LoadSprite("ForWhomItTolls", 1, null);
            tollBell.trigger = TriggerCalls.OnCombatStart;
            tollBell.unlockableID = (UnlockableID)456469;
            tollBell.namePopup = true;
            tollBell.itemPools = BrutalAPI.ItemPools.Treasure;
            tollBell.immediate = true;
            tollBell.equippedModifiers = new WearableStaticModifierSetterSO[]
            {
                theyAreBells
            };
            Connection_PerformEffectPassiveAbility connection_PerformEffectPassiveAbility = LoadedAssetsHandler.GetCharcater("Doll_CH").passiveAbilities[0] as Connection_PerformEffectPassiveAbility;
            CasterAddRandomExtraAbilityEffect casterAddRandomExtraAbilityEffect = connection_PerformEffectPassiveAbility.connectionEffects[1].effect as CasterAddRandomExtraAbilityEffect;
            casterAddRandomExtraAbilityEffect._extraData = new List<ExtraAbility_Wearable_SMS>(casterAddRandomExtraAbilityEffect._extraData)
            {
                theyAreBells
            }.ToArray();

            FoolItemPairs FelixPair = new FoolItemPairs(felix, tollBell, bowlingBall);
            FelixPair.Add();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Felix");

        }
    }
}
