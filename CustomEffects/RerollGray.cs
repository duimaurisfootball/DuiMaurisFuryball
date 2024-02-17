namespace Dui_Mauris_Furyball
{
    public class RerollGray : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            var slots = new List<int>();
            var manaBar = stats.MainManaBar.ManaBarSlots;
            for (var i = 0; i < manaBar.Length; i++)
            {
                var slot = manaBar[i];
                if (slot != null && !slot.IsEmpty && slot.ManaColor != Pigments.Gray)
                {
                    slots.Add(i);
                }
            }
            var slotsToTransform = new List<int>();
            var pigments = new List<ManaColorSO>();
            while (slots.Count > 0 && slotsToTransform.Count < entryVariable)
            {
                var idx = UnityEngine.Random.Range(0, slots.Count);
                slotsToTransform.Add(slots[idx]);
                slots.RemoveAt(idx);
                pigments.Add(Pigments.Gray);
                exitAmount++;
            }
            if (slotsToTransform.Count > 0)
            {
                CombatManager.Instance.AddUIAction(new ModifyManaSlotsUIAction(stats.MainManaBar.ID, slotsToTransform.ToArray(), pigments.ToArray()));
            }
            return exitAmount > 0;
        }

    }
}
