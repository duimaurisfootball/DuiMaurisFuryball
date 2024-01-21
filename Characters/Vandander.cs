using Dui_Mauris_Furyball.CustomEffects;

namespace Dui_Mauris_Furyball
{
    public static class Vandander
    {
        public static void Add()
        {
            //changes vandander's sprites hopefully
            ExtraCCSprites_ArraySO extraCCSprites_ArraySO = ScriptableObject.CreateInstance<ExtraCCSprites_ArraySO>();
            extraCCSprites_ArraySO._useDefault = ExtraSpriteType.None;
            extraCCSprites_ArraySO._doesLoop = true;
            extraCCSprites_ArraySO._useSpecial = (ExtraSpriteType)74162;
            extraCCSprites_ArraySO._frontSprite = new Sprite[]
            {
                ResourceLoader.LoadSprite("VandanderFrontChunk", 1, null),
                ResourceLoader.LoadSprite("VandanderFrontFew", 1, null),
                ResourceLoader.LoadSprite("VandanderFrontVoid", 1, null),
                ResourceLoader.LoadSprite("VandanderFrontBasic", 1, null)
            };
            extraCCSprites_ArraySO._backSprite = new Sprite[]
            {
                ResourceLoader.LoadSprite("VandanderBackChunk", 1, null),
                ResourceLoader.LoadSprite("VandanderBackFew", 1, null),
                ResourceLoader.LoadSprite("VandanderBackVoid", 1, null),
                ResourceLoader.LoadSprite("VandanderBackBasic", 1, null)
            };
            SetCasterExtraSpritesEffect setCasterExtraSpritesEffect = ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>();
            setCasterExtraSpritesEffect._spriteType = (ExtraSpriteType)74162;


            //Vandander Basics
            Character vandander = new Character();
            Debug.Log("loading");
            vandander.name = "Vandander";
            vandander.healthColor = Pigments.Purple;
            vandander.entityID = (EntityIDs)22123124;
            vandander.frontSprite = ResourceLoader.LoadSprite("VandanderFrontBasic");
            vandander.backSprite = ResourceLoader.LoadSprite("VandanderBackBasic");
            vandander.overworldSprite = ResourceLoader.LoadSprite("VandanderOverworld", 32, new Vector2(0.5f, 0.02f));
            vandander.lockedSprite = ResourceLoader.LoadSprite("VandanderLocked");
            vandander.unlockedSprite = ResourceLoader.LoadSprite("VandanderMenu");
            vandander.extraSprites = extraCCSprites_ArraySO;
            vandander.menuChar = true;
            vandander.appearsInShops = true;
            vandander.hurtSound = LoadedAssetsHandler.GetEnemy("TaMaGoa_EN").deathSound;
            vandander.deathSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").deathSound;
            vandander.dialogueSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").deathSound;
            vandander.isSupport = true;
            vandander.passives = new BasePassiveAbilitySO[]
            {
                Passives.Delicate,
                Passives.Enfeebled
            };


            ApplyFrailEffect FrailHalf = ScriptableObject.CreateInstance<ApplyFrailEffect>();

            //ventilate
            Ability vandanderize0 = new Ability();
            vandanderize0.name = "Viewing Ventilate";
            vandanderize0.description = "Heal the opposing enemy 1 health, and inflict 1 frail. Heal self and left ally 1 health and inflict 2 frail.";
            vandanderize0.cost = new ManaColorSO[3] { Pigments.Blue, Pigments.Yellow, Pigments.Red };
            vandanderize0.sprite = ResourceLoader.LoadSprite("vandanderize");
            vandanderize0.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<HealEffect>(), 1, IntentType.Heal_1_4, Slots.Front),
                    new(ScriptableObject.CreateInstance<HealEffect>(), 1, IntentType.Heal_1_4, Slots.SlotTarget(new int[] { -1, 0 }, true)),
                    new(FrailHalf, 1, IntentType.Status_Frail, Slots.Front),
                    new(FrailHalf, 2, IntentType.Status_Frail, Slots.SlotTarget(new int[] { -1, 0 }, true)),
                    new(setCasterExtraSpritesEffect, 1, null, Slots.Self),
                    new(setCasterExtraSpritesEffect, 1, null, Slots.Self, Conditions.Chance(50)),
                    new(setCasterExtraSpritesEffect, 1, null, Slots.Self, Conditions.Chance(50)),
                };
            vandanderize0.animationTarget = Slots.Self;
            vandanderize0.visuals = LoadedAssetsHandler.GetCharacterAbility("Entwined_1_A").visuals;

            Ability vandanderize1 = vandanderize0.Duplicate();
            vandanderize1.name = "Vigilant Ventilate";
            vandanderize1.description = "Heal the opposing enemy 2 health, and inflict 2 frail. Heal self and left ally 2 health and inflict 2 frail.";
            vandanderize1.effects[0]._entryVariable = 2;
            vandanderize1.effects[1]._entryVariable = 2;
            vandanderize1.effects[2]._entryVariable = 2;

            Ability vandanderize2 = vandanderize1.Duplicate();
            vandanderize2.name = "Virulent Ventilate";
            vandanderize2.description = "Heal the opposing enemy 3 health, and inflict 3 frail. Heal self and left ally 3 health and inflict 2 frail.";
            vandanderize2.effects[0]._entryVariable = 3;
            vandanderize2.effects[1]._entryVariable = 3;
            vandanderize2.effects[2]._entryVariable = 3;

            Ability vandanderize3 = vandanderize2.Duplicate();
            vandanderize3.name = "Vivid Ventilate";
            vandanderize3.description = "Heal the opposing enemy 4 health, and inflict 4 frail. Heal self and left ally 4 health and inflict 2 frail.";
            vandanderize3.effects[0]._entryVariable = 4;
            vandanderize3.effects[1]._entryVariable = 4;
            vandanderize3.effects[2]._entryVariable = 4;


            //vow
            ApplyLinkedWithPercentageEffect LinkingForever0 = ScriptableObject.CreateInstance<ApplyLinkedWithPercentageEffect>();
            LinkingForever0._percentageToApply = 40;
            ApplyLinkedWithPercentageEffect LinkingForever1 = ScriptableObject.CreateInstance<ApplyLinkedWithPercentageEffect>();
            LinkingForever1._percentageToApply = 45;
            ApplyLinkedWithPercentageEffect LinkingForever2 = ScriptableObject.CreateInstance<ApplyLinkedWithPercentageEffect>();
            LinkingForever2._percentageToApply = 50;
            ApplyLinkedWithPercentageEffect LinkingForever3 = ScriptableObject.CreateInstance<ApplyLinkedWithPercentageEffect>();
            LinkingForever3._percentageToApply = 55;
            ApplyScarsEffect ScarsForever = ScriptableObject.CreateInstance<ApplyScarsEffect>();


            Ability vow0 = new Ability();
            vow0.name = "Vaguely Vow";
            vow0.description = "Rolls a 40% chance to link the opposing enemy, self, and left ally, twice. Inflict 2 scars to the opposing enemy.";
            vow0.cost = new ManaColorSO[1] { Pigments.SplitPigment(Pigments.Red, Pigments.Purple) };
            vow0.sprite = ResourceLoader.LoadSprite("vandandrate");
            vow0.effects = new Effect[]
                {
                    new(LinkingForever0, 1, IntentType.Status_Linked, Slots.Front),
                    new(LinkingForever0, 1, IntentType.Status_Linked, Slots.SlotTarget(new int[] { -1, 0 }, true)),
                    new(LinkingForever0, 1, IntentType.Status_Linked, Slots.Front),
                    new(LinkingForever0, 1, IntentType.Status_Linked, Slots.SlotTarget(new int[] { -1, 0 }, true)),
                    new(ScarsForever, 2, IntentType.Status_Scars, Slots.Front),
                    new(setCasterExtraSpritesEffect, 1, null, Slots.Self),
                    new(setCasterExtraSpritesEffect, 1, null, Slots.Self, Conditions.Chance(50)),
                    new(setCasterExtraSpritesEffect, 1, null, Slots.Self, Conditions.Chance(50)),
                };
            vow0.animationTarget = Slots.Self;
            vow0.visuals = LoadedAssetsHandler.GetEnemyAbility("DrippingsOfTheGarden_A").visuals;
            Debug.Log("0");
            Ability vow1 = vow0.Duplicate();
            vow1.name = "Vicariously Vow";
            vow1.description = "Rolls a 45% chance to link the opposing enemy, self, and left ally, twice. Inflict 3 scars to the opposing enemy.";
            vow1.effects[0]._effect = LinkingForever1;
            vow1.effects[1]._effect = LinkingForever1;
            vow1.effects[2]._effect = LinkingForever1;
            vow1.effects[3]._effect = LinkingForever1;
            vow1.effects[4]._entryVariable = 3;

            Ability vow2 = vow1.Duplicate();
            vow2.name = "Voraciously Vow";
            vow2.description = "Rolls a 50% chance to link the opposing enemy, self, and left ally, twice. Inflict 4 scars to the opposing enemy.";
            vow2.effects[0]._effect = LinkingForever2;
            vow2.effects[1]._effect = LinkingForever2;
            vow2.effects[2]._effect = LinkingForever2;
            vow2.effects[3]._effect = LinkingForever2;
            vow2.effects[4]._entryVariable = 4;

            Ability vow3 = vow2.Duplicate();
            vow3.name = "Vivisected Vow";
            vow3.description = "Rolls a 55% chance to link the opposing enemy, self, and left ally, twice. Inflict 5 scars to the opposing enemy.";
            vow3.effects[0]._effect = LinkingForever3;
            vow3.effects[1]._effect = LinkingForever3;
            vow3.effects[2]._effect = LinkingForever3;
            vow3.effects[3]._effect = LinkingForever3;
            vow3.effects[4]._entryVariable = 5;


            //vandala effect
            RandomizeHealthEffect Vandala1 = ScriptableObject.CreateInstance<RandomizeHealthEffect>();
            HealEffect Vandala2 = ScriptableObject.CreateInstance<HealEffect>();
            Vandala2.entryAsPercentage = true;

            Ability vandalaEffect0 = new Ability();
            vandalaEffect0.name = "Vandala Effect, Vacantly";
            vandalaEffect0.description = "Randomize this party member's and the left ally's health, then heal by 30%. Attempt to resurrect a party member in the left ally position.";
            vandalaEffect0.cost = new ManaColorSO[] { Pigments.Purple, Pigments.Blue };
            vandalaEffect0.sprite = ResourceLoader.LoadSprite("vandala effect");
            vandalaEffect0.effects = new Effect[]
                {
                    new(Vandala1, 1, IntentType.Heal_1_4, Slots.SlotTarget(new int[] { -1, 0 }, true)),
                    new(Vandala2, 30, IntentType.Heal_1_4, Slots.SlotTarget(new int[] { -1, 0 }, true)),
                    new(ScriptableObject.CreateInstance<ResurrectEffect>(), 1, IntentType.Other_Resurrect, Slots.SlotTarget(new int[] { -1 }, true)),
                    new(setCasterExtraSpritesEffect, 1, null, Slots.Self),
                    new(setCasterExtraSpritesEffect, 1, null, Slots.Self, Conditions.Chance(50)),
                    new(setCasterExtraSpritesEffect, 1, null, Slots.Self, Conditions.Chance(50)),
                };
            vandalaEffect0.animationTarget = Slots.SlotTarget(new int[] { -1, 0 }, true);
            vandalaEffect0.visuals = LoadedAssetsHandler.GetEnemy("Sepulchre_EN").abilities[0].ability.visuals;

            Ability vandalaEffect1 = vandalaEffect0.Duplicate();
            vandalaEffect1.name = "Vandala Effect, Variously";
            vandalaEffect1.description = "Randomize this party member's and the left ally's health, then heal by 40%. Attempt to resurrect a party member in the left ally position.";
            vandalaEffect1.effects[1]._entryVariable = 40;

            Ability vandalaEffect2 = vandalaEffect1.Duplicate();
            vandalaEffect2.name = "Vandala Effect, Virtuously";
            vandalaEffect2.description = "Randomize this party member's and the left ally's health, then heal by 50%. Attempt to resurrect a party member in the left ally position.";
            vandalaEffect2.effects[1]._entryVariable = 50;

            Ability vandalaEffect3 = vandalaEffect2.Duplicate();
            vandalaEffect3.name = "Vandala Effect, Visibly";
            vandalaEffect3.description = "Randomize this party member's and the left ally's health, then heal by 60%. Attempt to resurrect a party member in the left ally position.";
            vandalaEffect3.effects[1]._entryVariable = 60;

            //
            //
            //

            var spawnHoles = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereEffect>();
            spawnHoles._characterCopy = "Holes of Vandander_CH";
            spawnHoles._rank = 0;
            spawnHoles._nameAddition = NameAdditionLocID.NameAdditionNone;
            spawnHoles._permanentSpawn = false;
            spawnHoles._usePreviousAsHealth = false;
            spawnHoles._extraModifiers = new WearableStaticModifierSetterSO[]
            {

            };


            EffectItem symbolOfPeace = new EffectItem();
            symbolOfPeace.name = "Symbol of Peace";
            symbolOfPeace.flavorText = "\"Actually, it's a brutal, painful and archaic device for killing criminals.\"";
            symbolOfPeace.description = "Attempt to summon as much of Vandander as can be managed.";
            symbolOfPeace.sprite = ResourceLoader.LoadSprite("SymbolOfPeace", 1, null);
            symbolOfPeace.trigger = TriggerCalls.OnCombatStart;
            symbolOfPeace.unlockableID = (UnlockableID)2226355;
            symbolOfPeace.namePopup = true;
            symbolOfPeace.itemPools = BrutalAPI.ItemPools.Treasure;
            symbolOfPeace.effects = new Effect[]
            {
                new(spawnHoles, 5, null, Slots.SlotTarget(new int[] { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5}, true))
            };

            //
            //
            //

            var fishMoney = ScriptableObject.CreateInstance<ExtraCurrencyEffect>();
            fishMoney._isMultiplier = true;

            var fishColorsGenerator = ScriptableObject.CreateInstance<ChangePigmentGeneratorPool_Effect>();
            fishColorsGenerator._newPool = new ManaColorSO[] 
            {
                Pigments.Yellow,
                Pigments.Red,
                Pigments.Blue,
                Pigments.Purple,
            };

            var fishColorsSpitter = ScriptableObject.CreateInstance<GenerateRandomManaBetweenEffect>();
            fishColorsSpitter.possibleMana = new ManaColorSO[]
            {
                Pigments.Yellow,
                Pigments.Red,
                Pigments.Blue,
                Pigments.Purple,
            };

            DoubleEffectItem thousandFish = new DoubleEffectItem();
            thousandFish.name = "One Thousand Fish";
            thousandFish.flavorText = "\"A miracle of numbers.\"";
            thousandFish.description = "The yellow pigment generator now generates pigment of random colors instead. Generate 2 pigment of a random color on turn start. 50% chance to gain twice as many coins at the end of combat.";
            thousandFish.sprite = ResourceLoader.LoadSprite("OneThousandFish", 1, null);
            thousandFish.unlockableID = (UnlockableID)2226356;
            thousandFish.namePopup = true;
            thousandFish.itemPools = BrutalAPI.ItemPools.Treasure;
            thousandFish.trigger = TriggerCalls.OnTurnStart;
            thousandFish.firstEffects = new Effect[]
            {
                new(fishColorsSpitter, 2, null, Slots.Self)
            };
            thousandFish.SecondTrigger = new TriggerCalls[]
            {
                TriggerCalls.OnCombatStart,
            };
            thousandFish.secondEffects = new Effect[]
            {
                new(fishColorsGenerator, 1, null, Slots.Self),
                new(fishMoney, 2, null, Slots.Self, Conditions.Chance(50)),
            };


            FoolItemPairs VandanderPair = new FoolItemPairs(vandander, symbolOfPeace, thousandFish);
            VandanderPair.Add();

            Debug.Log("loading");
            vandander.AddLevel(15, new Ability[3] { vow0, vandanderize0, vandalaEffect0 }, 0);
            vandander.AddLevel(19, new Ability[3] { vow1, vandanderize1, vandalaEffect1 }, 1);
            vandander.AddLevel(24, new Ability[3] { vow2, vandanderize2, vandalaEffect2 }, 2);
            vandander.AddLevel(28, new Ability[3] { vow3, vandanderize3, vandalaEffect3 }, 3);
            vandander.AddCharacter();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Vandander");

        }
    }
}
