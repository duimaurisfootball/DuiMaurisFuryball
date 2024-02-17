namespace Dui_Mauris_Furyball
{
    public class Gomma
    {
        public static void Add()

        {
            //stored values for leaky
            var WartinessUp = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            WartinessUp._increase = true;
            WartinessUp._valueName = (UnitStoredValueNames)873289;

            var wartCheck = ScriptableObject.CreateInstance<CasterStoreValueCheckEffect>();
            wartCheck._valueName = (UnitStoredValueNames)873289;

            //custom passives
            PerformEffectPassiveAbility Warts2 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            Warts2._passiveName = "Warts (2)";
            Warts2.type = (PassiveAbilityTypes)2225151;
            Warts2.passiveIcon = ResourceLoader.LoadSprite("warts");
            Warts2._enemyDescription = "Upon receiving direct damage, this enemy will apply shield to their position equivalent to their current amount of Warts.";
            Warts2._characterDescription = "Upon receiving direct damage, this character will apply shield to their position equivalent to their current amount of Warts.";
            Warts2.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new(wartCheck, 1, null, Slots.Self),
                    new(ScriptableObject.CreateInstance<ApplyShieldFromPreviousAddEntryEffect>(), 2, null, Slots.Self)
                });
            Warts2._triggerOn = new TriggerCalls[]
                {
                    TriggerCalls.OnDirectDamaged
                };


            //Spoogle Basics
            Character gomma = new Character();
            
            gomma.name = "Gomma";
            gomma.healthColor = Pigments.Yellow;
            gomma.entityID = (EntityIDs)55155115;
            gomma.frontSprite = ResourceLoader.LoadSprite("GommaFront");
            gomma.backSprite = ResourceLoader.LoadSprite("GommaBack");
            gomma.overworldSprite = ResourceLoader.LoadSprite("GommaOverworld", 32, new Vector2(0.5f, 0.02f));
            gomma.lockedSprite = ResourceLoader.LoadSprite("GommaMenu");
            gomma.unlockedSprite = ResourceLoader.LoadSprite("GommaMenu");
            gomma.menuChar = true;
            gomma.appearsInShops = true;
            gomma.hurtSound = LoadedAssetsHandler.GetCharcater("Pearl_CH").dxSound;
            gomma.deathSound = LoadedAssetsHandler.GetCharcater("Pearl_CH").deathSound;
            gomma.dialogueSound = LoadedAssetsHandler.GetCharcater("Pearl_CH").dxSound;
            gomma.isSupport = true;
            gomma.passives = new BasePassiveAbilitySO[]
            {
                Warts2
            };

            IDetour Wartiness = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(Gomma).GetMethod("AddStoredValueName", ~BindingFlags.Default));

            //forest
            Ability forest0 = new Ability();
            forest0.name = "Tiny Forest";
            forest0.description = "Apply 3 shield to the lowest health party members(s). Increase Warts by 1.";
            forest0.cost = new ManaColorSO[] { Pigments.Yellow };
            forest0.sprite = ResourceLoader.LoadSprite("forest");
            forest0.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<ApplyShieldByWeakestEffect>(), 3, IntentType.Field_Shield, Slots.SlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true)),
                    new(WartinessUp, 1, IntentType.Misc_State_Stand, Slots.Self),
                };
            forest0.animationTarget = Slots.Self;
            forest0.visuals = LoadedAssetsHandler.GetCharacterAbility("Impenetrable_1_A").visuals;


            Ability forest1 = forest0.Duplicate();
            forest1.name = "Black Forest";
            forest1.description = "Apply 6 shield to the lowest health party members(s). Increase Warts by 2.";
            forest1.effects[0]._entryVariable = 6;
            forest1.effects[1]._entryVariable = 2;

            Ability forest2 = forest1.Duplicate();
            forest2.name = "Burning Forest";
            forest2.description = "Apply 8 shield to the lowest health party members(s). Increase Warts by 2.";
            forest2.effects[0]._entryVariable = 8;

            Ability forest3 = forest2.Duplicate();
            forest3.name = "Ashen Forest";
            forest3.description = "Apply 10 shield to the lowest health party members(s). Increase Warts by 3.";
            forest3.effects[0]._entryVariable = 10;
            forest3.effects[1]._entryVariable = 3;

            //scales
            Ability scales0 = new Ability();
            scales0.name = "Budding Scales";
            scales0.description = "Apply 0-8 shield to the Left position. Increase Warts by 1.";
            scales0.cost = new ManaColorSO[] { Pigments.Blue, Pigments.Yellow };
            scales0.sprite = ResourceLoader.LoadSprite("scales");
            scales0.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, null, Slots.Self),
                    new(ScriptableObject.CreateInstance<ApplyRandomShieldBetweenPreviousAndEntryEffect>(), 8, IntentType.Field_Shield, Slots.SlotTarget(new int[] { -1 }, true)),
                    new(WartinessUp, 1, IntentType.Misc_State_Stand, Slots.Self),
                };
            scales0.animationTarget = Slots.SlotTarget(new int[] { -1 }, true);
            scales0.visuals = LoadedAssetsHandler.GetCharacterAbility("Form_1_A").visuals;

            Ability scales1 = scales0.Duplicate();
            scales1.name = "Propagating Scales";
            scales1.description = "Apply 1-11 shield to the Left position. Increase Warts by 2.";
            scales1.effects[0]._entryVariable = 1;
            scales1.effects[1]._entryVariable = 11;
            scales1.effects[2]._entryVariable = 2;

            Ability scales2 = scales1.Duplicate();
            scales2.name = "Human Scales";
            scales2.description = "Apply 1-17 shield to the Left position. Increase Warts by 2.";
            scales2.effects[1]._entryVariable = 17;

            Ability scales3 = scales2.Duplicate();
            scales3.name = "Lifelong Scales";
            scales3.description = "Apply 1-21 shield to the Left position. Increase Warts by 3.";
            scales3.effects[1]._entryVariable = 21;
            scales3.effects[2]._entryVariable = 3;


            //smoke
            Ability smoke0 = new Ability();
            smoke0.name = "White Smoke";
            smoke0.description = "Deal 2 direct damage to this party member. Heal this party member 1 health. 20% chance to refresh the Left ally.";
            smoke0.cost = new ManaColorSO[] { Pigments.Yellow, Pigments.Blue };
            smoke0.sprite = ResourceLoader.LoadSprite("smoke");
            smoke0.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<DamageEffect>(), 2, IntentType.Damage_1_2, Slots.Self),
                    new(ScriptableObject.CreateInstance<HealEffect>(), 1, IntentType.Heal_1_4, Slots.Self),
                    new(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, IntentType.Other_Refresh, Slots.SlotTarget(new int[] { -1 }, true), Conditions.Chance(20)),
                };
            smoke0.animationTarget = Slots.Self;
            smoke0.visuals = LoadedAssetsHandler.GetCharacterAbility("Quills_1_A").visuals;

            Ability smoke1 = smoke0.Duplicate();
            smoke1.name = "Gray Smoke";
            smoke1.description = "Deal 2 direct damage to this party member. Heal this party member 1 health. 30% chance to refresh the Left ally.";
            smoke1.effects[2]._condition = Conditions.Chance(30);

            Ability smoke2 = smoke1.Duplicate();
            smoke2.name = "Brown Smoke";
            smoke2.description = "Deal 2 direct damage to this party member. Heal this party member 1 health. 40% chance to refresh the Left ally.";
            smoke2.effects[2]._condition = Conditions.Chance(40);

            Ability smoke3 = smoke2.Duplicate();
            smoke3.name = "Black Smoke";
            smoke3.description = "Deal 1 direct damage to this party member. Heal this party member 1 health. 50% chance to refresh the Left ally.";
            smoke3.effects[0]._entryVariable = 1;
            smoke3.effects[2]._condition = Conditions.Chance(50);

            //
            //
            //

            var indirectDamage = ScriptableObject.CreateInstance<DamageEffect>();
            indirectDamage._indirect = true;

            var complexComplexion = new EffectItem();
            complexComplexion.name = "Complex Complexion";
            complexComplexion.flavorText = "\"No part of you wants to be smooth.\"";
            complexComplexion.description = "Upon taking direct damage, deal 5 indirect damage to the Opposing enemy, apply 4 shield to this party member's position, and heal the Left and Right allies 5.";
            complexComplexion.sprite = ResourceLoader.LoadSprite("BoneAndSkin", 1, null);
            complexComplexion.unlockableID = (UnlockableID)00828423;
            complexComplexion.namePopup = true;
            complexComplexion.itemPools = BrutalAPI.ItemPools.Treasure;
            complexComplexion.trigger = TriggerCalls.OnDirectDamaged;
            complexComplexion.effects = new Effect[]
            {
                new(indirectDamage, 5, null, Slots.Front),
                new(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 4, null, Slots.Self),
                new(ScriptableObject.CreateInstance<HealEffect>(), 5, null, Slots.SlotTarget(new int[] { -1, 1 }, true)),
            };

            //
            //
            //

            var countSpurs = ScriptableObject.CreateInstance<CasterStoreValueCheckEffect>();
            countSpurs._valueName = (UnitStoredValueNames)873290;

            var countWarts = ScriptableObject.CreateInstance<CasterStoreValueCheckEffect>();
            countWarts._valueName = (UnitStoredValueNames)873291;

            var Spurs2 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            Spurs2._passiveName = "Bone Spurs (2)";
            Spurs2.type = (PassiveAbilityTypes)2225153;
            Spurs2.passiveIcon = ResourceLoader.LoadSprite("bonespurscopy");
            Spurs2._enemyDescription = "Upon receiving direct damage this enemy will deal indirect damage to the Opposing enemy equivalent to their current amount of Bone Spurs.";
            Spurs2._characterDescription = "Upon receiving direct damage this party member will deal indirect damage to the Opposing enemy equivalent to their current amount of Bone Spurs.";
            Spurs2.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new(countSpurs, 1, null, Slots.Self),
                    new(ScriptableObject.CreateInstance<IndirectDamageFromPreviousAddEntryEffect>(), 2, null, Slots.Front),
                });
            Spurs2._triggerOn = new TriggerCalls[]
                {
                    TriggerCalls.OnDirectDamaged
                };

            var Warts2b = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            Warts2b._passiveName = "Warts (2)";
            Warts2b.type = (PassiveAbilityTypes)2225151;
            Warts2b.passiveIcon = ResourceLoader.LoadSprite("warts");
            Warts2b._enemyDescription = "Upon receiving direct damage, this enemy will apply shield to their position equivalent to their current amount of Warts.";
            Warts2b._characterDescription = "Upon receiving direct damage, this character will apply shield to their position equivalent to their current amount of Warts.";
            Warts2b.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new(countWarts, 1, null, Slots.Self),
                    new(ScriptableObject.CreateInstance<ApplyShieldFromPreviousAddEntryEffect>(), 2, null, Slots.Self)
                });
            Warts2b._triggerOn = new TriggerCalls[]
                {
                    TriggerCalls.OnDirectDamaged
                };

            var SpursBip = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            SpursBip._increase = true;
            SpursBip._valueName = (UnitStoredValueNames)873290;

            var WartBip = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            WartBip._increase = true;
            WartBip._valueName = (UnitStoredValueNames)873291;

            var spurBing = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            spurBing._extraPassiveAbility = Spurs2;

            var wartBing = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            wartBing._extraPassiveAbility = Warts2b;

            IDetour WartIteminess = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(ComplexionWartsStoredValue).GetMethod("AddStoredValueName", ~BindingFlags.Default));
            IDetour SpurIteminess = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(ComplexionBoneSpursStoredValue).GetMethod("AddStoredValueName", ~BindingFlags.Default));

            var gumpMuckGoa = new DoubleEffectItem();
            gumpMuckGoa.name = "Gump Muck Goa";
            gumpMuckGoa.flavorText = "\"The result of one too many tossed car batteries...\"";
            gumpMuckGoa.description = "This party member now has Bone Spurs (2) and Warts (2) as passives. Increase Bone Spurs and Warts at the end of every turn and upon taking damage.";
            gumpMuckGoa.sprite = ResourceLoader.LoadSprite("GunkMingGoa", 1, null);
            gumpMuckGoa.unlockableID = (UnlockableID)00828424;
            gumpMuckGoa.namePopup = true;
            gumpMuckGoa.itemPools = BrutalAPI.ItemPools.Treasure;
            gumpMuckGoa.fishRarity = 3;
            gumpMuckGoa._secondImmediateEffect = true;
            gumpMuckGoa.SecondTrigger = new TriggerCalls[]
            {
                TriggerCalls.OnTurnFinished,
                TriggerCalls.OnDamaged,
            };
            gumpMuckGoa.secondEffects = new Effect[]
            {
                new(SpursBip, 1, null, Slots.Self),
                new(WartBip, 1, null, Slots.Self),
            };
            gumpMuckGoa.equippedModifiers = new WearableStaticModifierSetterSO[]
            {
                spurBing,
                wartBing,
            };

            FoolItemPairs GommaPair = new FoolItemPairs(gomma, complexComplexion, gumpMuckGoa);
            GommaPair.Add();

            
            gomma.AddLevel(12, new Ability[3] { scales0, forest0, smoke0 }, 0);
            gomma.AddLevel(15, new Ability[3] { scales1, forest1, smoke1 }, 1);
            gomma.AddLevel(19, new Ability[3] { scales2, forest2, smoke2 }, 2);
            gomma.AddLevel(24, new Ability[3] { scales3, forest3, smoke3 }, 3);
            gomma.AddCharacter();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Gomma");

        }

        public static string AddStoredValueName(
            Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
            TooltipTextHandlerSO self, UnitStoredValueNames storedValue, int value)
        {
            Color yellow = Color.yellow;
            string str1;
            if (storedValue == (UnitStoredValueNames)873289)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Warts" + string.Format(" +{0}", (object)value);
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
