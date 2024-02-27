namespace Dui_Mauris_Furyball
{
    public class Naba
    {
        public static void Add()
        {

            //Custom Passives
            var Conviction = ScriptableObject.CreateInstance<DivineProtectingPassive>();
            Conviction._passiveName = "Conviction";
            Conviction.type = (PassiveAbilityTypes)726375;
            Conviction.passiveIcon = ResourceLoader.LoadSprite("conviction");
            Conviction._enemyDescription = "The Right enemy has divine protection.";
            Conviction._characterDescription = "The Right ally has divine protection.";
            Conviction._triggerOn = new TriggerCalls[]
                {
                };

            var lighthouseHeal = ScriptableObject.CreateInstance<HealWeakestEffect>();
            lighthouseHeal._checkCanHeal = true;

            var Lantern = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            Lantern._passiveName = "Night Lantern";
            Lantern.type = (PassiveAbilityTypes)726376;
            Lantern.passiveIcon = ResourceLoader.LoadSprite("reward");
            Lantern._enemyDescription = "not for enemies";
            Lantern._characterDescription = "The party member(s) with the lowest health is healed by 1 on turn end twice. Ignores allies that cannot be healed.";
            Lantern.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new(lighthouseHeal, 1, null, Slots.SlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true)),
                    new(lighthouseHeal, 1, null, Slots.SlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true)),
                });
            Lantern._triggerOn = new TriggerCalls[]
                {
                    TriggerCalls.OnTurnFinished
                };

            //bless
            Ability bless = new Ability();
            bless.name = "Contrition";
            bless.description = "Deal 3 damage to the opposing enemy. Inflict 2 divine protection to the opposing enemy.";
            bless.cost = new ManaColorSO[] { Pigments.Yellow };
            bless.sprite = ResourceLoader.LoadSprite("bless");
            bless.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<DamageEffect>(), 3, IntentType.Damage_3_6, Slots.Front),
                new(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 2, IntentType.Status_DivineProtection, Slots.Front),
            };
            bless.animationTarget = Slots.Front;
            bless.visuals = LoadedAssetsHandler.GetEnemyAbility("RapturousReverberation_A").visuals;


            //Naba Basics
            Character naba = new Character();
            
            naba.name = "Naba";
            naba.healthColor = Pigments.Blue;
            naba.entityID = (EntityIDs)577537;
            naba.frontSprite = ResourceLoader.LoadSprite("NabaFront");
            naba.backSprite = ResourceLoader.LoadSprite("NabaBack");
            naba.overworldSprite = ResourceLoader.LoadSprite("NabaOverworld", 32, new Vector2(0.5f, 0.02f));
            naba.lockedSprite = ResourceLoader.LoadSprite("NabaMenu");
            naba.unlockedSprite = ResourceLoader.LoadSprite("NabaMenu");
            naba.menuChar = true;
            naba.appearsInShops = true;
            naba.hurtSound = LoadedAssetsHandler.GetCharcater("Rags_CH").damageSound;
            naba.deathSound = LoadedAssetsHandler.GetCharcater("Rags_CH").deathSound;
            naba.dialogueSound = LoadedAssetsHandler.GetCharcater("Rags_CH").damageSound;
            naba.isSupport = true;
            naba.baseAbility = bless;
            naba.passives = new BasePassiveAbilitySO[]
            {
                Conviction,
                Lantern
            };

            //Crown
            Ability crown0 = new Ability();
            crown0.name = "Crown of Pins";
            crown0.description = "Heal Right ally 8. Deal 6 damage to the Right ally.";
            crown0.cost = new ManaColorSO[] { Pigments.Blue };
            crown0.sprite = ResourceLoader.LoadSprite("crown");
            crown0.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<HealEffect>(), 8, IntentType.Heal_5_10, Slots.SlotTarget(new int[] { 1 }, true)),
                new(ScriptableObject.CreateInstance<DamageEffect>(), 6, IntentType.Damage_3_6, Slots.SlotTarget(new int[] { 1 }, true)),
            };
            crown0.animationTarget = Slots.SlotTarget(new int[] { 1 }, true);
            crown0.visuals = LoadedAssetsHandler.GetCharacterAbility("Impenetrable_1_A").visuals;

            Ability crown1 = crown0.Duplicate();
            crown1.name = "Crown of Stakes";
            crown1.description = "Heal Right ally 12. Deal 6 damage to the Right ally.";
            crown1.effects[0]._entryVariable = 12;
            crown1.effects[0]._intent = IntentType.Heal_11_20;


            Ability crown2 = crown1.Duplicate();
            crown2.name = "Crown of Thorns";
            crown2.description = "Heal Right ally 16. Deal 6 damage to the Right ally.";
            crown2.effects[0]._entryVariable = 16;


            Ability crown3 = crown2.Duplicate();
            crown3.name = "Crown of Crowns";
            crown3.description = "Heal Right ally 20. Deal 6 damage to the Right ally.";
            crown3.effects[0]._entryVariable = 20;


            var purpleGen = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            purpleGen.mana = Pigments.Purple;
            var redGen = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            redGen.mana = Pigments.Red;
            var blueGen = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            blueGen.mana = Pigments.Blue;
            var yellowGen = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            yellowGen.mana = Pigments.Yellow;

            //Two Prayers
            Ability twoPrayers0 = new Ability();
            twoPrayers0.name = "Two Prayers for the Ill";
            twoPrayers0.description = "Generate 1 of each pigment. Deal 5 damage to the Left, Right, and Opposing enemies.";
            twoPrayers0.cost = new ManaColorSO[] { Pigments.Blue };
            twoPrayers0.sprite = ResourceLoader.LoadSprite("whatsleft");
            twoPrayers0.effects = new Effect[]
            {
                new(redGen, 1, IntentType.Mana_Generate, Slots.Self),
                new(blueGen, 1, null, Slots.Self),
                new(yellowGen, 1, null, Slots.Self),
                new(purpleGen, 1, null, Slots.Self),
                new(ScriptableObject.CreateInstance<DamageEffect>(), 5, IntentType.Damage_3_6, Slots.FrontLeftRight),
            };
            twoPrayers0.animationTarget = Slots.Self;
            twoPrayers0.visuals = LoadedAssetsHandler.GetEnemyAbility("Struggle_A").visuals;

            Ability twoPrayers1 = twoPrayers0.Duplicate();
            twoPrayers1.name = "Two Prayers for the Poor";
            twoPrayers1.description = "Generate 1 of each pigment. Deal 6 damage to the Left, Right, and Opposing enemies.";
            twoPrayers1.effects[4]._entryVariable = 6;

            Ability twoPrayers2 = twoPrayers1.Duplicate();
            twoPrayers2.name = "Two Prayers for the Wicked";
            twoPrayers2.description = "Generate 1 of each pigment. Deal 7 damage to the Left, Right, and Opposing enemies.";
            twoPrayers2.effects[4]._entryVariable = 7;

            Ability twoPrayers3 = twoPrayers2.Duplicate();
            twoPrayers3.name = "Two Prayers for the Mortal";
            twoPrayers3.description = "Generate 1 of each pigment. Deal 8 damage to the Left, Right, and Opposing enemies.";
            twoPrayers3.effects[4]._entryVariable = 8;


            //Revelation
            Ability revelation0 = new Ability();
            revelation0.name = "A Revelation";
            revelation0.description = "Deal 7 damage to the Right ally. Refresh the Right ally.";
            revelation0.cost = new ManaColorSO[] { Pigments.Blue };
            revelation0.sprite = ResourceLoader.LoadSprite("revelation");
            revelation0.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<DamageEffect>(), 7, IntentType.Damage_7_10, Slots.SlotTarget(new int[] { 1 }, true)),
                new(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, IntentType.Other_Refresh, Slots.SlotTarget(new int[] { 1 }, true)),
            };
            revelation0.animationTarget = Slots.SlotTarget(new int[] { 1 }, true);
            revelation0.visuals = LoadedAssetsHandler.GetCharacterAbility("Torch_1_A").visuals;

            Ability revelation1 = revelation0.Duplicate();
            revelation1.name = "The Revelation";
            revelation1.description = "Deal 6 damage to the Right ally. Refresh the Right ally.";
            revelation1.effects[0]._entryVariable = 6;
            revelation0.effects[0]._intent = IntentType.Damage_3_6;

            Ability revelation2 = revelation1.Duplicate();
            revelation2.name = "And Revelation";
            revelation2.description = "Deal 5 damage to the Right ally. Refresh the Right ally.";
            revelation2.effects[0]._entryVariable = 5;

            Ability revelation3 = revelation2.Duplicate();
            revelation3.name = "Revelations";
            revelation3.description = "Deal 4 damage to the Right ally. Refresh the Right ally.";
            revelation3.effects[0]._entryVariable = 4;

            //
            //
            //

            var randomGen = ScriptableObject.CreateInstance<GenerateRandomManaBetweenEffect>();
            randomGen.possibleMana = new ManaColorSO[] { Pigments.Red, Pigments.Purple, Pigments.Yellow, Pigments.Blue };
            randomGen.usePreviousExitValueAsMultiplier = false;

            var untether = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            untether._extraPassiveAbility = Passives.UntetheredEssence;

            var fresnelLens = new FresnelItem();
            fresnelLens.name = "Fresnel Lens";
            fresnelLens.flavorText = "\"Focus the light, save their lives.\"";
            fresnelLens.description = "This party member has Untethered Essence as a passive. Upon lucky pigment triggering, produce an additional random pigment.";
            fresnelLens.sprite = ResourceLoader.LoadSprite("FresnelLens", 1, null);
            fresnelLens.unlockableID = (UnlockableID)7728738;
            fresnelLens.namePopup = false;
            fresnelLens.itemPools = BrutalAPI.ItemPools.Shop;
            fresnelLens.shopPrice = 4;
            fresnelLens.effects = new Effect[]
            {
                new(randomGen, 1, null, Slots.Self),
            };
            fresnelLens.equippedModifiers = new WearableStaticModifierSetterSO[]
            {
                untether
            };

            //
            //
            //

            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;

            var fishMoney = ScriptableObject.CreateInstance<ExtraCurrencyEffect>();
            fishMoney._isMultiplier = true;

            var kraken = new DoubleEffectItem();
            kraken.name = "The Kraken";
            kraken.flavorText = "\"The terror of the seven seas!\"";
            kraken.description = "Add 6 additional attacks to the timeline every turn. Gain thrice as many coins at the end of combat.";
            kraken.sprite = ResourceLoader.LoadSprite("kraken", 1, null);
            kraken.unlockableID = (UnlockableID)7728739;
            kraken.namePopup = true;
            kraken.itemPools = BrutalAPI.ItemPools.Treasure;
            kraken.fishRarity = 1;
            kraken.trigger = TriggerCalls.OnTurnStart;
            kraken.firstEffects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<AddRandomTimelineAbilityEffect>(), 1, null, allEnemy),
                new(ScriptableObject.CreateInstance<AddRandomTimelineAbilityEffect>(), 1, null, allEnemy),
                new(ScriptableObject.CreateInstance<AddRandomTimelineAbilityEffect>(), 1, null, allEnemy),
                new(ScriptableObject.CreateInstance<AddRandomTimelineAbilityEffect>(), 1, null, allEnemy),
                new(ScriptableObject.CreateInstance<AddRandomTimelineAbilityEffect>(), 1, null, allEnemy),
                new(ScriptableObject.CreateInstance<AddRandomTimelineAbilityEffect>(), 1, null, allEnemy),
            };
            kraken.SecondTrigger = new TriggerCalls[]
            {
                TriggerCalls.OnCombatEnd
            };
            kraken.secondEffects = new Effect[]
            {
                new(fishMoney, 3, null, Slots.Self),
            };

            FoolItemPairs NabaPair = new FoolItemPairs(naba, fresnelLens, kraken);
            NabaPair.Add();

            
            naba.AddLevel(12, new Ability[3] { crown0, twoPrayers0, revelation0 }, 0);
            naba.AddLevel(14, new Ability[3] { crown1, twoPrayers1, revelation1 }, 1);
            naba.AddLevel(16, new Ability[3] { crown2, twoPrayers2, revelation2 }, 2);
            naba.AddLevel(17, new Ability[3] { crown3, twoPrayers3, revelation3 }, 3);
            naba.AddCharacter();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Alvinar");
        }
    }
}
