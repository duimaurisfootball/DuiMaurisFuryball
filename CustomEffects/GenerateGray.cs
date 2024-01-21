using System.Collections.Generic;

namespace Dui_Mauris_Furyball
{
    public class GenerateGray : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            ManaColorSO[] array = new ManaColorSO[]
            {
                Pigments.Red,
                Pigments.Yellow,
                Pigments.Purple,
                Pigments.Blue,
                Pigments.Green,
            };
            exitAmount = 0;
            List<int> list = new List<int>();
            List<ManaColorSO> list2 = new List<ManaColorSO>();
            ManaBarSlot[] manaBarSlots = stats.MainManaBar.ManaBarSlots;
            int num = 0;
            foreach (ManaBarSlot manaBarSlot in manaBarSlots)
            {
                bool flag = !manaBarSlot.IsEmpty && manaBarSlot.ManaColor != caster.HealthColor;
                if (flag)
                {
                    int num2 = UnityEngine.Random.Range(0, array.Length);
                    manaBarSlot.SetMana(Pigments.Gray);
                    list.Add(manaBarSlot.SlotIndex);
                    list2.Add(Pigments.Gray);
                    num++;
                    exitAmount++;
                    bool flag2 = num >= this._howmuch;
                    if (flag2)
                    {
                        break;
                    }
                }
            }
            bool flag3 = list.Count > 0;
            if (flag3)
            {
                CombatManager.Instance.AddUIAction(new ModifyManaSlotsUIAction(stats.MainManaBar.ID, list.ToArray(), list2.ToArray()));
            }
            return exitAmount > 0;
        }

        public int _howmuch;
    }
}
