namespace Dui_Mauris_Furyball
{
    public class ComplexionBoneSpursStoredValue
    {
        public static string AddStoredValueName(
                Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
                TooltipTextHandlerSO self, UnitStoredValueNames storedValue, int value)
        {
            string str1;
            if (storedValue == (UnitStoredValueNames)873291)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Bone Spurs" + string.Format(" +{0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.blue) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }
    }
}
