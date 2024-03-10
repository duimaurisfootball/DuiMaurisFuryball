namespace Dui_Mauris_Furyball
{
    public class Formido
    {
        public static void Add()
        {
            //Formido Basics
            Character formido = new Character();
            formido.name = "Formido";
            formido.healthColor = Pigments.Purple;
            formido.entityID = (EntityIDs)66126699;
            formido.frontSprite = ResourceLoader.LoadSprite("FormidoFront");
            formido.backSprite = ResourceLoader.LoadSprite("FormidoBack");
            formido.overworldSprite = ResourceLoader.LoadSprite("FormidoOverworld", 32, new Vector2(0.5f, 0.02f));
            formido.lockedSprite = ResourceLoader.LoadSprite("FormidoMenu");
            formido.unlockedSprite = ResourceLoader.LoadSprite("FormidoMenu");
            formido.menuChar = true;
            formido.appearsInShops = true;
            formido.hurtSound = LoadedAssetsHandler.GetEnemy("OsmanLeft_BOSS").damageSound;
            formido.deathSound = LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").damageSound;
            formido.dialogueSound = LoadedAssetsHandler.GetEnemy("OsmanLeft_BOSS").damageSound;
            formido.isSupport = true;
            formido.passives = new BasePassiveAbilitySO[]
            {
                Passives.Unstable,
                Passives.Construct
            };
            
            var stoneReroll = ScriptableObject.CreateInstance<CostRerollChangeSizeRandomlyEffect>();
            stoneReroll._newCosts = new()
            {
                Pigments.Red,
                Pigments.Red,
                Pigments.Red,
                Pigments.Blue,
                Pigments.Blue,
                Pigments.Blue,
                Pigments.Yellow,
                Pigments.Yellow,
                Pigments.Yellow,
                Pigments.Purple,
                Pigments.Purple,
                Pigments.Purple,
                Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
                Pigments.SplitPigment(Pigments.Red, Pigments.Yellow),
                Pigments.SplitPigment(Pigments.Red, Pigments.Purple),
                Pigments.SplitPigment(Pigments.Blue, Pigments.Yellow),
                Pigments.SplitPigment(Pigments.Blue, Pigments.Purple),
                Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple),
                Pigments.Gray,
            };

            var allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllies = true;
            allAlly.getAllUnitSlots = false;

            var remRuptured = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            remRuptured._statusToRemove = StatusEffectType.Ruptured;

            var remFrail = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            remFrail._statusToRemove = StatusEffectType.Frail;

            var remLinked = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            remLinked._statusToRemove = StatusEffectType.Linked;

            var remCursed = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            remCursed._statusToRemove = StatusEffectType.Cursed;

            var unstable2 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            unstable2._extraPassiveAbility = Passives.Unstable;

            var dollSpawn0 = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereEffect>();
            dollSpawn0._characterCopy = "Doll_CH";
            dollSpawn0._rank = 0;
            dollSpawn0._nameAddition = NameAdditionLocID.NameAdditionNone;
            dollSpawn0._permanentSpawn = false;
            dollSpawn0._usePreviousAsHealth = false;
            dollSpawn0._extraModifiers = new WearableStaticModifierSetterSO[]
            {
                unstable2
            };

            //Stones
            var stones0 = new Ability();
            stones0.name = "Mercurian Stones";
            stones0.description = "Reroll all party member's costs, with a chance to change the number of costs. Remove ruptured from every party member.";
            stones0.cost = new ManaColorSO[] { Pigments.Red, Pigments.Yellow };
            stones0.sprite = ResourceLoader.LoadSprite("thunderstrike");
            stones0.effects = new Effect[]
            {
                new(stoneReroll, 1, IntentType.Mana_Modify, allAlly),
                new(remRuptured, 1, IntentType.Rem_Status_Ruptured, allAlly),
            };
            stones0.animationTarget = Slots.SlotTarget(new int[] { -1, 1 }, true);
            stones0.visuals = LoadedAssetsHandler.GetCharacterAbility("Sear_1_A").visuals;

            var stones1 = stones0.Duplicate();
            stones1.name = "Venusian Stones";
            stones1.description = "Reroll all party member's costs, with a chance to change the number of costs. Remove ruptured and frail from every party member.";
            stones1.effects = new Effect[]
            {
                new(stoneReroll, 1, IntentType.Mana_Modify, allAlly),
                new(remRuptured, 1, IntentType.Rem_Status_Ruptured, allAlly),
                new(remFrail, 1, IntentType.Rem_Status_Frail, allAlly),
            };

            var stones2 = stones1.Duplicate();
            stones2.name = "Lunar Stones";
            stones2.description = "Reroll all party member's costs, with a chance to change the number of costs. Remove ruptured, frail, and linked from every party member.";
            stones2.effects = new Effect[]
            {
                new(stoneReroll, 1, IntentType.Mana_Modify, allAlly),
                new(remRuptured, 1, IntentType.Rem_Status_Ruptured, allAlly),
                new(remFrail, 1, IntentType.Rem_Status_Frail, allAlly),
                new(remLinked, 1, IntentType.Rem_Status_Linked, allAlly),
            };

            var stones3 = stones2.Duplicate();
            stones3.name = "Martian Stones";
            stones3.description = "Reroll all party member's costs, with a chance to change the number of costs. Remove ruptured, frail, linked, and curse from every party member.";
            stones3.effects = new Effect[]
            {
                new(stoneReroll, 1, IntentType.Mana_Modify, allAlly),
                new(remRuptured, 1, IntentType.Rem_Status_Ruptured, allAlly),
                new(remFrail, 1, IntentType.Rem_Status_Frail, allAlly),
                new(remLinked, 1, IntentType.Rem_Status_Linked, allAlly),
                new(remCursed, 1, IntentType.Rem_Status_Cursed, allAlly),
            };


            //Lovely People
            var soul0 = new Ability();
            soul0.name = "You Lovely People";
            soul0.description = "Increase all party member's health by 1, ignoring max health. Attempt to summon an unstable Doll.";
            soul0.cost = new ManaColorSO[] { Pigments.Purple, Pigments.Blue };
            soul0.sprite = ResourceLoader.LoadSprite("shockTherapy");
            soul0.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<HealIgnoreMaxHealthEffect>(), 1, IntentType.Heal_1_4, allAlly),
                new(dollSpawn0, 1, IntentType.Other_Spawn, Slots.SlotTarget(new int[] {-4, -3, -2, -1, 0, 1, 2, 3, 4}, true)),
            };
            soul0.animationTarget = Slots.SlotTarget(new int[] { -2, 0, 2 }, true);
            soul0.visuals = LoadedAssetsHandler.GetCharacterAbility("Sear_1_A").visuals;

            var soul1 = soul0.Duplicate();
            soul1.name = "We're Lovely People";
            soul1.description = "Increase all party member's health by 2, ignoring max health. Attempt to summon an unstable Doll.";
            soul1.effects[0]._entryVariable = 2;
            
            var soul2 = soul1.Duplicate();
            soul2.name = "A World of Lovely People";
            soul2.description = "Increase all party member's health by 3, ignoring max health. Attempt to summon an unstable Doll.";
            soul2.effects[0]._entryVariable = 3;

            var soul3 = soul2.Duplicate();
            soul3.name = "We Martians are Lovely People";
            soul3.description = "Increase all party member's health by 4, ignoring max health. Attempt to summon an unstable Doll.";
            soul3.effects[0]._entryVariable = 4;


            //Wrought
            var wrought0 = new Ability();
            wrought0.name = "Glade Wrought";
            wrought0.description = "Make every party member perform a random one of their abilities. Party members with construct will perform 1 extra random ability.";
            wrought0.cost = new ManaColorSO[] { Pigments.Yellow, Pigments.Red, Pigments.Purple, Pigments.Blue, Pigments.Gray };
            wrought0.sprite = ResourceLoader.LoadSprite("reconfiguration");
            wrought0.effects = new Effect[]
            {
                new(ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, IntentType.Misc, allAlly),
                new(ScriptableObject.CreateInstance<PerformRandomAbilityCheckConstructEffect>(), 1, IntentType.Misc, allAlly),
            };

            var wrought1 = wrought0.Duplicate();
            wrought1.name = "Delta Wrought";
            wrought1.description = "Make every party member perform a random one of their abilities. Party members with construct will perform 2 extra random abilities.";
            wrought1.effects[1]._entryVariable = 2;

            var wrought2 = wrought1.Duplicate();
            wrought2.name = "Satan Wrought";
            wrought2.description = "Make every party member perform a random one of their abilities. Party members with construct will perform 3 extra random abilities.";
            wrought2.effects[1]._entryVariable = 3;

            var wrought3 = wrought2.Duplicate();
            wrought3.name = "Olympus Wrought";
            wrought3.description = "Make every party member perform a random one of their abilities. Party members with construct will perform 4 extra random abilities.";
            wrought3.effects[1]._entryVariable = 4;


            formido.AddLevel(15, new Ability[3] { stones0, soul0, wrought0 }, 0);
            formido.AddLevel(15, new Ability[3] { stones1, soul1, wrought1 }, 1);
            formido.AddLevel(15, new Ability[3] { stones2, soul2, wrought2 }, 2);
            formido.AddLevel(15, new Ability[3] { stones3, soul3, wrought3 }, 3);
            formido.AddCharacter();

            Connection_PerformEffectPassiveAbility connection_PerformEffectPassiveAbility = LoadedAssetsHandler.GetCharcater("Doll_CH").passiveAbilities[0] as Connection_PerformEffectPassiveAbility;
            CasterAddRandomExtraAbilityEffect casterAddRandomExtraAbilityEffect = connection_PerformEffectPassiveAbility.connectionEffects[1].effect as CasterAddRandomExtraAbilityEffect;
            casterAddRandomExtraAbilityEffect._extraData = new List<ExtraAbility_Wearable_SMS>(casterAddRandomExtraAbilityEffect._extraData)
            {
            }.ToArray();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Formido");
        }
    }
}
