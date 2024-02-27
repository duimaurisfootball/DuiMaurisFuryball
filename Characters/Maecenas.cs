namespace Dui_Mauris_Furyball
{
    public class Maecenas
    {
        public static void Add()
        {
            //Maecenas Basics
            Character maecenas = new Character();
            maecenas.name = "Maecenas";
            maecenas.healthColor = Pigments.Purple;
            maecenas.entityID = (EntityIDs)33299106;
            maecenas.frontSprite = ResourceLoader.LoadSprite("MaecenasFront");
            maecenas.backSprite = ResourceLoader.LoadSprite("MaecenasBack");
            maecenas.overworldSprite = ResourceLoader.LoadSprite("MaecenasOverworld", 32, new Vector2(0.5f, 0.02f));
            maecenas.lockedSprite = ResourceLoader.LoadSprite("MaecenasMenu");
            maecenas.unlockedSprite = ResourceLoader.LoadSprite("MaecenasMenu");
            maecenas.menuChar = true;
            maecenas.appearsInShops = true;
            maecenas.hurtSound = LoadedAssetsHandler.GetCharcater("Griffin_CH").damageSound;
            maecenas.deathSound = LoadedAssetsHandler.GetCharcater("Griffin_CH").deathSound;
            maecenas.dialogueSound = LoadedAssetsHandler.GetCharcater("Griffin_CH").dxSound;
            maecenas.isSupport = false;

            var damageEgo0 = ScriptableObject.CreateInstance<UnboundedDamageEffect>();
            damageEgo0._repeatChance = 66;
            damageEgo0._guaranteedRepeats = 2;

            var damageEgo1 = ScriptableObject.CreateInstance<UnboundedDamageEffect>();
            damageEgo1._repeatChance = 66;
            damageEgo1._guaranteedRepeats = 3;

            var damageEgo2 = ScriptableObject.CreateInstance<UnboundedDamageEffect>();
            damageEgo2._repeatChance = 66;
            damageEgo2._guaranteedRepeats = 4;

            var damageEgo3 = ScriptableObject.CreateInstance<UnboundedDamageEffect>();
            damageEgo3._repeatChance = 66;
            damageEgo3._guaranteedRepeats = 5;

            //ability
            var ego0 = new Ability();
            ego0.name = "Grain Ego";
            ego0.description = "Deal at least 6 damage to the opposing enemy, 10 on average. Add 1 additional attack to the Opposing enemy.";
            ego0.cost = new ManaColorSO[] { Pigments.Red };
            ego0.sprite = ResourceLoader.LoadSprite("ego");
            ego0.effects = new Effect[]
            {
                new(damageEgo0, 6, IntentType.Damage_3_6, Slots.Front),
                new(ScriptableObject.CreateInstance<AddTurnTargetToTimelineEffect>(), 1, IntentType.Other_Refresh, Slots.Front),
            };
            ego0.animationTarget = Slots.Self;
            ego0.visuals = LoadedAssetsHandler.GetCharacterAbility("Insult_1_A").visuals;

            var ego1 = ego0.Duplicate();
            ego1.name = "Salt Ego";
            ego1.description = "Deal at least 7 damage to the opposing enemy, 13 on average. Add 1 additional attack to the Opposing enemy.";
            ego1.effects[0]._entryVariable = 7;
            ego1.effects[0]._effect = damageEgo1;
            ego1.effects[0]._intent = IntentType.Damage_7_10;

            var ego2 = ego1.Duplicate();
            ego2.name = "Expressed Ego";
            ego2.description = "Deal at least 8 damage to the opposing enemy, 15 on average. Add 1 additional attack to the Opposing enemy.";
            ego2.effects[0]._entryVariable = 8;
            ego2.effects[0]._effect = damageEgo2;

            var ego3 = ego2.Duplicate();
            ego3.name = "Super Ego";
            ego3.description = "Deal at least 9 damage to the opposing enemy, 18 on average. Add 1 additional attack to the Opposing enemy.";
            ego3.effects[0]._entryVariable = 9;
            ego3.effects[0]._effect = damageEgo3;

            //Tango
            var tango0 = new Ability();
            tango0.name = "Strange Tango";
            tango0.description = "Deal 10 damage to the Opposing enemy. Inflict 3 ruptured on the opposing enemy. Add 1 additional attack to the Opposing enemy.";
            tango0.cost = new ManaColorSO[] { Pigments.Red, Pigments.Purple };
            tango0.sprite = ResourceLoader.LoadSprite("tango");
            tango0.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<DamageEffect>(), 10, IntentType.Damage_7_10, Slots.Front),
                new(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 3, IntentType.Status_Ruptured, Slots.Front),
                new(ScriptableObject.CreateInstance<AddTurnTargetToTimelineEffect>(), 1, IntentType.Other_Refresh, Slots.Front),
            };
            tango0.animationTarget = Slots.Front;
            tango0.visuals = LoadedAssetsHandler.GetEnemyAbility("FallingSkies_A").visuals;

            var tango1 = tango0.Duplicate();
            tango1.name = "Top-Heavy Tango";
            tango1.description = "Deal 13 damage to the Opposing enemy. Inflict 4 ruptured on the opposing enemy. Add 1 additional attack to the Opposing enemy.";
            tango1.effects[0]._entryVariable = 13;
            tango1.effects[0]._intent = IntentType.Damage_11_15;
            tango1.effects[1]._entryVariable = 4;

            var tango2 = tango1.Duplicate();
            tango2.name = "Monstrous Tango";
            tango2.description = "Deal 17 damage to the Opposing enemy. Inflict 4 ruptured on the opposing enemy. Add 1 additional attack to the Opposing enemy.";
            tango2.effects[0]._entryVariable = 17;
            tango2.effects[0]._intent = IntentType.Damage_16_20;

            var tango3 = tango2.Duplicate();
            tango3.name = "Let's Tango";
            tango3.description = "Deal 20 damage to the Opposing enemy. Inflict 5 ruptured on the opposing enemy. Add 1 additional attack to the Opposing enemy.";
            tango3.effects[0]._entryVariable = 20;
            tango3.effects[1]._entryVariable = 5;

            //Glare
            var glare0 = new Ability();
            glare0.name = "Sudden Glare";
            glare0.description = "Apply 2 fire to the Opposing position.";
            glare0.cost = new ManaColorSO[] { Pigments.Red, Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple), Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple) };
            glare0.sprite = ResourceLoader.LoadSprite("glare");
            glare0.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 2, IntentType.Field_Fire, Slots.Front),
            };
            glare0.animationTarget = Slots.Front;
            glare0.visuals = LoadedAssetsHandler.GetCharacterAbility("Torch_1_A").visuals;

            var glare1 = glare0.Duplicate();
            glare1.name = "Stinging Glare";
            glare1.description = "Apply 3 fire to the Opposing position.";
            glare1.effects[0]._entryVariable = 3;

            var glare2 = glare1.Duplicate();
            glare2.name = "Blazing Glare";
            glare2.description = "Apply 3 fire to the Left and Opposing positions.";
            glare2.effects[0]._target = Slots.SlotTarget(new int[] { -1, 0 }, false);

            var glare3 = glare2.Duplicate();
            glare3.name = "Solar Glare";
            glare3.description = "Apply 3 fire to the Left, Right, and Opposing positions.";
            glare3.effects[0]._target = Slots.SlotTarget(new int[] { -1, 0, 1 }, false);

            //
            //
            //

            var superSymbol = new EffectItem();
            superSymbol.name = "Alchemical Constant";
            superSymbol.flavorText = "\"Hot! Hot hot hot!\"";
            superSymbol.description = "Light an eternal fire in the Opposing position on combat start.";
            superSymbol.sprite = ResourceLoader.LoadSprite("Something", 1, null);
            superSymbol.unlockableID = (UnlockableID)5891783;
            superSymbol.namePopup = true;
            superSymbol.itemPools = BrutalAPI.ItemPools.Treasure;
            superSymbol.trigger = TriggerCalls.OnCombatStart;
            superSymbol.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<ApplyPermanentFireEffect>(), 1, null, Slots.Front)
            };

            //
            //
            //

            var allPurple = ScriptableObject.CreateInstance<RandomizeAllManaEffect>();
            allPurple.manaRandomOptions = new ManaColorSO[]
            {
                Pigments.Purple,
            };

            var allGray = ScriptableObject.CreateInstance<RandomizeAllManaEffect>();
            allGray.manaRandomOptions = new ManaColorSO[]
            {
                Pigments.Gray,
            };

            var brevois = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            brevois.wasSuccessful = false;

            var grayOil = new EffectItem();
            grayOil.name = "Night Oil";
            grayOil.flavorText = "\"Puts stars in your eyes.\"";
            grayOil.description = "Reroll all pigment in the pigment tray to either purple or gray.";
            grayOil.sprite = ResourceLoader.LoadSprite("GrayOil", 1, null);
            grayOil.unlockableID = (UnlockableID)5891784;
            grayOil.namePopup = true;
            grayOil.itemPools = BrutalAPI.ItemPools.Shop;
            grayOil.shopPrice = 6;
            grayOil.trigger = TriggerCalls.OnTurnFinished;
            grayOil.effects = new Effect[]
            {
                new(allPurple, 1, null, Slots.Self, Conditions.Chance(50)),
                new(allGray, 1, null, Slots.Self, brevois),
            };

            FoolItemPairs MaecenasPair = new FoolItemPairs(maecenas, superSymbol, grayOil);
            MaecenasPair.Add();

            maecenas.AddLevel(15, new Ability[] { ego0, tango0, glare0 }, 0);
            maecenas.AddLevel(19, new Ability[] { ego1, tango1, glare1 }, 1);
            maecenas.AddLevel(23, new Ability[] { ego2, tango2, glare2 }, 2);
            maecenas.AddLevel(26, new Ability[] { ego3, tango3, glare3 }, 3);
            maecenas.AddCharacter();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Maecenas");

        }
    }
}
