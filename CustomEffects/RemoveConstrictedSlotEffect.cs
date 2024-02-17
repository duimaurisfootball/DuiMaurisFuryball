namespace Dui_Mauris_Furyball
{
    public class RemoveSlotEffect : EffectSO
    {

        public SlotStatusEffectType _statusEffectType = SlotStatusEffectType.Constricted;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                bool isTargetCharacterSlot = targets[i].IsTargetCharacterSlot;
                bool flag = isTargetCharacterSlot;
                if (flag)
                {
                    exitAmount += stats.combatSlots.CharacterSlots[targets[i].SlotID].TryRemoveSlotStatusEffect(this._statusEffectType);
                }
                else
                {
                    exitAmount += stats.combatSlots.EnemySlots[targets[i].SlotID].TryRemoveSlotStatusEffect(this._statusEffectType);
                }
            }
            return exitAmount > 0;
        }
    }
}
