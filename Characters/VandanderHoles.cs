namespace Dui_Mauris_Furyball.Characters
{
    public static class VandanderHoles
    {
        public static void Add()
        {
            //holes basics
            Character vandanderHoles = new Character();
            Debug.Log("loading");
            vandanderHoles.name = "Holes of Vandander";
            vandanderHoles.healthColor = Pigments.Purple;
            vandanderHoles.entityID = (EntityIDs)22123125;
            vandanderHoles.frontSprite = ResourceLoader.LoadSprite("VandanderHolesFront");
            vandanderHoles.backSprite = ResourceLoader.LoadSprite("VandanderHolesBack");
            vandanderHoles.overworldSprite = ResourceLoader.LoadSprite("VandanderHolesOverworld", 32, new Vector2(0.5f, 0.02f));
            vandanderHoles.lockedSprite = ResourceLoader.LoadSprite("VandanderHolesMenu");
            vandanderHoles.unlockedSprite = ResourceLoader.LoadSprite("VandanderHolesMenu");
            vandanderHoles.menuChar = false;
            vandanderHoles.appearsInShops = false;
            vandanderHoles.isSecret = true;
            vandanderHoles.hurtSound = LoadedAssetsHandler.GetEnemy("TaMaGoa_EN").deathSound;
            vandanderHoles.deathSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").deathSound;
            vandanderHoles.dialogueSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").deathSound;
            vandanderHoles.isSupport = true;
            vandanderHoles.levels = new CharacterRankedData[1];
            vandanderHoles.usesAllAbilities = true;
            vandanderHoles.passives = new BasePassiveAbilitySO[]
            {
                Passives.Delicate,
                Passives.Enfeebled,
            };

            var tenheal = ScriptableObject.CreateInstance<HealEffect>();
            tenheal.entryAsPercentage = true;

            var brevios = ScriptableObject.CreateInstance<PreviousEffectCondition>();

            //one move smile
            var vandalize = new Ability();
            vandalize.name = "Vandalize";
            vandalize.description = "Apply 1 frail to the opposing enemy, apply 1 linked and 1 scar to the opposing enemy, or heal the left ally 20% of their health. Any combination of these effects can happen.";
            vandalize.cost = new ManaColorSO[] { Pigments.Blue };
            vandalize.sprite = ResourceLoader.LoadSprite("vandalize");
            vandalize.effects = new Effect[]
                {
                    new(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 1, IntentType.Status_Frail, Slots.Front, Conditions.Chance(50)),
                    new(ScriptableObject.CreateInstance<ApplyLinkedEffect>(), 1, IntentType.Status_Linked, Slots.Front, Conditions.Chance(50)),
                    new(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, IntentType.Status_Scars, Slots.Front, brevios),
                    new(tenheal, 20, IntentType.Heal_1_4, Slots.SlotTarget(new int[] { -1 }, true), Conditions.Chance(50)),
                };
            vandalize.animationTarget = Slots.Self;
            vandalize.visuals = LoadedAssetsHandler.GetEnemy("Sepulchre_EN").abilities[0].ability.visuals;

            Debug.Log("loading");
            vandanderHoles.AddLevel(8, new Ability[] { vandalize }, 0);
            vandanderHoles.AddCharacter();

            Debug.Log("It's working! It's working! | Dui Mauris Furyball | Holes of Vandander");
        }
    }
}
