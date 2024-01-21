using Dui_Mauris_Furyball.CustomEffects;

namespace Dui_Mauris_Furyball
{
    public static class Vat
    {
        public static void Add()

        {
            //humorous effect
            var sanguineColor = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
            sanguineColor._healthColors = new ManaColorSO[] { Pigments.Red };

            //evil stored value for custom sprites
            var vatChanger = ScriptableObject.CreateInstance<CasterStoreValueSetterEffect>();
            vatChanger._valueName = (UnitStoredValueNames)820141;
            var vatChecker = ScriptableObject.CreateInstance<CheckStoredValueNumberToBoolEffect>();
            vatChecker._valueName = (UnitStoredValueNames)820141;

            //does it really running isn't become but is for more common is like
            var checkValuePrev0 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            checkValuePrev0.previousAmount = 1;
            checkValuePrev0.wasSuccessful = true;
            var checkValuePrev1 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            checkValuePrev1.previousAmount = 2;
            checkValuePrev1.wasSuccessful = true;
            var checkValuePrev2 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            checkValuePrev2.previousAmount = 3;
            checkValuePrev2.wasSuccessful = true;

            //sprites
            ExtraCCSprites_ArraySO messySprites = ScriptableObject.CreateInstance<ExtraCCSprites_ArraySO>();
            messySprites._useDefault = ExtraSpriteType.None;
            messySprites._doesLoop = true;
            messySprites._useSpecial = (ExtraSpriteType)827321;
            messySprites._frontSprite = new Sprite[]
            {
                ResourceLoader.LoadSprite("VatFrontPhlegma", 1, null),
                ResourceLoader.LoadSprite("VatFrontMelancholy", 1, null),
                ResourceLoader.LoadSprite("VatFrontCholeric", 1, null),
                ResourceLoader.LoadSprite("VatFrontSanguine", 1, null),
            };
            messySprites._backSprite = new Sprite[]
            {
                ResourceLoader.LoadSprite("VatBackPhlegma", 1, null),
                ResourceLoader.LoadSprite("VatBackMelancholy", 1, null),
                ResourceLoader.LoadSprite("VatBackCholeric", 1, null),
                ResourceLoader.LoadSprite("VatBackSanguine", 1, null),
            };
            SetCasterExtraSpritesEffect setVatSprites = ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>();
            setVatSprites._spriteType = (ExtraSpriteType)827321;
            

            //custom passives
            //leaky (2)
            PerformEffectPassiveAbility leaky2 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            leaky2._passiveName = "Leaky (2)";
            leaky2.type = (PassiveAbilityTypes)873476;
            leaky2.passiveIcon = Passives.Leaky.passiveIcon;
            leaky2._enemyDescription = "IM KILLING YOU";
            leaky2._characterDescription = "Upon receiving damage this party member produces additional Pigment. ";
            leaky2.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new(ScriptableObject.CreateInstance<GenerateCasterHealthManaEffect>(), 2, null, Slots.Self),
                });
            leaky2._triggerOn = new TriggerCalls[]
                {
                    TriggerCalls.OnDirectDamaged
                };

            //Humorous
            PerformEffectPassiveAbility Humorous = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            Humorous._passiveName = "Humorous";
            Humorous.type = (PassiveAbilityTypes)873477;
            Humorous.passiveIcon = ResourceLoader.LoadSprite("humorous");
            Humorous._enemyDescription = "haha this ones got sprite changes so dont use it for enemies bro";
            Humorous._characterDescription = "Upon taking damage, this party member's health will change to red.";
            Humorous.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    //red check
                    //AAAAAAAAAHHHHHH HES RED :D :DDD

                    //blue check
                    new(vatChecker, 1, null, Slots.Self),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev0),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev1),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev2),

                    //purple check
                    new(vatChecker, 2, null, Slots.Self),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev0),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev1),

                    //yellow check
                    new(vatChecker, 3, null, Slots.Self),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev0),

                    //actual effect
                    new(sanguineColor, 1, null, Slots.Self),

                    //change sprite value to 0 (red)
                    new(vatChanger, 0, null, Slots.Self),
                });
            Humorous._triggerOn = new TriggerCalls[]
                {
                    TriggerCalls.OnDirectDamaged
                };

            //custom base ability check
            var Brevious = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            Brevious.wasSuccessful = false;

            

            //custom base ability
            Ability apoptosis = new Ability();
            apoptosis.name = "Microapoptosis";
            apoptosis.description = "Deal 2 or 7 damage to this party member. Heal all other party members 5.";
            apoptosis.cost = new ManaColorSO[] { Pigments.Yellow };
            apoptosis.sprite = ResourceLoader.LoadSprite("vesicle");
            apoptosis.effects = new Effect[]
            {
              new(ScriptableObject.CreateInstance<DamageEffect>(), 7, IntentType.Damage_7_10, Slots.Self, Conditions.Chance(50)),
              new(ScriptableObject.CreateInstance<DamageEffect>(), 2, IntentType.Damage_1_2, Slots.Self, Brevious),
              new(ScriptableObject.CreateInstance<HealEffect>(), 5, IntentType.Heal_1_4, Slots.SlotTarget(new int[] { -5, -4, -3, -2, -1, 1, 2, 3, 4, 5}, true))
            };
            apoptosis.animationTarget = Slots.Self;
            apoptosis.visuals = LoadedAssetsHandler.GetEnemyAbility("HeartBreaker_A").visuals;


            //Vat Basics
            Character vat = new Character();
            Debug.Log("loading");
            vat.name = "Vat";
            vat.healthColor = Pigments.Red;
            vat.entityID = (EntityIDs)257996;
            vat.frontSprite = ResourceLoader.LoadSprite("VatFrontSanguine");
            vat.backSprite = ResourceLoader.LoadSprite("VatBackSanguine");
            vat.overworldSprite = ResourceLoader.LoadSprite("VatOverworld", 32, new Vector2(0.5f, 0.02f));
            vat.lockedSprite = ResourceLoader.LoadSprite("VatLocked");
            vat.unlockedSprite = ResourceLoader.LoadSprite("VatMenu");
            vat.menuChar = true;
            vat.appearsInShops = true;
            vat.hurtSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").damageSound;
            vat.deathSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").deathSound;
            vat.dialogueSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").damageSound;
            vat.baseAbility = apoptosis;
            vat.isSupport = true;
            vat.levels = new CharacterRankedData[1];
            vat.extraSprites = messySprites;
            vat.extraSprites = messySprites;
            vat.extraSprites = messySprites;
            vat.extraSprites = messySprites;
            vat.passives = new BasePassiveAbilitySO[]
            {
                leaky2,
                Humorous
            };

            //check for health color change
            var basicPrevious = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            basicPrevious.wasSuccessful = true;

            //health color changes
            var phlegmaticColor = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
            phlegmaticColor._healthColors = new ManaColorSO[] { Pigments.Blue };
            var melancholyColor = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
            melancholyColor._healthColors = new ManaColorSO[] { Pigments.Purple };
            var cholericColor = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
            cholericColor._healthColors = new ManaColorSO[] { Pigments.Yellow };


            //golgibody
            Ability golgiBody = new Ability();
            golgiBody.name = "Golgi Body";
            golgiBody.description = "Change this party member's health to blue. If successful, heal 7.";
            golgiBody.cost = new ManaColorSO[] { Pigments.Red };
            golgiBody.sprite = ResourceLoader.LoadSprite("golgi");
            golgiBody.effects = new Effect[]
                {
                    //red check
                    new(vatChecker, 0, null, Slots.Self),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev0),

                    //blue check
                    //bluema? what's bluema?

                    //purple check
                    new(vatChecker, 2, null, Slots.Self),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev0),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev1),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev2),

                    //yellow check
                    new(vatChecker, 3, null, Slots.Self),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev0),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev1),

                    //actual effect
                    new(phlegmaticColor, 1, IntentType.Mana_Modify, Slots.Self),
                    new(ScriptableObject.CreateInstance<HealEffect>(), 7, IntentType.Heal_1_4, Slots.Self, basicPrevious),

                    //change sprite value to 1 (blue)
                    new(vatChanger, 1, null, Slots.Self),
                };
            golgiBody.animationTarget = Slots.Self;
            golgiBody.visuals = LoadedAssetsHandler.GetCharacterAbility("Hex_1_A").visuals;


            //nucleus
            Ability nucleolusMove = new Ability();
            nucleolusMove.name = "Nucleolus";
            nucleolusMove.description = "Change this party member's health to purple. If successful, heal 7.";
            nucleolusMove.cost = new ManaColorSO[] { Pigments.Red };
            nucleolusMove.sprite = ResourceLoader.LoadSprite("nucleolus");
            nucleolusMove.effects = new Effect[]
                {
                    //red check
                    new(vatChecker, 0, null, Slots.Self),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev0),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev1),

                    //blue check
                    new(vatChecker, 1, null, Slots.Self),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev0),

                    //purple check
                    //supposedly this man is already purple do why bother

                    //yellow check
                    new(vatChecker, 3, null, Slots.Self),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev0),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev1),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev2),

                    //actual effect
                    new(melancholyColor, 1, IntentType.Mana_Modify, Slots.Self),
                    new(ScriptableObject.CreateInstance<HealEffect>(), 7, IntentType.Heal_1_4, Slots.Self, basicPrevious),

                    //change sprite value to 2 (purple)
                    new(vatChanger, 2, null, Slots.Self),
                };
            nucleolusMove.animationTarget = Slots.Self;
            nucleolusMove.visuals = LoadedAssetsHandler.GetCharacterAbility("Hex_1_A").visuals;


            //dna
            Ability DNA = new Ability();
            DNA.name = "Deoxyribonucleic Acid";
            DNA.description = "Change this party member's health to yellow. If successful, heal 7.";
            DNA.cost = new ManaColorSO[] { Pigments.Red };
            DNA.sprite = ResourceLoader.LoadSprite("deoxyribonucleic");
            DNA.effects = new Effect[]
                {
                    //red check
                    new(vatChecker, 0, null, Slots.Self),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev0),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev1),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev2),

                    //blue check
                    new(vatChecker, 1, null, Slots.Self),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev0),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev1),

                    //purple check
                    new(vatChecker, 2, null, Slots.Self),
                    new(setVatSprites, 1, null, Slots.Self, checkValuePrev0),

                    //yellow check
                    //none for yellow to yellow. it dont make sense

                    //actual effect
                    new(cholericColor, 1, IntentType.Mana_Modify, Slots.Self),
                    new(ScriptableObject.CreateInstance<HealEffect>(), 7, IntentType.Heal_1_4, Slots.Self, basicPrevious),

                    //change sprite value to 3 (yellow)
                    new(vatChanger, 3, null, Slots.Self),
                };
            DNA.animationTarget = Slots.Self;
            DNA.visuals = LoadedAssetsHandler.GetCharacterAbility("Hex_1_A").visuals;

            //
            //
            //

            PerformEffectPassiveAbility leaky3 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            leaky3._passiveName = "Leaky (3)";
            leaky3.type = (PassiveAbilityTypes)873579;
            leaky3.passiveIcon = Passives.Leaky.passiveIcon;
            leaky3._enemyDescription = "okay people tomorrow morning 10 am santas comin to town";
            leaky3._characterDescription = "Upon receiving damage this party member produces additional Pigment. ";
            leaky3.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new(ScriptableObject.CreateInstance<GenerateCasterHealthManaEffect>(), 3, null, Slots.Self),
                });
            leaky3._triggerOn = new TriggerCalls[]
                {
                    TriggerCalls.OnDirectDamaged
                };

            var giveLeaky = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            giveLeaky._extraPassiveAbility = leaky3;

            var healthToRed = ScriptableObject.CreateInstance<HealthColorChange_Wearable_SMS>();
            healthToRed._healthColor = Pigments.Red;

            var doubleHealth = ScriptableObject.CreateInstance<MaxHealthChange_Wearable_SMS>();
            doubleHealth.isChangePercentage = true;
            doubleHealth.maxHealthChange = 100;

            

            EffectItem sickleCells = new EffectItem();
            sickleCells.name = "Sickle Cells";
            sickleCells.flavorText = "\"At least you won't get malaria.\"";
            sickleCells.description = "Double this party member's health and turn it red. This party member now has leaky(3) as a passive. Apply 1 scar at the start of combat.";
            sickleCells.sprite = ResourceLoader.LoadSprite("SickleCells", 1, null);
            sickleCells.trigger = TriggerCalls.OnCombatStart;
            sickleCells.unlockableID = (UnlockableID)832754;
            sickleCells.namePopup = true;
            sickleCells.itemPools = BrutalAPI.ItemPools.Treasure;
            sickleCells.immediate = true;
            sickleCells.equippedModifiers = new WearableStaticModifierSetterSO[]
            {
                giveLeaky, 
                healthToRed, 
                doubleHealth,
            };
            sickleCells.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, null, Slots.Self),
            };

            //
            //
            //
           
            var healthToBlue = ScriptableObject.CreateInstance<HealthColorChange_Wearable_SMS>();
            healthToBlue._healthColor = Pigments.Blue;

            var halfHealth = ScriptableObject.CreateInstance<SubtractMaxHealth_Wearable_SMS>();
            halfHealth.isChangePercentage = true;
            halfHealth.maxHealthChange = 50;

            DoubleEffectItem festerFlesh = new DoubleEffectItem();
            festerFlesh.name = "Fester Flesh";
            festerFlesh.flavorText = "\"I need this. I need this now. I need this forever. I am hell.\"";
            festerFlesh.description = "Halve this party member's health and turn it blue. On turn start and end, apply 3-4 shield to this position.";
            festerFlesh.sprite = ResourceLoader.LoadSprite("FesterFlesh", 1, null);
            festerFlesh.unlockableID = (UnlockableID)832755;
            festerFlesh.namePopup = true;
            festerFlesh.itemPools = BrutalAPI.ItemPools.Treasure;
            festerFlesh.SecondTrigger = new TriggerCalls[]
            {
                TriggerCalls.OnTurnStart,
                TriggerCalls.OnTurnFinished,
            };
            festerFlesh.secondEffects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 3, null, Slots.Self, Conditions.Chance(50)),
                new(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 4, null, Slots.Self, Brevious),
            };
            festerFlesh.equippedModifiers = new WearableStaticModifierSetterSO[]
            {
                healthToBlue,
                halfHealth,
            };
            

            FoolItemPairs VatPair = new FoolItemPairs(vat, sickleCells, festerFlesh);
            VatPair.Add();


            Debug.Log("loading");
            vat.AddLevel(50, new Ability[3] { nucleolusMove, golgiBody, DNA }, 0);
            vat.AddCharacter();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Vat");

        }
    }
}
