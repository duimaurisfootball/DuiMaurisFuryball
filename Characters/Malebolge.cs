namespace Dui_Mauris_Furyball
{
    public static class Malebolge
    {
        public static void Add()

        {
            //Malebolge Basics
            Character malebolge = new Character();
            
            malebolge.name = "Malebolge";
            malebolge.healthColor = Pigments.Gray;
            malebolge.entityID = (EntityIDs)257772;
            malebolge.frontSprite = ResourceLoader.LoadSprite("MalebolgeFront");
            malebolge.backSprite = ResourceLoader.LoadSprite("MalebolgeBack");
            malebolge.overworldSprite = ResourceLoader.LoadSprite("MalebolgeOverworld", 32, new Vector2(0.5f, 0.02f));
            malebolge.lockedSprite = ResourceLoader.LoadSprite("MalebolgeLocked");
            malebolge.unlockedSprite = ResourceLoader.LoadSprite("MalebolgeMenu");
            malebolge.menuChar = true;
            malebolge.appearsInShops = true;
            malebolge.usesAllAbilities = true;
            malebolge.usesBaseAbility = false;
            malebolge.walksInOverworld = false;
            malebolge.hurtSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").damageSound;
            malebolge.deathSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").deathSound;
            malebolge.dialogueSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").damageSound;
            malebolge.isSupport = false;
            malebolge.levels = new CharacterRankedData[1];
            malebolge.passives = new BasePassiveAbilitySO[]
            {
                Passives.Inanimate
            };
            malebolge.osmanUnlock = (UnlockableID)999182;
            malebolge.heavenUnlock = (UnlockableID)999183;

            IDetour Accelerate = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(Malebolge).GetMethod("AddStoredValueName", ~BindingFlags.Default));

            //glorify
            Ability glorify = new Ability();
            glorify.name = "Glorify";
            glorify.description = "Inflict 4 ruptured, 4 frail, 4 oil slicked, and 4 scars to the opposing enemy.";
            glorify.cost = new ManaColorSO[] { Pigments.Purple, Pigments.Purple, Pigments.Red };
            glorify.sprite = ResourceLoader.LoadSprite("glorify");
            glorify.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 4, IntentType.Status_Ruptured, Slots.Front),
                    new(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 4, IntentType.Status_Frail, Slots.Front),
                    new(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 4, IntentType.Status_OilSlicked, Slots.Front),
                    new(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 4, IntentType.Status_Scars, Slots.Front),
                };


            //explode damage effects
            var indirectDamage = ScriptableObject.CreateInstance<DamageEffect>();
            indirectDamage._indirect = true;
            var explodeDamage = ScriptableObject.CreateInstance<DamageEffect>();
            explodeDamage._usePreviousExitValue = true;

            //explode targets
            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;

            //combust
            Ability combust = new Ability();
            combust.name = "Combust";
            combust.description = "Deal 8 fire damage to the opposing enemy.";
            combust.cost = new ManaColorSO[] { Pigments.Red, Pigments.Yellow };
            combust.sprite = ResourceLoader.LoadSprite("combust");
            combust.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<FireDamageEffectFootball>(), 8, IntentType.Field_Fire, Slots.Front),
                };


            //indirect damage for accelerate
            var accelDamage = ScriptableObject.CreateInstance<AcceleratingDamage>();
            accelDamage._indirect = true;
            accelDamage._usePreviousExitValue = true;

            //accelerate up
            CasterStoredValueChangeEffect accelerando = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            accelerando._increase = true;
            accelerando._valueName = (UnitStoredValueNames)800808;
            var basicPrevious = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            basicPrevious.wasSuccessful = false;

            //check for stored value
            var acceleratingFaster = ScriptableObject.CreateInstance<CasterStoreValueCheckEffect>();
            acceleratingFaster._valueName = (UnitStoredValueNames)800808;

            //accelerate
            Ability accelerateTime = new Ability();
            accelerateTime.name = "Accelerate Time";
            accelerateTime.description = "Deal 1 indirect damage to all enemies. Increase the damage dealt by this attack by 1-2. ";
            accelerateTime.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.Red };
            accelerateTime.sprite = ResourceLoader.LoadSprite("accelerate");
            accelerateTime.effects = new Effect[]
                {
                    new(acceleratingFaster, 1, IntentType.Misc_State_Stand, Slots.Self),
                    new(accelDamage, 1, IntentType.Damage_1_2, allEnemy),
                    new(accelerando, 1, null, Slots.Self, Conditions.Chance(40)),
                    new(accelerando, 2, null, Slots.Self, basicPrevious),
                };
            accelerateTime.animationTarget = allEnemy;
            accelerateTime.visuals = LoadedAssetsHandler.GetCharacterAbility("Clobber_1_A").visuals;


            //
            //
            //

            //stored value
            var headFalling = ScriptableObject.CreateInstance<CasterStoreValueCheckEffect>();
            headFalling._valueName = (UnitStoredValueNames)809942;

            //fire damage
            var headFireDamage = ScriptableObject.CreateInstance<FireDamageEffectFootball>();
            headFireDamage._usePreviousExitValue = true;
            headFireDamage._severedHeadDamage = true;

            var guillotine = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            guillotine._increase = true;
            guillotine._valueName = (UnitStoredValueNames)809942;


            IDetour Ahead = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default),
                typeof(SeveredHeadValue).GetMethod("AddStoredValueName", ~BindingFlags.Default));

            EffectItem malebolgeHead = new EffectItem();
            malebolgeHead.name = "Malebolge's Severed Head";
            malebolgeHead.flavorText = "''You'll be alseep soon enough.''";
            malebolgeHead.description = "Deal 1 fire damage to all enemies on turn start. 50% chance to increase damage by 1 upon activation.";
            malebolgeHead.sprite = ResourceLoader.LoadSprite("MalebolgesSeveredHead", 1, null);
            malebolgeHead.trigger = TriggerCalls.OnTurnStart;
            malebolgeHead.unlockableID = (UnlockableID)999182;
            malebolgeHead.namePopup = true;
            malebolgeHead.itemPools = BrutalAPI.ItemPools.Treasure;
            malebolgeHead.effects = new Effect[]
            {
                new(headFalling, 1, null, Slots.Self),
                new(headFireDamage, 1, null, allEnemy),
                new(guillotine, 1, null, Slots.Self, Conditions.Chance(50)),
            };

            //
            //
            //

            var healthToGray = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
            healthToGray._healthColors = new ManaColorSO[] { Pigments.Gray };

            PercentDamageDoubleEffectWearable carversTools = new PercentDamageDoubleEffectWearable();
            carversTools.name = "Carver's Tools";
            carversTools.flavorText = "\"It will never be perfect.\"";
            carversTools.description = "Decrease all incoming damage by 25%. Upon taking direct damage, turn this party member's health gray.";
            carversTools.sprite = ResourceLoader.LoadSprite("CarversTools", 32, null);
            carversTools.trigger = TriggerCalls.OnBeingDamaged;
            carversTools._secondPerformTriggersOn = new TriggerCalls[]
                {
                    TriggerCalls.OnBeingDamaged,
                };
            carversTools.unlockableID = (UnlockableID)999181;
            carversTools.namePopup = true;
            carversTools.consumedOnUse = false;
            carversTools.itemPools = (ItemPools)1;
            carversTools.shopPrice = 10;
            carversTools._doesIncrease = false;
            carversTools._useDealt = false;
            carversTools._secondDoesPerformItemPopUp = false;
            carversTools._GetsConsumedOnSecondaryUse = false;
            carversTools._secondImmediateEffect = false;
            carversTools._percentageToModify = 75;
            carversTools._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new(healthToGray, 1, null, Slots.Self),
                });

            FoolItemPairs MalebolgePair = new FoolItemPairs(malebolge, carversTools, malebolgeHead);
            MalebolgePair.Add();

            
            malebolge.AddLevel(100, new Ability[3] { glorify, combust, accelerateTime }, 0);
            malebolge.levels[0].rankAbilities[2].ability.specialStoredValue = (UnitStoredValueNames)800808;
            malebolge.AddCharacter();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Malebolge");
        }
        public static string AddStoredValueName(
            Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
            TooltipTextHandlerSO self, UnitStoredValueNames storedValue, int value)
        {
            Color red = Color.red;
            string str1;
            if (storedValue == (UnitStoredValueNames)800808)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Acceleration" + string.Format(" +{0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.red) + ">";
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
