namespace Dui_Mauris_Furyball
{
    public class VatCustomSpritesEffect : EffectSO
    {
        public ExtraSpriteType _spriteType;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.IsUnitCharacter)
            {
                CombatManager.Instance.AddUIAction(new CharacterSetExtraSpriteUIAction(caster.ID, _spriteType));
                return true;
            }

            return false;
        }
    }
}
