namespace Dui_Mauris_Furyball
{
    public static class BrutalAPIExtensions
    {
        public static void AddLevelWithCustomAbilities(this Character ch, int health, CharacterAbility[] abilities, int level)
        {
            var data = new CharacterRankedData();
            data.rankAbilities = new CharacterAbility[abilities.Length];
            data.health = health;
            for (int i = 0; i < abilities.Length; i++)
            {
                data.rankAbilities[i] = abilities[i];
            }
            ch.levels[level] = data;
        }
    }
}
