namespace Dui_Mauris_Furyball
{
    public static class Alvinar
    {
        public static void Add()
        {
            //Custom Passive
            var Connoisseur = ScriptableObject.CreateInstance<SeasoningDamage>();
            Connoisseur._passiveName = "Connoisseur";
            Connoisseur.type = (PassiveAbilityTypes)091273;
            Connoisseur.passiveIcon = Passives.Formless.passiveIcon;
            Connoisseur._enemyDescription = "???";
            Connoisseur._characterDescription = "This party member inflicts 20% additional damage for each status effect on targets.";
            Connoisseur._triggerOn = new TriggerCalls[0];

            //prepare
            Ability prepare = new Ability();
            prepare.name = "Prepare";
            prepare.description = "Deal 1 damage to the opposing enemy. Inflict 4 oil slicked to the opposing enemy.";
            prepare.cost = new ManaColorSO[] { Pigments.Yellow };
            prepare.sprite = ResourceLoader.LoadSprite("evilpoke");
            prepare.effects = new Effect[]
            {
              new(ScriptableObject.CreateInstance<DamageEffect>(), 1, IntentType.Damage_1_2, Slots.Front),
              new(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 4, IntentType.Status_OilSlicked, Slots.Front),
            };
            prepare.animationTarget = Slots.Front;
            prepare.visuals = LoadedAssetsHandler.GetCharacterAbility("Oil_1_A").visuals;

            //Alvinar Basics
            Character alvinar = new Character();
            Debug.Log("loading");
            alvinar.name = "Alvinar";
            alvinar.healthColor = Pigments.Purple;
            alvinar.entityID = (EntityIDs)991293;
            alvinar.frontSprite = ResourceLoader.LoadSprite("AlvinarFront");
            alvinar.backSprite = ResourceLoader.LoadSprite("AlvinarBack");
            alvinar.overworldSprite = ResourceLoader.LoadSprite("AlvinarOverworld", 32, new Vector2(0.5f, 0.02f));
            alvinar.lockedSprite = ResourceLoader.LoadSprite("AlvinarLocked");
            alvinar.unlockedSprite = ResourceLoader.LoadSprite("AlvinarMenu");
            alvinar.menuChar = true;
            alvinar.appearsInShops = true;
            alvinar.hurtSound = LoadedAssetsHandler.GetCharcater("Boyle_CH").damageSound;
            alvinar.deathSound = LoadedAssetsHandler.GetCharcater("Boyle_CH").deathSound;
            alvinar.dialogueSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").damageSound;
            alvinar.isSupport = false;
            alvinar.baseAbility = prepare;
            alvinar.passives = new BasePassiveAbilitySO[]
            {
                Connoisseur,
            };

            //Just for you! special indirect damage :3
            SpecialDamageShieldBlockedEffect IndirectDamage = ScriptableObject.CreateInstance<SpecialDamageShieldBlockedEffect>();
            IndirectDamage._indirect = true;

            //Frenzy
            Ability frenzy0 = new Ability();
            frenzy0.name = "Chewing Frenzy";
            frenzy0.description = "Deal 1 indirect damage to the opposing enemy 3 times, then deal 1 direct damage. Inflict 1 scar to the opposing enemy. This ability is completely blocked by shield.";
            frenzy0.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.Purple };
            frenzy0.sprite = ResourceLoader.LoadSprite("ablate");
            frenzy0.effects = new Effect[]
            {
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(ScriptableObject.CreateInstance<DamageShieldBlockedEffect>(), 1, IntentType.Damage_1_2, Slots.Front),
                new(ScriptableObject.CreateInstance<ApplyScarsEffectShieldBlocked>(), 1, IntentType.Status_Scars, Slots.Front),
            };
            frenzy0.animationTarget = Slots.Front;
            frenzy0.visuals = LoadedAssetsHandler.GetEnemyAbility("Gnaw_A").visuals;

            Ability frenzy1 = frenzy0.Duplicate();
            frenzy1.name = "Biting Frenzy";
            frenzy1.description = "Deal 1 indirect damage to the opposing enemy 4 times, then deal 1 direct damage. Inflict 1 scar to the opposing enemy. This ability is completely blocked by shield.";
            frenzy1.sprite = ResourceLoader.LoadSprite("ablate");
            frenzy1.effects = new Effect[]
            {
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(ScriptableObject.CreateInstance<DamageShieldBlockedEffect>(), 1, IntentType.Damage_1_2, Slots.Front),
                new(ScriptableObject.CreateInstance<ApplyScarsEffectShieldBlocked>(), 1, IntentType.Status_Scars, Slots.Front),
            };

            Ability frenzy2 = frenzy1.Duplicate();
            frenzy2.name = "Wounding Frenzy";
            frenzy2.description = "Deal 1 indirect damage to the opposing enemy 5 times, then deal 1 direct damage. Inflict 1 scar to the opposing enemy. This ability is completely blocked by shield.";
            frenzy2.sprite = ResourceLoader.LoadSprite("ablate");
            frenzy2.effects = new Effect[]
            {
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(ScriptableObject.CreateInstance<DamageShieldBlockedEffect>(), 1, IntentType.Damage_1_2, Slots.Front),
                new(ScriptableObject.CreateInstance<ApplyScarsEffectShieldBlocked>(), 1, IntentType.Status_Scars, Slots.Front),
            };

            Ability frenzy3 = frenzy2.Duplicate();
            frenzy3.name = "Masticating Frenzy";
            frenzy3.description = "Deal 1 indirect damage to the opposing enemy 6 times, then deal 1 direct damage. Inflict 1 scar to the opposing enemy. This ability is completely blocked by shield.";
            frenzy3.sprite = ResourceLoader.LoadSprite("ablate");
            frenzy3.effects = new Effect[]
            {
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(IndirectDamage, 1, IntentType.Damage_1_2, Slots.Front),
                new(ScriptableObject.CreateInstance<DamageShieldBlockedEffect>(), 1, IntentType.Damage_1_2, Slots.Front),
                new(ScriptableObject.CreateInstance<ApplyScarsEffectShieldBlocked>(), 1, IntentType.Status_Scars, Slots.Front),
            };

            //Tear
            Ability tear0 = new Ability();
            tear0.name = "Face Torn Open";
            tear0.description = "Deal 5 damage to the opposing enemy. Inflict 3 ruptured to the opposing enemy. This ability is completely blocked by shield.";
            tear0.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.Blue };
            tear0.sprite = ResourceLoader.LoadSprite("vandala effect");
            tear0.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<DamageShieldBlockedEffect>(), 5, IntentType.Damage_3_6, Slots.Front),
                new(ScriptableObject.CreateInstance<ApplyRupturedEffectShieldBlocked>(), 3, IntentType.Status_Ruptured, Slots.Front),
            };
            tear0.animationTarget = Slots.Self;
            tear0.visuals = LoadedAssetsHandler.GetCharacterAbility("Huff_1_A").visuals;

            Ability tear1 = tear0.Duplicate();
            tear1.name = "Skull Torn Open";
            tear1.description = "Deal 7 damage to the opposing enemy. Inflict 3 ruptured to the opposing enemy. This ability is completely blocked by shield.";
            tear1.effects[0]._entryVariable = 7;
            tear1.effects[0]._intent = IntentType.Damage_7_10;

            Ability tear2 = tear1.Duplicate();
            tear2.name = "Chest Torn Open";
            tear2.description = "Deal 9 damage to the opposing enemy. Inflict 3 ruptured to the opposing enemy. This ability is completely blocked by shield.";
            tear2.effects[0]._entryVariable = 9;

            Ability tear3 = tear2.Duplicate();
            tear3.name = "Body Torn Open";
            tear3.description = "Deal 11 damage to the opposing enemy. Inflict 3 ruptured to the opposing enemy. This ability is completely blocked by shield.";
            tear3.effects[0]._entryVariable = 11;
            tear2.effects[0]._intent = IntentType.Damage_11_15;

            //Feast
            Ability feast0 = new Ability();
            feast0.name = "Nice Feast";
            feast0.description = "Deal 4 damage to the opposing enemy. Inflict 2 frail to the opposing enemy. This ability is completely blocked by shield.";
            feast0.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.Yellow };
            feast0.sprite = ResourceLoader.LoadSprite("");
            feast0.effects = new Effect[2];
            feast0.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageShieldBlockedEffect>(),
                4, IntentType.Damage_3_6, Slots.Front);
            feast0.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyFrailEffectShieldBlocked>(),
                2, IntentType.Status_Frail, Slots.Front);
            feast0.animationTarget = Slots.Self;
            feast0.visuals = LoadedAssetsHandler.GetCharacterAbility("Huff_1_A").visuals;

            Ability feast1 = feast0.Duplicate();
            feast1.name = "Big Feast";
            feast1.description = "Deal 5 damage to the opposing enemy. Inflict 2 frail to the opposing enemy. This ability is completely blocked by shield.";
            feast1.effects[0]._entryVariable = 5;

            Ability feast2 = feast1.Duplicate();
            feast2.name = "Hearty Feast";
            feast2.description = "Deal 6 damage to the opposing enemy. Inflict 3 frail to the opposing enemy. This ability is completely blocked by shield.";
            feast2.effects[0]._entryVariable = 6;

            Ability feast3 = feast2.Duplicate();
            feast3.name = "Family Feast";
            feast3.description = "Deal 7 damage to the opposing enemy. Inflict 3 frail to the opposing enemy. This ability is completely blocked by shield.";
            feast3.effects[0]._entryVariable = 7;
            feast3.effects[0]._intent = IntentType.Damage_7_10;


            Debug.Log("loading");
            alvinar.AddLevel(15, new Ability[3] { frenzy0, tear0, feast0 }, 0);
            alvinar.AddLevel(15, new Ability[3] { frenzy1, tear1, feast1 }, 1);
            alvinar.AddLevel(17, new Ability[3] { frenzy2, tear2, feast2 }, 2);
            alvinar.AddLevel(19, new Ability[3] { frenzy3, tear3, feast3 }, 3);
            alvinar.AddCharacter();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Alvinar");
        }
    }
}
