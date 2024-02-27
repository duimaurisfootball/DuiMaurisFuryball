namespace Dui_Mauris_Furyball
{
    public static class Filemarm
    {
        public static void Add()
        {
            //Custom Passive
            var GrayGenerator = ScriptableObject.CreateInstance<ChangePigmentGeneratorPool_Effect>();
            GrayGenerator._newPool = new ManaColorSO[1] { Pigments.Gray };

            var Impunity = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            Impunity._passiveName = "Impunity";
            Impunity.type = (PassiveAbilityTypes)843434;
            Impunity.passiveIcon = ResourceLoader.LoadSprite("Impunity");
            Impunity._enemyDescription = "The yellow pigment generator now generates gray pigment instead.";
            Impunity._characterDescription = "The yellow pigment generator now generates gray pigment instead.";
            Impunity.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new Effect(GrayGenerator, 0, null, Slots.Self),
                });
            Impunity.disconnectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[0]);
            Impunity._triggerOn = new TriggerCalls[0];

            //Alvinar Basics
            Character filemarm = new Character();
            
            filemarm.name = "Filemarm";
            filemarm.healthColor = Pigments.Purple;
            filemarm.entityID = (EntityIDs)981253;
            filemarm.frontSprite = ResourceLoader.LoadSprite("FilemarmFront");
            filemarm.backSprite = ResourceLoader.LoadSprite("FilemarmBack");
            filemarm.overworldSprite = ResourceLoader.LoadSprite("FilemarmOverworld", 32, new Vector2(0.5f, 0.02f));
            filemarm.lockedSprite = ResourceLoader.LoadSprite("FilemarmLocked");
            filemarm.unlockedSprite = ResourceLoader.LoadSprite("FilemarmMenu");
            filemarm.menuChar = true;
            filemarm.appearsInShops = true;
            filemarm.hurtSound = LoadedAssetsHandler.GetCharcater("Kleiver_CH").damageSound;
            filemarm.deathSound = LoadedAssetsHandler.GetCharcater("Kleiver_CH").deathSound;
            filemarm.dialogueSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").damageSound;
            filemarm.isSupport = true;
            filemarm.passives = new BasePassiveAbilitySO[]
            {
                Impunity,
                Passives.Slippery
            };


            //bilge
            RemoveAbilityOnPercentage BilgeRemove0 = ScriptableObject.CreateInstance<RemoveAbilityOnPercentage>();
            BilgeRemove0._percentageToApply = 40;
            RemoveAbilityOnPercentage BilgeRemove1 = ScriptableObject.CreateInstance<RemoveAbilityOnPercentage>();
            BilgeRemove1._percentageToApply = 50;
            RemoveAbilityOnPercentage BilgeRemove2 = ScriptableObject.CreateInstance<RemoveAbilityOnPercentage>();
            BilgeRemove2._percentageToApply = 60;
            RemoveAbilityOnPercentage BilgeRemove3 = ScriptableObject.CreateInstance<RemoveAbilityOnPercentage>();
            BilgeRemove3._percentageToApply = 70;

            Ability bilge0 = new Ability();
            bilge0.name = "Nasty Bilge";
            bilge0.description = "Apply 1 constricted to the Opposing position. 40% chance to remove 1 of the Opposing enemy's abilities.";
            bilge0.cost = new ManaColorSO[] { Pigments.Green, Pigments.Blue };
            bilge0.sprite = ResourceLoader.LoadSprite("bilge");
            bilge0.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, IntentType.Field_Constricted, Slots.Front),
                    new(BilgeRemove0, 1, IntentType.Other_Exhaust, Slots.Front),
                };
            bilge0.animationTarget = Slots.Front;
            bilge0.visuals = LoadedAssetsHandler.GetCharacterAbility("Oil_1_A").visuals;

            Ability bilge1 = bilge0.Duplicate();
            bilge1.name = "Infected Bilge";
            bilge1.description = "Apply 1 constricted to the Opposing position. 50% chance to remove 1 of the Opposing enemy's abilities.";
            bilge1.effects[1]._effect = BilgeRemove1;

            Ability bilge2 = bilge1.Duplicate();
            bilge2.name = "Actively Evolving Bilge";
            bilge2.description = "Apply 1 constricted to the Opposing position. 60% chance to remove 1 of the Opposing enemy's abilities.";
            bilge2.effects[1]._effect = BilgeRemove2;

            Ability bilge3 = bilge2.Duplicate();
            bilge3.name = "'Please Use Your Imagination' Bilge";
            bilge3.description = "Apply 1 constricted to the Opposing position. 70% chance to remove 1 of the Opposing enemy's abilities.";
            bilge3.effects[1]._effect = BilgeRemove3;


            //film
            RemoveAbilityOnPercentage FilmRemove0 = ScriptableObject.CreateInstance<RemoveAbilityOnPercentage>();
            FilmRemove0._percentageToApply = 30;

            Ability film0 = new Ability();
            film0.name = "Horrid Film";
            film0.description = "Apply 5 shield to this position. 30% chance to remove 1 of the Opposing enemy's abilities.";
            film0.cost = new ManaColorSO[] { Pigments.Green, Pigments.Red };
            film0.sprite = ResourceLoader.LoadSprite("film");
            film0.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, IntentType.Field_Shield, Slots.Self),
                    new(FilmRemove0, 1, IntentType.Other_Exhaust, Slots.Front),
                };
            film0.animationTarget = Slots.Self;
            film0.visuals = LoadedAssetsHandler.GetCharacterAbility("Weave_1_A").visuals;

            Ability film1 = film0.Duplicate();
            film1.name = "Loathesome Film";
            film1.description = "Apply 8 shield to this position. 30% chance to remove 1 of the Opposing enemy's abilities.";
            film1.effects[0]._entryVariable = 8;

            Ability film2 = film1.Duplicate();
            film2.name = "Verminous Film";
            film2.description = "Apply 11 shield to this position. 30% chance to remove 1 of the Opposing enemy's abilities.";
            film2.effects[0]._entryVariable = 11;

            Ability film3 = film2.Duplicate();
            film3.name = "Just the Most Vile, Revolting Film";
            film3.description = "Apply 16 shield to this position. 30% chance to remove 1 of the Opposing enemy's abilities.";
            film3.effects[0]._entryVariable = 16;


            //sump


            Ability sump0 = new Ability();
            sump0.name = "Dizzying Sump";
            sump0.description = "Heal this party member 3 health. Change 1 pigment to gray.";
            sump0.cost = new ManaColorSO[] { Pigments.Green, Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple) };
            sump0.sprite = ResourceLoader.LoadSprite("sump");
            sump0.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<HealEffect>(), 3, IntentType.Heal_1_4, Slots.Self),
                    new(ScriptableObject.CreateInstance<RerollGray>(), 1, IntentType.Mana_Modify, Slots.Self),
                };
            sump0.animationTarget = Slots.Self;
            sump0.visuals = LoadedAssetsHandler.GetEnemyAbility("RevoltingRevolution_A").visuals;

            Ability sump1 = sump0.Duplicate();
            sump1.name = "Cloying Sump";
            sump1.description = "Heal this party member 4 health. Change 1 pigment to gray.";
            sump1.effects[0]._entryVariable = 4;

            Ability sump2 = sump1.Duplicate();
            sump2.name = "Morbid, Noxious Sump";
            sump2.description = "Heal this party member 5 health. Change 1 pigment to gray.";
            sump2.effects[0]._entryVariable = 5;
            sump2.effects[0]._intent = IntentType.Heal_5_10;

            Ability sump3 = sump2.Duplicate();
            sump3.name = "I'd Rather Die than Describe This Sump";
            sump3.description = "Heal this party member 6 health. Change 2 pigment to gray.";
            sump3.effects[0]._entryVariable = 6;
            sump3.effects[1]._entryVariable = 2;

            
            filemarm.AddLevel(11, new Ability[3] { bilge0, film0, sump0 }, 0);
            filemarm.AddLevel(12, new Ability[3] { bilge1, film1, sump1 }, 1);
            filemarm.AddLevel(13, new Ability[3] { bilge2, film2, sump2 }, 2);
            filemarm.AddLevel(14, new Ability[3] { bilge3, film3, sump3 }, 3);
            filemarm.AddCharacter();

            //
            //
            //

            var thirtyPercentSweat = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            thirtyPercentSweat.triggerPercentage = 30;

            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;

            DoubleEffectItem doversPowder = new DoubleEffectItem();
            doversPowder.name = "Dover's Powder";
            doversPowder.flavorText = "\"The sweat of anticipation! There's so much of it!\"";
            doversPowder.description = "On turn start, reroll one enemy action. On turn end, there is a 30% chance to remove an enemy action.";
            doversPowder.sprite = ResourceLoader.LoadSprite("DoversPowder", 1, null);
            doversPowder.unlockableID = (UnlockableID)589176;
            doversPowder.namePopup = true;
            doversPowder.itemPools = BrutalAPI.ItemPools.Shop;
            doversPowder.shopPrice = 8;
            doversPowder.firstPopUp = true;
            doversPowder.trigger = TriggerCalls.OnTurnStart;
            doversPowder.triggerConditions = new EffectorConditionSO[]
            {

            };
            doversPowder.firstEffects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<ReRollRandomTimelineAbilityEffect>(), 1, null, Slots.Self),
            };
            doversPowder.secondPopUp = true;
            doversPowder.SecondTrigger = new TriggerCalls[]
            {
                TriggerCalls.OnTurnFinished,
            };
            doversPowder.secondTriggerConditions = new EffectorConditionSO[]
            {
                thirtyPercentSweat,
            };
            doversPowder.secondEffects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<RemoveRandomTimelineAbilityEffect>(), 1, null, allEnemy),
            };

            //
            //
            //

            var luckyGray = ScriptableObject.CreateInstance<LuckyBlueColorSetEffect>();
            luckyGray._luckyColor = Pigments.Gray;

            var grayEssence = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            grayEssence._passiveName = "Gray Essence";
            grayEssence.type = (PassiveAbilityTypes)891237;
            grayEssence.passiveIcon = ResourceLoader.LoadSprite("GrayEssence");
            grayEssence._enemyDescription = "Allows lucky pigment to be toggled to Gray.";
            grayEssence._characterDescription = "Allows lucky pigment to be toggled to Gray.";
            grayEssence.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new(luckyGray, 1, null, Slots.Self),
                });
            grayEssence._triggerOn = new TriggerCalls[]
                {
                    TriggerCalls.OnCombatStart,
                };

            var giveGray = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            giveGray._extraPassiveAbility = grayEssence;

            EffectItem ipecac = new EffectItem();
            ipecac.name = "Syrup of Ipecac";
            ipecac.flavorText = "\"Tired of being swallowed all the time? It's shocking how often it happens.\"";
            ipecac.description = "Adds Gray Essence to this party member as a passive. Essence allows lucky pigment to be toggled to colours other than just blue.";
            ipecac.sprite = ResourceLoader.LoadSprite("SyrupOfIpecac", 1, null);
            ipecac.trigger = TriggerCalls.OnCombatStart;
            ipecac.unlockableID = (UnlockableID)589175;
            ipecac.namePopup = true;
            ipecac.itemPools = BrutalAPI.ItemPools.Shop;
            ipecac.shopPrice = 9;
            ipecac.immediate = true;
            ipecac.equippedModifiers = new WearableStaticModifierSetterSO[]
            {
                giveGray
            };


            FoolItemPairs FilemarmPair = new FoolItemPairs(filemarm, doversPowder, ipecac);
            FilemarmPair.Add();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Filemarm");
        }
    }
}
