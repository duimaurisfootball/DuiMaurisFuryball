namespace Dui_Mauris_Furyball
{
    public static class Rodney
    {
        public static void Add()

        {

            //custom passives
            PerformEffectPassiveAbility Sacrilege = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            Sacrilege._passiveName = "Sacrilege";
            Sacrilege.type = (PassiveAbilityTypes)873452;
            Sacrilege.passiveIcon = ResourceLoader.LoadSprite("Sacrilege");
            Sacrilege._enemyDescription = "This enemy is cursed.";
            Sacrilege._characterDescription = "This party member is cursed.";
            Sacrilege.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new Effect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, null, Slots.Self)
                });
            Sacrilege._triggerOn = new TriggerCalls[]
                {
                    TriggerCalls.OnCombatStart
                };

            //funny slap damage
            var pokema = ScriptableObject.CreateInstance<DamageEffect>();
            pokema._deathType = DeathType.Slap;

            //custom base ability
            Ability poke = new Ability();
            poke.name = "Evil Poke";
            poke.description = "Deal 1 damage to the opposing enemy. Inflict cursed to the opposing enemy.";
            poke.cost = new ManaColorSO[] { Pigments.Yellow };
            poke.sprite = ResourceLoader.LoadSprite("evilpoke");
            poke.effects = new Effect[]
            {
              new(pokema, 1, IntentType.Damage_1_2, Slots.Front),
              new(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, IntentType.Status_Cursed, Slots.Front),
            };
            poke.animationTarget = Slots.Front;
            poke.visuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;

            //Salad Basics
            Character rodney = new Character();
            Debug.Log("loading");
            rodney.name = "Rodney";
            rodney.healthColor = Pigments.Purple;
            rodney.entityID = (EntityIDs)257141;
            rodney.frontSprite = ResourceLoader.LoadSprite("RodneyFront");
            rodney.backSprite = ResourceLoader.LoadSprite("RodneyBack");
            rodney.overworldSprite = ResourceLoader.LoadSprite("RodneyOverworld", 32, new Vector2(0.5f, 0.02f));
            rodney.lockedSprite = ResourceLoader.LoadSprite("RodneyLocked");
            rodney.unlockedSprite = ResourceLoader.LoadSprite("RodneyMenu");
            rodney.menuChar = true;
            rodney.appearsInShops = true;
            rodney.hurtSound = LoadedAssetsHandler.GetCharcater("Clive_CH").damageSound;
            rodney.deathSound = LoadedAssetsHandler.GetCharcater("Clive_CH").deathSound;
            rodney.dialogueSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").damageSound;
            rodney.baseAbility = poke;
            rodney.isSupport = true;
            rodney.levels = new CharacterRankedData[4];
            rodney.passives = new BasePassiveAbilitySO[]
            {
                Sacrilege
            };

            //rotation checks
            var removeCurse = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            removeCurse._statusToRemove = StatusEffectType.Cursed;

            var applyCurse = ScriptableObject.CreateInstance<ApplyCursedEffect>();

            var leftCursed = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            leftCursed.previousAmount = new int[] { 1, 2 };
            leftCursed.wasSuccessful = new bool[] { false, true };

            var selfCursed = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            selfCursed.previousAmount = new int[] { 2, 3 };
            selfCursed.wasSuccessful = new bool[] { true, false };

            var noneCursed = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            noneCursed.previousAmount = new int[] { 3, 4 };
            noneCursed.wasSuccessful = new bool[] { false, false };

            var bothCursed = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            bothCursed.previousAmount = new int[] { 4, 5 };
            bothCursed.wasSuccessful = new bool[] { true, true };

            var leftPresent1 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            leftPresent1.previousAmount = 2;


            //curse check and refresh for veneration
            var checkCursed = ScriptableObject.CreateInstance<StatusEffectCheckerEffect>();
            checkCursed._statusEffectCheck = StatusEffectType.Cursed;

            var basicPrevious = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            basicPrevious.wasSuccessful = true;


            //rotation
            Ability rotation0 = new Ability();
            rotation0.name = "Sick Rotation";
            rotation0.description = "Exchange cursed with the left party member. If both are cursed, remove cursed from the left party member. If neither is cursed or there is no left party member, inflict cursed to self.";
            rotation0.cost = new ManaColorSO[] { Pigments.Blue, Pigments.Blue };
            rotation0.sprite = ResourceLoader.LoadSprite("rotation");
            rotation0.effects = new Effect[]
            {
              new(ScriptableObject.CreateInstance<CheckHasUnitEffect>(), 0, null, Slots.SlotTarget(new int[] { -1 }, true)),
              new(removeCurse, 0, IntentType.Rem_Status_Cursed, Slots.SlotTarget(new int[] { -1 }, true), ScriptableObject.CreateInstance<PreviousEffectCondition>()), //try remove from left
              new(removeCurse, 0, IntentType.Rem_Status_Cursed, Slots.SlotTarget(new int[] { 0 }, true), leftPresent1), //try remove from self

              new(applyCurse, 0, IntentType.Status_Cursed, Slots.SlotTarget(new int[] { 0 }, true), leftCursed), //if only left was cursed, curse self

              new(applyCurse, 0, IntentType.Status_Cursed, Slots.SlotTarget(new int[] { -1 }, true), selfCursed), //if only self was cursed, curse left

              new(applyCurse, 0, null, Slots.SlotTarget(new int[] { 0 }, true), noneCursed), //if none were cursed, curse self

              new(applyCurse, 0, null, Slots.SlotTarget(new int[] { 0 }, true), bothCursed), //if both were cursed, curse self
              new(ScriptableObject.CreateInstance<RefreshAbilityUseOnChanceEffect>(), 0, null, Slots.Self)
            };
            rotation0.animationTarget = Slots.SlotTarget(new int[] { -1 }, true);
            rotation0.visuals = LoadedAssetsHandler.GetEnemyAbility("ThePact_A").visuals;

            Ability rotation1 = rotation0.Duplicate();
            rotation1.name = "Blight Rotation";
            rotation1.description = "Exchange cursed with the left party member. If both are cursed, remove cursed from the left party member. If neither is cursed or there is no left party member, inflict cursed to self. 3% chance to refresh this party member.";
            rotation1.effects[7] = new(ScriptableObject.CreateInstance<RefreshAbilityUseOnChanceEffect>(), 3, IntentType.Other_Refresh, Slots.Self);


            Ability rotation2 = rotation1.Duplicate();
            rotation2.name = "Dead Rotation";
            rotation2.description = "Exchange cursed with the left party member. If both are cursed, remove cursed from the left party member. If neither is cursed or there is no left party member, inflict cursed to self. 5% chance to refresh this party member.";
            rotation1.effects[7] = new Effect(ScriptableObject.CreateInstance<RefreshAbilityUseOnChanceEffect>(), 5, IntentType.Other_Refresh, Slots.Self);


            Ability rotation3 = rotation2.Duplicate();
            rotation3.name = "Skeletal Rotation";
            rotation3.description = "Exchange cursed with the left party member. If both are cursed, remove cursed from the left party member. If neither is cursed or there is no left party member, inflict cursed to self. 7% chance to refresh this party member.";
            rotation1.effects[7] = new Effect(ScriptableObject.CreateInstance<RefreshAbilityUseOnChanceEffect>(), 7, IntentType.Other_Refresh, Slots.Self);


            //tribulation
            Ability tribulation0 = new Ability();
            tribulation0.name = "Little Tribulation";
            tribulation0.description = "Heal the right ally 7. Inflict curse to right ally.";
            tribulation0.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red };
            tribulation0.sprite = ResourceLoader.LoadSprite("tribulation");
            tribulation0.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<HealEffect>(), 7, IntentType.Heal_5_10, Slots.SlotTarget(new int[] { 1 }, true)),
                    new(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, IntentType.Status_Cursed, Slots.SlotTarget(new int[] { 1 }, true)),
                };
            tribulation0.animationTarget = Slots.SlotTarget(new int[] { 1 }, true);
            tribulation0.visuals = LoadedAssetsHandler.GetCharacterAbility("PressurePoint_1_A").visuals;

            Ability tribulation1 = tribulation0.Duplicate();
            tribulation1.name = "Ring Tribulation";
            tribulation1.description = "Heal the right ally 10. Inflict curse to right ally.";
            tribulation1.effects[0]._entryVariable = 10;

            Ability tribulation2 = tribulation1.Duplicate();
            tribulation2.name = "Middle Tribulation";
            tribulation2.description = "Heal the right ally 13. Inflict curse to right ally.";
            tribulation2.effects[0]._entryVariable = 13;
            tribulation2.effects[0]._intent = IntentType.Heal_11_20;

            Ability tribulation3 = tribulation2.Duplicate();
            tribulation3.name = "Index Tribulation";
            tribulation3.description = "Heal the right ally 16. Inflict curse to right ally.";
            tribulation3.effects[0]._entryVariable = 16;


            //veneration
            Ability veneration0 = new Ability();
            veneration0.name = "Distant Veneration";
            veneration0.description = "Heal the right ally 2. If the right ally is cursed, refresh them.";
            veneration0.cost = new ManaColorSO[] { Pigments.Red, Pigments.Blue };
            veneration0.sprite = ResourceLoader.LoadSprite("veneration");
            veneration0.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<HealEffect>(), 2, IntentType.Heal_1_4, Slots.SlotTarget(new int[] { 1 }, true)),
                    new(checkCursed, 0, null, Slots.SlotTarget(new int[] { 1 }, true)),
                    new(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, IntentType.Other_Refresh, Slots.SlotTarget(new int[] { 1 }, true), basicPrevious),
                };
            veneration0.animationTarget = Slots.SlotTarget(new int[] { 1 }, true);
            veneration0.visuals = LoadedAssetsHandler.GetCharacterAbility("Blow_1_A").visuals;
                
            Ability veneration1 = veneration0.Duplicate();
            veneration1.name = "Guiding Veneration";
            veneration1.description = "Heal the right ally 3. If the right ally is cursed, refresh them.";
            veneration1.effects[0]._entryVariable = 3;
            veneration1.effects[0]._intent = IntentType.Heal_5_10;

            Ability veneration2 = veneration1.Duplicate();
            veneration2.name = "Pointing Veneration";
            veneration2.description = "Heal the right ally 4. If the right ally is cursed, refresh them.";
            veneration2.effects[0]._entryVariable = 4;

            Ability veneration3 = veneration2.Duplicate();
            veneration3.name = "Feeling Veneration";
            veneration3.description = "Heal the right ally 6. If the right ally is cursed, refresh them.";
            veneration3.effects[0]._entryVariable = 6;

            //
            //
            //

            var previops0 = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            previops0.wasSuccessful = new bool[] { true, true, true };
            previops0.previousAmount = new int[] { 1, 2, 3 };

            var previops1 = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            previops1.wasSuccessful = new bool[] { true, true, true };
            previops1.previousAmount = new int[] { 1, 3 };

            var previops2 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previops2.previousAmount = 4;

            var ribcage = new DoubleEffectItem();
            ribcage.name = "Kagla's Ribcage";
            ribcage.flavorText = "\"HOOOGHA! HOOUUGHA! AAAAAAA-HAHAHAHA!!\"";
            ribcage.description = "This party member is cursed. Upon this party member using an ability while cursed, there is a 40% chance to refresh all cursed party members.";
            ribcage.sprite = ResourceLoader.LoadSprite("KaglasRibcage", 1, null);
            ribcage.unlockableID = (UnlockableID)589991;
            ribcage.itemPools = BrutalAPI.ItemPools.Treasure;
            ribcage.firstPopUp = true;
            ribcage.trigger = TriggerCalls.OnCombatStart;
            ribcage.firstEffects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, null, Slots.Self),
            };
            ribcage.secondPopUp = false;
            ribcage.SecondTrigger = new TriggerCalls[]
            {
                TriggerCalls.OnAbilityUsed,
            };
            ribcage.secondEffects = new Effect[]
            {
                //self
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, Conditions.Chance(40)),
                new(ScriptableObject.CreateInstance<PopUpCasterItemInfoEffect>(), 1, null, Slots.Self, ScriptableObject.CreateInstance<PreviousEffectCondition>()),
                new(checkCursed, 1, null, Slots.Self),
                new(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, null, Slots.Self, previops1),

                //left
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, previops2),
                new(checkCursed, 1, null, Slots.Self),
                new(checkCursed, 1, null, Slots.SlotTarget(new int[] { -1 }, true)),
                new(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, null, Slots.SlotTarget(new int[] { -1 }, true), previops0),

                //far left
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, previops2),
                new(checkCursed, 1, null, Slots.Self),
                new(checkCursed, 1, null, Slots.SlotTarget(new int[] { -2 }, true)),
                new(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, null, Slots.SlotTarget(new int[] { -2 }, true), previops0),

                //far far left
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, previops2),
                new(checkCursed, 1, null, Slots.Self),
                new(checkCursed, 1, null, Slots.SlotTarget(new int[] { -3 }, true)),
                new(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, null, Slots.SlotTarget(new int[] { -3 }, true), previops0),

                //very far left
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, previops2),
                new(checkCursed, 1, null, Slots.Self),
                new(checkCursed, 1, null, Slots.SlotTarget(new int[] { -4 }, true)),
                new(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, null, Slots.SlotTarget(new int[] { -4 }, true), previops0),

                //right
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, previops2),
                new(checkCursed, 1, null, Slots.Self),
                new(checkCursed, 1, null, Slots.SlotTarget(new int[] { 1 }, true)),
                new(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, null, Slots.SlotTarget(new int[] { 1 }, true), previops0),

                //far right
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, previops2),
                new(checkCursed, 1, null, Slots.Self),
                new(checkCursed, 1, null, Slots.SlotTarget(new int[] { 2 }, true)),
                new(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, null, Slots.SlotTarget(new int[] { 2 }, true), previops0),

                //far far right
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, previops2),
                new(checkCursed, 1, null, Slots.Self),
                new(checkCursed, 1, null, Slots.SlotTarget(new int[] { 3 }, true)),
                new(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, null, Slots.SlotTarget(new int[] { 3 }, true), previops0),

                //very far right
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, previops2),
                new(checkCursed, 1, null, Slots.Self),
                new(checkCursed, 1, null, Slots.SlotTarget(new int[] { 4 }, true)),
                new(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, null, Slots.SlotTarget(new int[] { 4 }, true), previops0),
            };

            //
            //
            //

            var leftLeg = new DoubleEffectItem();
            leftLeg.name = "Kagla's Left Leg";
            leftLeg.flavorText = "\"RUN, COWARD!\"";
            leftLeg.description = "This party member is cursed. Upon this party member being moved while cursed, there is a 40% refresh the movement of all cursed party members.";
            leftLeg.sprite = ResourceLoader.LoadSprite("KaglasLeftLeg", 1, null);
            leftLeg.unlockableID = (UnlockableID)589992;
            leftLeg.itemPools = BrutalAPI.ItemPools.Treasure;
            leftLeg.firstPopUp = true;
            leftLeg.trigger = TriggerCalls.OnCombatStart;
            leftLeg.firstEffects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, null, Slots.Self),
            };
            leftLeg.secondPopUp = false;
            leftLeg.SecondTrigger = new TriggerCalls[]
            {
                TriggerCalls.OnMoved,
            };
            leftLeg.secondEffects = new Effect[]
            {
                //self
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, Conditions.Chance(40)),
                new(ScriptableObject.CreateInstance<PopUpCasterItemInfoEffect>(), 1, null, Slots.Self, ScriptableObject.CreateInstance<PreviousEffectCondition>()),
                new(checkCursed, 1, null, Slots.Self),
                new(ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, null, Slots.Self, previops1),

                //left
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, previops2),
                new(checkCursed, 1, null, Slots.Self),
                new(checkCursed, 1, null, Slots.SlotTarget(new int[] { -1 }, true)),
                new(ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, null, Slots.SlotTarget(new int[] { -1 }, true), previops0),

                //far left
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, previops2),
                new(checkCursed, 1, null, Slots.Self),
                new(checkCursed, 1, null, Slots.SlotTarget(new int[] { -2 }, true)),
                new(ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, null, Slots.SlotTarget(new int[] { -2 }, true), previops0),

                //far far left
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, previops2),
                new(checkCursed, 1, null, Slots.Self),
                new(checkCursed, 1, null, Slots.SlotTarget(new int[] { -3 }, true)),
                new(ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, null, Slots.SlotTarget(new int[] { -3 }, true), previops0),

                //very far left
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, previops2),
                new(checkCursed, 1, null, Slots.Self),
                new(checkCursed, 1, null, Slots.SlotTarget(new int[] { -4 }, true)),
                new(ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, null, Slots.SlotTarget(new int[] { -4 }, true), previops0),

                //right
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, previops2),
                new(checkCursed, 1, null, Slots.Self),
                new(checkCursed, 1, null, Slots.SlotTarget(new int[] { 1 }, true)),
                new(ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, null, Slots.SlotTarget(new int[] { 1 }, true), previops0),

                //far right
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, previops2),
                new(checkCursed, 1, null, Slots.Self),
                new(checkCursed, 1, null, Slots.SlotTarget(new int[] { 2 }, true)),
                new(ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, null, Slots.SlotTarget(new int[] { 2 }, true), previops0),

                //far far right
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, previops2),
                new(checkCursed, 1, null, Slots.Self),
                new(checkCursed, 1, null, Slots.SlotTarget(new int[] { 3 }, true)),
                new(ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, null, Slots.SlotTarget(new int[] { 3 }, true), previops0),

                //very far right
                new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, previops2),
                new(checkCursed, 1, null, Slots.Self),
                new(checkCursed, 1, null, Slots.SlotTarget(new int[] { 4 }, true)),
                new(ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, null, Slots.SlotTarget(new int[] { 4 }, true), previops0),
            };

            FoolItemPairs RodneyPair = new FoolItemPairs(rodney, ribcage, leftLeg);
            RodneyPair.Add();


            Debug.Log("loading");
            rodney.AddLevel(30, new Ability[3] { tribulation0, rotation0, veneration0 }, 0);
            rodney.AddLevel(35, new Ability[3] { tribulation1, rotation1, veneration1 }, 1);
            rodney.AddLevel(40, new Ability[3] { tribulation2, rotation2, veneration2 }, 2);
            rodney.AddLevel(45, new Ability[3] { tribulation3, rotation3, veneration3 }, 3);
            rodney.AddCharacter();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Rodney");

        }
        public static string AddStoredValueName(
            Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
            TooltipTextHandlerSO self, UnitStoredValueNames storedValue, int value)
        {
            string str1;
            if (storedValue == (UnitStoredValueNames)229382)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "You shouldnt be seeing this" + string.Format(" +{0}", (object)value);
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
