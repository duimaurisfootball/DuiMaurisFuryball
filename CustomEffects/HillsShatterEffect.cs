namespace Dui_Mauris_Furyball
{
    internal class HillsShatterEffect : EffectSO
    {
        public float _waitTime;
        public string _sound;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                for (int i = 0; i < 1;)
                {
                    if (!stats.combatSlots.SlotContainsSlotStatusEffect(targetSlotInfo.SlotID, targetSlotInfo.IsTargetCharacterSlot, SlotStatusEffectType.Shield))
                    {
                        i++;
                    }
                    if (targetSlotInfo.HasUnit)
                    {
                        CombatManager.Instance.AddUIAction(new PlayStatusEffectSoundAndWaitUIAction(_sound, _waitTime));
                        int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                        int amount = UnityEngine.Random.Range(base.PreviousExitValue, entryVariable + 1);
                        DamageInfo damageInfo;
                        amount = caster.WillApplyDamage(amount, targetSlotInfo.Unit);
                        damageInfo = targetSlotInfo.Unit.Damage(amount, caster, DeathType.Basic, targetSlotOffset, true, true, false);
                        exitAmount += damageInfo.damageAmount;
                    }
                }
            }

            if (exitAmount > 0)
            {
                caster.DidApplyDamage(exitAmount);
            }

            return exitAmount > 0;
        }
    }
}
