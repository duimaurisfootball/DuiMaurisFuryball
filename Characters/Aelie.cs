namespace Dui_Mauris_Furyball
{
    public class Aelie
    {
        public static void Add()
        {
            //Custom Passive
            var Windswept = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            Windswept._passiveName = "Windswept";
            Windswept.passiveIcon = ResourceLoader.LoadSprite("windswept");
            Windswept._enemyDescription = "On turn start, randomly move this enemy and the Left and Right enemies twice.";
            Windswept._characterDescription = "On turn start, randomly move this party member and the Left and Right allies twice.";
            Windswept.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new(ScriptableObject.CreateInstance<MassSwapZoneEffect>(), 1, null, Slots.SlotTarget(new int[] { -1, 0, 1 }, true)),
                    new(ScriptableObject.CreateInstance<MassSwapZoneEffect>(), 1, null, Slots.SlotTarget(new int[] { -1, 0, 1 }, true)),
                });
            Windswept._triggerOn = new TriggerCalls[]
                {
                    TriggerCalls.OnTurnStart
                };

            //base ability
            var parry = new Ability();
            parry.name = "Parry";
            parry.description = "Deal 1 damage to the Opposing enemy. Move the Opposing enemy to the Left or Right.";
            parry.cost = new ManaColorSO[] { Pigments.Yellow };
            parry.sprite = ResourceLoader.LoadSprite("parry");
            parry.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<DamageEffect>(), 1, IntentType.Damage_1_2, Slots.Front),
                new(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Front),
            };
            parry.animationTarget = Slots.Front;
            parry.visuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;

            //Aelie Basics
            Character aelie = new Character();
            aelie.name = "Aelie";
            aelie.healthColor = Pigments.Yellow;
            aelie.entityID = (EntityIDs)661266;
            aelie.frontSprite = ResourceLoader.LoadSprite("AelieFront");
            aelie.backSprite = ResourceLoader.LoadSprite("AelieBack");
            aelie.overworldSprite = ResourceLoader.LoadSprite("AelieOverworld", 32, new Vector2(0.5f, 0.02f));
            aelie.lockedSprite = ResourceLoader.LoadSprite("AelieMenu");
            aelie.unlockedSprite = ResourceLoader.LoadSprite("AelieMenu");
            aelie.menuChar = true;
            aelie.appearsInShops = true;
            aelie.baseAbility = parry;
            aelie.hurtSound = LoadedAssetsHandler.GetCharcater("Rags_CH").dxSound;
            aelie.deathSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").damageSound;
            aelie.dialogueSound = LoadedAssetsHandler.GetCharcater("Rags_CH").dxSound;
            aelie.isSupport = false;
            aelie.passives = new BasePassiveAbilitySO[]
            {
                Windswept,
                Passives.Skittish,
            };

            var indirectDamage = ScriptableObject.CreateInstance<DamageEffect>();
            indirectDamage._indirect = true;

            var healthYellow = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
            healthYellow._healthColors = new ManaColorSO[]
            {
                Pigments.Yellow
            };

            var remRupture = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            remRupture._statusToRemove = StatusEffectType.Ruptured;

            var fireAnim1 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            fireAnim1._visuals = LoadedAssetsHandler.GetCharacterAbility("Torch_1_A").visuals;
            fireAnim1._animationTarget = Slots.SlotTarget(new int[] { -1, 1 }, false);

            var fireAnim2 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            fireAnim2._visuals = LoadedAssetsHandler.GetCharacterAbility("Torch_1_A").visuals;
            fireAnim2._animationTarget = Slots.SlotTarget(new int[] { -1, 0, 1 }, false);

            var sandFire = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            sandFire._visuals = LoadedAssetsHandler.GetCharacterAbility("Torch_1_A").visuals;
            sandFire._animationTarget = Slots.Front;

            var remConstricted = ScriptableObject.CreateInstance<RemoveSlotEffect>();
            remConstricted._statusEffectType = SlotStatusEffectType.Constricted;

            var sunDry = ScriptableObject.CreateInstance<ConsumeAllColorManaEffect>();
            sunDry._consumeMana = Pigments.Blue;

            var sunHeal = ScriptableObject.CreateInstance<HealByHealthColorPlusEntryVariableCarryPeviousExitValueEffect>();
            sunHeal._matchingHealthColor = Pigments.Yellow;

            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;

            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllies = true;
            allAlly.getAllUnitSlots = false;

            //Frenzy
            Ability sand0 = new Ability();
            sand0.name = "Sand Throw";
            sand0.description = "Deal 4 indirect damage to the Opposing enemy. Randomly move the Left, Right, and Opposing enemies. Deal 6 indirect damage to the Opposing enemy. Consume 3 pigment. Remove ruptured from the Left ally.";
            sand0.cost = new ManaColorSO[] { Pigments.Yellow, Pigments.Yellow };
            sand0.sprite = ResourceLoader.LoadSprite("sands");
            sand0.effects = new Effect[]
            {
                new(indirectDamage, 4, IntentType.Damage_3_6, Slots.Front),
                new(ScriptableObject.CreateInstance<MassSwapZoneEffect>(), 1, IntentType.Swap_Mass, Slots.SlotTarget(new int[] { -1, 0, 1 }, false)),
                new(sandFire, 1, null, Slots.Self),
                new(indirectDamage, 6, IntentType.Damage_3_6, Slots.Front),
                new(ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 3, IntentType.Mana_Consume, Slots.Self),
                new(remRupture, 1, IntentType.Rem_Status_Ruptured, Slots.SlotTarget(new int[] { -1 }, true)),
            };
            sand0.animationTarget = Slots.Front;
            sand0.visuals = LoadedAssetsHandler.GetCharacterAbility("Torch_1_A").visuals;

            Ability sand1 = sand0.Duplicate();
            sand1.name = "Sand Dunes";
            sand1.description = "Deal 5 indirect damage to the Opposing enemy. Randomly move the Left, Right, and Opposing enemies. Deal 7 indirect damage to the Opposing enemy. Consume 3 pigment. Remove ruptured from the Left ally.";
            sand1.effects[0]._entryVariable = 5;
            sand1.effects[3]._entryVariable = 7;
            sand1.effects[3]._intent = IntentType.Damage_7_10;

            Ability sand2 = sand1.Duplicate();
            sand2.name = "Sandstorm";
            sand2.description = "Deal 7 indirect damage to the Opposing enemy. Randomly move the Left, Right, and Opposing enemies. Deal 9 indirect damage to the Opposing enemy. Consume 3 pigment. Remove ruptured from the Left ally.";
            sand2.effects[0]._entryVariable = 7;
            sand2.effects[0]._intent = IntentType.Damage_7_10;
            sand2.effects[3]._entryVariable = 9;

            Ability sand3 = sand2.Duplicate();
            sand3.name = "Sands of Time";
            sand3.description = "Deal 9 indirect damage to the Opposing enemy. Randomly move the Left, Right, and Opposing enemies. Deal 10 indirect damage to the Opposing enemy. Consume 3 pigment. Remove ruptured from the Left ally.";
            sand3.effects[0]._entryVariable = 8;
            sand3.effects[3]._entryVariable = 9;

            //desiccate
            Ability desiccate0 = new Ability();
            desiccate0.name = "Desiccate Quietly";
            desiccate0.description = "Remove constricted from the Left and this position. Consume all blue pigment. Heal All party members and enemies with Yellow health color the amount consumed. Remove ruptured from the Left ally.";
            desiccate0.cost = new ManaColorSO[] { Pigments.Yellow };
            desiccate0.sprite = ResourceLoader.LoadSprite("desiccate");
            desiccate0.effects = new Effect[]
            {
                new(remConstricted, 0, IntentType.Rem_Field_Constricted, Slots.SlotTarget(new int[] { -1, 0 }, true)),
                new(sunDry, 0, IntentType.Mana_Consume, Slots.Self),
                new(sunHeal, 0, IntentType.Heal_5_10, allAlly),
                new(sunHeal, 0, IntentType.Heal_5_10, allEnemy),
            };
            desiccate0.animationTarget = Slots.Self;
            desiccate0.visuals = LoadedAssetsHandler.GetCharacterAbility("Fumes_1_A").visuals;


            Ability desiccate1 = desiccate0.Duplicate();
            desiccate1.name = "Desiccate Slyly";
            desiccate1.description = "Remove constricted from the Left, Right, and this position. Consume all blue pigment. Heal All party members and enemies with Yellow health color the amount consumed + 1.";
            desiccate1.effects[0]._target = Slots.SlotTarget(new int[] { -1, 0, 1 }, true);
            desiccate1.effects[2]._entryVariable = 1;
            desiccate1.effects[3]._entryVariable = 1;

            Ability desiccate2 = desiccate1.Duplicate();
            desiccate2.name = "Desiccate Carefully";
            desiccate2.description = "Remove constricted from the Far Left, Left, Right, and this position. Consume all blue pigment. Heal All party members and enemies with Yellow health color the amount consumed + 2.";
            desiccate2.effects[0]._target = Slots.SlotTarget(new int[] { -2, -1, 0, 1 }, true);
            desiccate2.effects[2]._entryVariable = 2;
            desiccate2.effects[3]._entryVariable = 2;


            Ability desiccate3 = desiccate2.Duplicate();
            desiccate3.name = "Desiccate Instantly";
            desiccate3.description = "Remove constricted from the Far Left, Left, Right, Far Right, and this position. Consume all blue pigment. Heal All party members and enemies with Yellow health color the amount consumed + 3.";
            desiccate3.effects[0]._target = Slots.SlotTarget(new int[] { -2, -1, 0, 1, 2 }, true);
            desiccate3.effects[2]._entryVariable = 3;
            desiccate3.effects[3]._entryVariable = 3;


            //singing
            Ability singing0 = new Ability();
            singing0.name = "Singing Wind";
            singing0.description = "Randomly move this party member and the Left and Right allies. Deal 6 indirect damage to the Left and Right enemies. Change the Left and Right allies' health to yellow.";
            singing0.cost = new ManaColorSO[] { Pigments.SplitPigment(Pigments.Yellow, Pigments.Red), Pigments.SplitPigment(Pigments.Yellow, Pigments.Red) };
            singing0.sprite = ResourceLoader.LoadSprite("singing");
            singing0.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<MassSwapZoneEffect>(), 1, IntentType.Swap_Mass, Slots.SlotTarget(new int[] { -1, 0, 1 }, true)),
                new(fireAnim1, 1, null, Slots.Self),
                new(indirectDamage, 6, IntentType.Damage_3_6, Slots.SlotTarget(new int[] { -1, 1 }, false)),
                new(healthYellow, 1, IntentType.Mana_Modify, Slots.SlotTarget(new int[] { -1, 1 }, true)),
            };

            Ability singing1 = singing0.Duplicate();
            singing1.name = "Singing Sand";
            singing1.description = "Randomly move this party member and the Left and Right allies. Deal 8 indirect damage to the Left and Right enemies. Change the Left and Right allies' health to yellow.";
            singing1.effects[2]._entryVariable = 8;
            singing1.effects[2]._intent = IntentType.Damage_7_10;

            Ability singing2 = singing1.Duplicate();
            singing2.name = "Singing Night";
            singing2.description = "Randomly move this party member and the Left and Right allies. Deal 10 indirect damage to the Left and Right enemies. Change the Left and Right allies' health to yellow.";
            singing2.effects[2]._entryVariable = 10;

            Ability singing3 = singing2.Duplicate();
            singing3.name = "Singing Sun";
            singing3.description = "Randomly move this party member and the Left and Right allies. Deal 10 indirect damage to the Left, Right and Opposing enemies. Change the Left and Right allies' health to yellow.";
            singing3.effects[1]._effect = fireAnim2;
            singing3.effects[2]._target = Slots.SlotTarget(new int[] { -1, 0, 1 }, false);

            //
            //
            //

            var healthToYellow = ScriptableObject.CreateInstance<HealthColorChange_Wearable_SMS>();
            healthToYellow._healthColor = Pigments.Yellow;

            var liquidDust = new DustItem();
            liquidDust.name = "Liquid Dust";
            liquidDust.flavorText = "\"Rubbish for sand castles.\"";
            liquidDust.description = "Deal double damage against targets with blue health. Deal quarter damage against targets with yellow health. Change this party member's health to yellow.";
            liquidDust.sprite = ResourceLoader.LoadSprite("LiquidDust", 1, null);
            liquidDust.unlockableID = (UnlockableID)6082460;
            liquidDust.namePopup = true;
            liquidDust.itemPools = BrutalAPI.ItemPools.Treasure;
            liquidDust.equippedModifiers = new WearableStaticModifierSetterSO[]
            {
                healthToYellow
            };

            //
            //
            //

            var luckyUp = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            luckyUp._increase = true;
            luckyUp._valueName = (UnitStoredValueNames)0017802;

            var luckyOne = ScriptableObject.CreateInstance<CasterStoreValueSetterEffect>();
            luckyOne._valueName = (UnitStoredValueNames)0017802;

            IDetour dustiness = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(HourglassStoredValue).GetMethod("AddStoredValueName", ~BindingFlags.Default));

            var brokenHourglass = new MultiCustomTriggerEffectItem();
            brokenHourglass.name = "Broken Hourglass";
            brokenHourglass.flavorText = "\"One way timer.\"";
            brokenHourglass.description = "Upon lucky pigment not triggering, increase the amount of pigment it generates. Upon lucky pigment triggering, reduce it to 1.";
            brokenHourglass.sprite = ResourceLoader.LoadSprite("BrokenHourglass", 1, null);
            brokenHourglass.unlockableID = (UnlockableID)6082461;
            brokenHourglass.namePopup = true;
            brokenHourglass.itemPools = BrutalAPI.ItemPools.Treasure;
            brokenHourglass.triggerEffects = new EffectsAndTriggerBase[]
            {
                new EffectsAndCustomTriggerPair()
                {
                    customTrigger = LuckyPigmentPatch.LUCKY_PIGMENT_FAILED,
                    effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                        new(ScriptableObject.CreateInstance<LuckyBlueAmountSetEffect>(), 1, null, Slots.Self),
                        new(luckyUp, 1, null, Slots.Self),
                    })
                },
                new EffectsAndCustomTriggerPair()
                {
                    customTrigger = LuckyPigmentPatch.LUCKY_PIGMENT_SUCCESS,
                    effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                        new(ScriptableObject.CreateInstance<LuckyBlueAmountActuallySetEffect>(), 1, null, Slots.Self),
                        new(luckyOne, 0, null, Slots.Self),
                    })
                }
            };

            FoolItemPairs AeliePair = new FoolItemPairs(aelie, brokenHourglass, liquidDust);
            AeliePair.Add();

            
            aelie.AddLevel(13, new Ability[3] { sand0, desiccate0, singing0 }, 0);
            aelie.AddLevel(16, new Ability[3] { sand1, desiccate1, singing1 }, 1);
            aelie.AddLevel(18, new Ability[3] { sand2, desiccate2, singing2 }, 2);
            aelie.AddLevel(20, new Ability[3] { sand3, desiccate3, singing3 }, 3);
            aelie.AddCharacter();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Aelie");
        }
    }
}
