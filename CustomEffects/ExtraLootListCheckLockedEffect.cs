namespace Dui_Mauris_Furyball
{
    public class ExtraLootListCheckLockedEffect : EffectSO
    {
        public LootItemProbability[] _lootableItems;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (entryVariable <= 0)
            {
                return false;
            }

            int num = 0;
            for (int i = 0; i < this._lootableItems.Length; i++)
            {
                if (LoadedAssetsHandler.GetWearable(_lootableItems[i].itemName) != null && (stats.InfoHolder.Game.IsItemUnlocked(_lootableItems[i].itemName) || !LoadedAssetsHandler.GetWearable(_lootableItems[i].itemName).startsLocked))
                {
                    num += _lootableItems[i].probability;
                }
            }

            for (int j = 0; j < entryVariable; j++)
            {
                int num2 = UnityEngine.Random.Range(0, num);
                for (int k = 0; k < _lootableItems.Length; k++)
                {
                    if (LoadedAssetsHandler.GetWearable(_lootableItems[k].itemName) != null && (stats.InfoHolder.Game.IsItemUnlocked(_lootableItems[k].itemName) || !LoadedAssetsHandler.GetWearable(_lootableItems[k].itemName).startsLocked))
                    {
                        if (num2 < _lootableItems[k].probability)
                        {
                            stats.AddExtraLootAddition(_lootableItems[k].itemName);
                            exitAmount++;
                            break;
                        }
                    }
                    num2 -= _lootableItems[k].probability;
                }
            }

            return exitAmount > 0;
        }
    }
}
