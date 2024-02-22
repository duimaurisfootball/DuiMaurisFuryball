namespace Dui_Mauris_Furyball
{
    public class Targetting_ByUnit_Side_Special : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot;

        public bool getAllUnitSlots;

        public int[] ExceptionSlots = new int[] { 0 };
        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => getAllUnitSlots;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            return slots.GetAllUnitTargetSlots((isCasterCharacter && getAllies && !Slots.SlotTarget(ExceptionSlots, true)) || (!isCasterCharacter && !getAllies && !Slots.SlotTarget(ExceptionSlots, false)), getAllUnitSlots, ignoreCastSlot ? casterSlotID : (-1));
        }
    }
}
