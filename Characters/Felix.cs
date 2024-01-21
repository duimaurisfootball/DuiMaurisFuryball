using Dui_Mauris_Furyball.CustomEffects;
using Dui_Mauris_Furyball.ExtraStoredValues;

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


            PerformEffectPassiveAbility Chaos = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            Chaos._passiveName = "Chaos";
            Chaos.type = (PassiveAbilityTypes)2786774;
            Chaos.passiveIcon = ResourceLoader.LoadSprite("chaos");
            Chaos._enemyDescription = "This enemy's stats are based around the number of coins at the beginning of combat.";
            Chaos._characterDescription = "This party member's health and costs are randomized at the start of combat.";
            Chaos.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new Effect(chaosHealth, 1, null, Slots.Self),
                    new Effect(ScriptableObject.CreateInstance<CostRerollEffect>(), 1, null, Slots.Self),
                });
            Chaos._triggerOn = new TriggerCalls[]
                {
                TriggerCalls.OnCombatStart
                };

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
            Debug.Log("loading");
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


            //determinism
            Ability determinism0 = new Ability();
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

            Ability determinism1 = determinism0.Duplicate();
            determinism1.name = "Broken Determinism";
            determinism1.description = "Reroll this party member's costs. Increase butterfly max healing by 0-3. Increase pendulum max damage by 0-3.";
            determinism1.effects[2]._entryVariable = 3;
            determinism1.effects[4]._entryVariable = 3;

            Ability determinism2 = determinism1.Duplicate();
            determinism2.name = "Slow Determinism";
            determinism2.description = "Reroll this party member's costs. Increase butterfly max healing by 0-4. Increase pendulum max damage by 0-4.";
            determinism2.effects[2]._entryVariable = 4;
            determinism2.effects[4]._entryVariable = 4;

            Ability determinism3 = determinism2.Duplicate();
            determinism3.name = "Stopped Determinism";
            determinism3.description = "Reroll this party member's costs. Increase butterfly max healing by 1-4. Increase pendulum max damage by 1-4.";
            determinism3.effects[1]._entryVariable = 1;
            determinism3.effects[3]._entryVariable = 1;


            //butterfly
            Ability butterfly0 = new Ability();
            butterfly0.name = "Tummy Butterfly";
            butterfly0.description = "Heal this party member and Right ally 2-3 health. Decrease this ability's minimum healing by 1-2.";
            butterfly0.cost = new ManaColorSO[] { Pigments.Green, Pigments.Green };
            butterfly0.sprite = ResourceLoader.LoadSprite("butterflies");
            butterfly0.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 2, null, Slots.Self),
                    new(butterflyHeal, 3, IntentType.Heal_1_4, Slots.SlotTarget(new int[] { 0, 1 }, true)),
                    new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self),
                    new(butterflyMinDown, 2, IntentType.Misc_State_Sit, Slots.Self),
                    new(moveTheClockForward, 1, null, Slots.Self),
                };
            butterfly0.animationTarget = Slots.Self;
            butterfly0.visuals = LoadedAssetsHandler.GetCharacterAbility("WholeAgain_1_A").visuals;

            Ability butterfly1 = butterfly0.Duplicate();
            butterfly1.name = "Incense Butterfly";
            butterfly1.description = "Heal this party member and Right ally 4-5 health. Decrease this ability's minimum healing by 1-2.";
            butterfly1.effects[0]._entryVariable = 4;
            butterfly1.effects[1]._entryVariable = 5;
            butterfly1.effects[1]._intent = IntentType.Heal_5_10;

            Ability butterfly2 = butterfly1.Duplicate();
            butterfly2.name = "Monarch Butterfly";
            butterfly2.description = "Heal this party member and Right ally 6-7 health. Decrease this ability's minimum healing by 1-2.";
            butterfly2.effects[0]._entryVariable = 6;
            butterfly2.effects[1]._entryVariable = 7;

            Ability butterfly3 = butterfly2.Duplicate();
            butterfly3.name = "The Butterfly Effect";
            butterfly3.description = "Heal this party member and Right ally 8-9 health. Decrease this ability's minimum healing by 1-2.";
            butterfly3.effects[0]._entryVariable = 8;
            butterfly3.effects[1]._entryVariable = 9;


            //pendulum
            Ability pendulum0 = new Ability();
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

            Ability pendulum1 = pendulum0.Duplicate();
            pendulum1.name = "Foucalt Pendulum";
            pendulum1.description = "Deal 8-9 damage to the Opposing enemy. Decrease this ability's minimum damage by 2-3.";
            pendulum1.effects[0]._entryVariable = 8;
            pendulum1.effects[1]._entryVariable = 9;
            pendulum1.effects[1]._intent = IntentType.Damage_7_10;

            Ability pendulum2 = pendulum1.Duplicate();
            pendulum2.name = "Damped Pendulum";
            pendulum2.description = "Deal 11-12 damage to the Opposing enemy. Decrease this ability's minimum damage by 2-3.";
            pendulum2.effects[0]._entryVariable = 11;
            pendulum2.effects[1]._entryVariable = 12;
            pendulum2.effects[1]._intent = IntentType.Damage_11_15;

            Ability pendulum3 = pendulum2.Duplicate();
            pendulum3.name = "Double Pendulum";
            pendulum3.description = "Deal 13-14 damage to the Opposing enemy. Decrease this ability's minimum damage by 2-3.";
            pendulum3.effects[0]._entryVariable = 13;
            pendulum3.effects[1]._entryVariable = 14;

            Debug.Log("loading");
            felix.AddLevel(12, new Ability[3] { butterfly0, determinism0, pendulum0 }, 0);
            felix.AddLevel(15, new Ability[3] { butterfly1, determinism1, pendulum1 }, 1);
            felix.AddLevel(17, new Ability[3] { butterfly2, determinism2, pendulum2 }, 2);
            felix.AddLevel(19, new Ability[3] { butterfly3, determinism3, pendulum3 }, 3);
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
            Ability ring = new Ability();
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
            tollBell.AddItem();

            FoolItemPairs FelixPair = new FoolItemPairs(felix, tollBell, bowlingBall);
            FelixPair.Add();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Felix");

        }
    }
}
