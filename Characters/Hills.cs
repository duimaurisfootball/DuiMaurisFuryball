namespace Dui_Mauris_Furyball
{
    public class Hills
    {
        public static void Add()
        {
            //Hills Basics
            Character hills = new Character();
            hills.name = "Hills";
            hills.healthColor = Pigments.Yellow;
            hills.entityID = (EntityIDs)33299105;
            hills.frontSprite = ResourceLoader.LoadSprite("HillsFront");
            hills.backSprite = ResourceLoader.LoadSprite("HillsBack");
            hills.overworldSprite = ResourceLoader.LoadSprite("HillsOverworld", 32, new Vector2(0.5f, 0.02f));
            hills.lockedSprite = ResourceLoader.LoadSprite("HillsMenu");
            hills.unlockedSprite = ResourceLoader.LoadSprite("HillsMenu");
            hills.menuChar = true;
            hills.appearsInShops = true;
            hills.walksInOverworld = false;
            hills.hurtSound = LoadedAssetsHandler.GetEnemy("Visage_Siblings_EN").deathSound;
            hills.deathSound = LoadedAssetsHandler.GetEnemy("Visage_Siblings_EN").deathSound;
            hills.dialogueSound = LoadedAssetsHandler.GetEnemy("Visage_Siblings_EN").deathSound;
            hills.isSupport = false;

            var indirectDamage = ScriptableObject.CreateInstance<DamageEffect>();
            indirectDamage._indirect = true;

            var shatterSounds = ScriptableObject.CreateInstance<HillsShatterEffect>();
            shatterSounds._sound = LoadedAssetsHandler.GetEnemy("Visage_Siblings_EN").deathSound;
            shatterSounds._waitTime = 0;

            var insanity = ScriptableObject.CreateInstance<ManiaEffect>();
            insanity._sound = LoadedAssetsHandler.GetEnemy("Visage_Siblings_EN").deathSound;
            insanity._waitTime = 0;
            insanity._damage = 6;
            insanity._extraTargets = Slots.Self;
            insanity._extraTargetsAttack = Slots.Front;
            insanity._repeatChance = 70;

            var insanity2 = ScriptableObject.CreateInstance<ManiaEffect>();
            insanity2._sound = LoadedAssetsHandler.GetEnemy("Visage_Siblings_EN").deathSound;
            insanity2._waitTime = 0;
            insanity2._damage = 6;
            insanity2._extraTargets = Slots.Self;
            insanity2._extraTargetsAttack = Slots.Front;
            insanity2._repeatChance = 80;


            //Bellow
            var bellow0 = new Ability();
            bellow0.name = "Clay Bellow";
            bellow0.description = "Shuffle the Left, Right, and Opposing enemies. Deal 6 indirect damage to them. Deal 1 damage to self. 50% chance to apply 1 scar to self. Refresh.";
            bellow0.cost = new ManaColorSO[] { Pigments.Yellow, Pigments.Red };
            bellow0.sprite = ResourceLoader.LoadSprite("bellow");
            bellow0.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<MassSwapZoneEffect>(), 1, IntentType.Swap_Mass, Slots.SlotTarget(new int[] {-1, 0, 1}, false)),
                new(indirectDamage, 6, IntentType.Damage_3_6, Slots.SlotTarget(new int[] {-1, 0, 1}, false)),
                new(ScriptableObject.CreateInstance<DamageEffect>(), 1, IntentType.Damage_1_2, Slots.Self),
                new(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, IntentType.Status_Scars, Slots.Self, Conditions.Chance(50)),
                new(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, IntentType.Other_Refresh, Slots.Self),
            };
            bellow0.animationTarget = Slots.Self;
            bellow0.visuals = LoadedAssetsHandler.GetEnemyAbility("Bellow_A").visuals;

            var bellow1 = bellow0.Duplicate();
            bellow1.name = "Painted Bellow";
            bellow1.description = "Shuffle the Left, Right, and Opposing enemies. Deal 8 indirect damage to them. Deal 1 damage to self. 50% chance to apply 1 scar to self. Refresh.";
            bellow1.effects[1]._entryVariable = 8;

            var bellow2 = bellow1.Duplicate();
            bellow2.name = "Ancient Bellow";
            bellow2.description = "Shuffle the Left, Right, and Opposing enemies. Deal 9 indirect damage to them. Deal 1 damage to self. 50% chance to apply 1 scar to self. Refresh.";
            bellow2.effects[1]._entryVariable = 9;

            var bellow3 = bellow2.Duplicate();
            bellow3.name = "Piling Bellow";
            bellow3.description = "Shuffle the Left, Right, and Opposing enemies. Deal 10 indirect damage to them. Deal 1 damage to self. 50% chance to apply 1 scar to self. Refresh.";
            bellow3.effects[1]._entryVariable = 10;

            //Shatter
            var shatter0 = new Ability();
            shatter0.name = "A Stupid Shatter";
            shatter0.description = "Deal 2-10 damage to the Opposing enemy. If this attack hits shield, do it again.";
            shatter0.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red };
            shatter0.sprite = ResourceLoader.LoadSprite("shatter");
            shatter0.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 2, null, Slots.Self),
                new(shatterSounds, 10, IntentType.Damage_7_10, Slots.Front),
            };
            shatter0.animationTarget = Slots.Front;
            shatter0.visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;

            var shatter1 = shatter0.Duplicate();
            shatter1.name = "A Loud Shatter";
            shatter1.description = "Deal 4-16 damage to the Opposing enemy. If this attack hits shield, do it again.";
            shatter1.effects[0]._entryVariable = 4;
            shatter1.effects[1]._entryVariable = 16;

            var shatter2 = shatter1.Duplicate();
            shatter2.name = "A Resounding Shatter";
            shatter2.description = "Deal 6-20 damage to the Opposing enemy. If this attack hits shield, do it again.";
            shatter2.effects[0]._entryVariable = 6;
            shatter2.effects[1]._entryVariable = 20;

            var shatter3 = shatter2.Duplicate();
            shatter3.name = "A Thunderous Shatter";
            shatter3.description = "Deal 10-22 damage to the Opposing enemy. If this attack hits shield, do it again.";
            shatter3.effects[0]._entryVariable = 10;
            shatter3.effects[1]._entryVariable = 22;

            //Mania
            var mania0 = new Ability();
            mania0.name = "Mania by Rolling";
            mania0.description = "Deal 6 damage to the Opposing enemy. Consume 1-2 pigment. Move self Left or Right. 90% chance to apply 1 scar to self. 70% chance to repeat this ability.";
            mania0.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.Red, Pigments.Red };
            mania0.sprite = ResourceLoader.LoadSprite("mania");
            mania0.effects = new Effect[]
            {
                new(insanity, 90, IntentType.Damage_3_6, Slots.Front),
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, IntentType.Mana_Consume, Slots.Front),
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, IntentType.Swap_Sides, Slots.Front),
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, IntentType.Misc, Slots.Front),
            };
            mania0.animationTarget = Slots.Self;
            mania0.visuals = LoadedAssetsHandler.GetCharacterAbility("Amalgam_1_A").visuals;

            var mania1 = mania0.Duplicate();
            mania1.name = "Mania by Cooking";
            mania1.description = "Deal 6 damage to the Opposing enemy. Consume 1-2 pigment. Move self Left or Right. 75% chance to apply 1 scar to self. 70% chance to repeat this ability.";
            mania1.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.Red, Pigments.SplitPigment( Pigments.Red, Pigments.Yellow ) };
            mania1.effects[0]._entryVariable = 75;

            var mania2 = mania1.Duplicate();
            mania2.name = "Mania by Wishing";
            mania2.description = "Deal 6 damage to the Opposing enemy. Consume 1-2 pigment. Move self Left or Right. 66% chance to apply 1 scar to self. 70% chance to repeat this ability.";
            mania2.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.SplitPigment(Pigments.Red, Pigments.Yellow), Pigments.SplitPigment(Pigments.Red, Pigments.Yellow) };
            mania2.effects[0]._entryVariable = 66;

            var mania3 = mania2.Duplicate();
            mania3.name = "Mania by Day, Mania by Night";
            mania3.description = "Deal 6 damage to the Opposing enemy. Consume 1-2 pigment. Move self Left or Right. 50% chance to apply 1 scar to self. 80% chance to repeat this ability.";
            mania3.cost = new ManaColorSO[] { Pigments.Red, Pigments.SplitPigment(Pigments.Red, Pigments.Yellow), Pigments.SplitPigment(Pigments.Red, Pigments.Yellow), Pigments.SplitPigment(Pigments.Red, Pigments.Yellow) };
            mania3.effects[0]._effect = insanity2;
            mania3.effects[0]._entryVariable = 50;

            //
            //
            //

            var infiniteDamage = ScriptableObject.CreateInstance<DamageByStoredValueEffect>();
            infiniteDamage._valueName = (UnitStoredValueNames)901753812;
            infiniteDamage._increaseDamage = true;
            infiniteDamage._indirect = true;

            var infiniteValue = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            infiniteValue._valueName = (UnitStoredValueNames)901753812;

            var soulSlap = ScriptableObject.CreateInstance<AbilitiesUsageChange_Wearable_SMS>();
            soulSlap._usesAllAbilities = true;
            soulSlap._usesBasicAbility = false;



            var infiniteMirror = new DoubleEffectItem();
            infiniteMirror.name = "Infinite Mirror";
            infiniteMirror.flavorText = "\"Tree falling no one would hear.\"";
            infiniteMirror.description = "\"Slap\" is replaced with this party member's missing ability. Upon taking any damage, perform one of this party member's abilities and deal 1 indirect damage to them. 20% chance to increase the damage by 1. Continue until they are dead.";
            infiniteMirror.sprite = ResourceLoader.LoadSprite("InfiniteMirror", 1, null);
            infiniteMirror.unlockableID = (UnlockableID)1310501082;
            infiniteMirror.namePopup = true;
            infiniteMirror.itemPools = BrutalAPI.ItemPools.Treasure;
            infiniteMirror.trigger = TriggerCalls.OnDamaged;
            infiniteMirror.firstEffects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, null, Slots.Self),
            };
            infiniteMirror.secondPopUp = false;
            infiniteMirror.SecondTrigger = new TriggerCalls[]
            {
                TriggerCalls.OnDamaged
            };
            infiniteMirror.secondEffects = new Effect[]
            {
                new(infiniteDamage, 1, null, Slots.Self),
                new(infiniteValue, 1, null, Slots.Self, Conditions.Chance(20))
            };
            infiniteMirror.equippedModifiers = new WearableStaticModifierSetterSO[]
            {
                soulSlap
            };

            //
            //
            //
            var repeatEffect = ScriptableObject.CreateInstance<UnboundedDamageEffect>();
            repeatEffect._repeatChance = 95;
            repeatEffect._guaranteedRepeats = 1;
            repeatEffect._multiplier = 1;

            var randomDamage = new Ability();
            randomDamage.name = "Run Forth";
            randomDamage.description = "Deal at least 1 damage to the opposing enemy.";
            randomDamage.cost = new ManaColorSO[] { Pigments.Gray, Pigments.Gray, Pigments.Gray, Pigments.Gray, Pigments.Gray, Pigments.Gray, };
            randomDamage.sprite = ResourceLoader.LoadSprite("runforthecube");
            randomDamage.effects = new Effect[]
                {
                    new(repeatEffect, 1, IntentType.Damage_1_2, Slots.Front)
                };
            randomDamage.animationTarget = Slots.Front;
            randomDamage.visuals = LoadedAssetsHandler.GetEnemyAbility("FallingSkies_A").visuals;

            ExtraAbility_Wearable_SMS unbounded = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            unbounded._extraAbility = randomDamage.CharacterAbility();

            var potOfGreed = new EffectItem();
            potOfGreed.name = "Pot of Greed";
            potOfGreed.flavorText = "\"I'll just... draw more cards.\"";
            potOfGreed.description = "Adds \"Run Forth\" as an additional ability, an attack that deals a random amount of damage.";
            potOfGreed.sprite = ResourceLoader.LoadSprite("PotOfGreed", 1, null);
            potOfGreed.unlockableID = (UnlockableID)1310501083;
            potOfGreed.namePopup = false;
            potOfGreed.itemPools = BrutalAPI.ItemPools.Treasure;
            potOfGreed.equippedModifiers = new WearableStaticModifierSetterSO[]
            {
                unbounded
            };

            Connection_PerformEffectPassiveAbility connection_PerformEffectPassiveAbility = LoadedAssetsHandler.GetCharcater("Doll_CH").passiveAbilities[0] as Connection_PerformEffectPassiveAbility;
            CasterAddRandomExtraAbilityEffect casterAddRandomExtraAbilityEffect = connection_PerformEffectPassiveAbility.connectionEffects[1].effect as CasterAddRandomExtraAbilityEffect;
            casterAddRandomExtraAbilityEffect._extraData = new List<ExtraAbility_Wearable_SMS>(casterAddRandomExtraAbilityEffect._extraData)
            { 
                unbounded
            }.ToArray();

            FoolItemPairs HillsPair = new FoolItemPairs(hills, infiniteMirror, potOfGreed);
            HillsPair.Add();

            hills.AddLevel(14, new Ability[] { bellow0, shatter0, mania0 }, 0);
            hills.AddLevel(16, new Ability[] { bellow1, shatter1, mania1 }, 1);
            hills.AddLevel(18, new Ability[] { bellow2, shatter2, mania2 }, 2);
            hills.AddLevel(20, new Ability[] { bellow3, shatter3, mania3 }, 3);
            hills.AddCharacter();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Hills");

        }
    }
}
