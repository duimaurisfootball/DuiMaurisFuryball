namespace Dui_Mauris_Furyball
{
    public class UnboundedShieldEffect : EffectSO
    {
        public int _repeatChance = 0;
        public int _averageShift = 1;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool flag = false;
            int ball = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                ball = 1 - _averageShift;
                for (int i = 0; i < _averageShift;)
                {
                    ball += entryVariable;
                    if (_repeatChance <= UnityEngine.Random.Range(0, 100))
                    {
                        i++;
                    }
                }
                ball += UnityEngine.Random.Range(0, entryVariable - 1);
            }
            stats.slotStatusEffectDataBase.TryGetValue(SlotStatusEffectType.Shield, out var value);
            for (int i = 0; i < targets.Length; i++)
            {
                var shield_SlotStatusEffect = new Shield_SlotStatusEffect(targets[i].SlotID, ball, targets[i].IsTargetCharacterSlot);
                shield_SlotStatusEffect.SetEffectInformation(value);
                if (stats.combatSlots.ApplySlotStatusEffect(targets[i].SlotID, targets[i].IsTargetCharacterSlot, ball, shield_SlotStatusEffect))
                {
                    exitAmount += ball;
                }
            }

            return flag;
        }
    }
}
