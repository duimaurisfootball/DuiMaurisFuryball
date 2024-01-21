namespace Dui_Mauris_Furyball.CustomEffects
{
    public class PercentageValueModifierRoundUp : IntValueModifier
    {
        public readonly float percentage;

        public readonly bool doesIncrease;

        public PercentageValueModifierRoundUp(bool dmgDealt, int percentage, bool doesIncrease)
            : base(dmgDealt ? 4 : 62)
        {
            this.percentage = Mathf.Max(percentage, 0);
            this.doesIncrease = doesIncrease;
        }

        public override int Modify(int value)
        {
            float f = percentage * (float)value / 100f;
            Debug.Log(f);
            int num = Mathf.Max(1, Mathf.FloorToInt(f));
            Debug.Log(num);
            //if (!doesIncrease)
            //{
            //    return Mathf.Max(0, value - num);
            // }

            return num;
        }
    }
}
