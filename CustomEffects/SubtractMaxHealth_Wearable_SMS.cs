namespace Dui_Mauris_Furyball.CustomEffects
{
    internal class SubtractMaxHealth_Wearable_SMS : WearableStaticModifierSetterSO
    {
        [SerializeField]
        public int maxHealthChange;

        [SerializeField]
        public bool isChangePercentage;

        public override void OnAttachedToCharacter(WearableStaticModifiers modifiers, CharacterSO character, int rank)
        {
            if (isChangePercentage)
            {
                int rank2 = character.ClampRank(rank);
                int maxHealth = character.GetMaxHealth(rank2);
                modifiers.MaximumHealthModifier = -maxHealthChange * maxHealth / 100;
            }
            else
            {
                modifiers.MaximumHealthModifier = -maxHealthChange;
            }
        }

        public override void OnDettachedFromCharacter(WearableStaticModifiers modifiers)
        {
            modifiers.MaximumHealthModifier = 0;
        }
    }
}
