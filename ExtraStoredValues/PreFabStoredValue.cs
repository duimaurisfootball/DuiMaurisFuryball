namespace Dui_Mauris_Furyball
{
    public class PreFabStoredValue
    {
        public static string AddStoredValueName(
            Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
            TooltipTextHandlerSO self, UnitStoredValueNames storedValue, int value)
        {
            string str1;
            if (storedValue == (UnitStoredValueNames)555770)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "who the hell is steve jobs?" + string.Format(" +{0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.yellow) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }
        //ligma balls
    }
}
