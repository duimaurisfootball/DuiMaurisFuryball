namespace Dui_Mauris_Furyball
{
    public class AbilityAdvanced : Ability
    {
        public CharacterAbility CharacterAdvancedAbility<T>(out T abilitySO) where T : AbilitySO
        {
            return new()
            {
                ability = (abilitySO = MakeAbility<T>()),
                cost = cost
            };
        }

        public EnemyAbilityInfo EnemyAdvancedAbility<T>(out T abilitySO) where T : AbilitySO
        {
            var rar = ScriptableObject.CreateInstance<RaritySO>();
            rar.rarityValue = rarity;
            rar.canBeRerolled = canBeRerolled;

            return new()
            {
                ability = (abilitySO = MakeAbility<T>()),
                rarity = rar
            };
        }
        public AbilityAdvanced DuplicateAdvanced()
        {
            var a = new AbilityAdvanced();
            a.name = name;
            a.sprite = sprite;
            a.description = description;
            a.priority = priority;
            a.visuals = visuals;
            a.effects = new Effect[effects.Length];
            a.rarity = rarity;
            a.canBeRerolled = canBeRerolled;
            a.animationTarget = animationTarget;
            for (int i = 0; i < effects.Length; i++)
            {
                a.effects[i] = new Effect(effects[i]);
            }
            a.cost = cost;
            return a;
        }
        public T MakeAbility<T>() where T : AbilitySO
        {
            var a = ScriptableObject.CreateInstance<T>();

            a._locAbilityData = new StringPairData(name, description);
            a._locID = "en_US";
            a.priority = ScriptableObject.CreateInstance<PrioritySO>();
            a.priority.priorityValue = priority;
            a.abilitySprite = sprite == null ? LoadedAssetsHandler.GetEnemy("Mung_EN").abilities[0].ability.abilitySprite : sprite;
            a.visuals = visuals;
            a.animationTarget = animationTarget;

            a.effects = new EffectInfo[effects.Length];
            a.intents = new IntentTargetInfo[effects.Length];

            for (int i = 0; i < effects.Length; i++)
            {
                EffectInfo ei = new EffectInfo();
                ei.entryVariable = effects[i]._entryVariable;
                ei.effect = effects[i]._effect;
                ei.targets = effects[i]._target;
                ei.condition = effects[i]._condition;
                a.effects[i] = ei;

                a.intents[i] = new IntentTargetInfo();
                a.intents[i].targets = effects[i]._target;
                a.intents[i].targetIntents = effects[i]._intent == null ? new IntentType[0] : new IntentType[1] { (IntentType)effects[i]._intent };
            }

            return a;
        }
    }
}
