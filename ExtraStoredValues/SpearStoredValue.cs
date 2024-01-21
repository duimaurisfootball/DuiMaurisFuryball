﻿namespace Dui_Mauris_Furyball.ExtraStoredValues
{
    public class SpearStoredValue
    {
        public static string AddStoredValueName(
            Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
            TooltipTextHandlerSO self, UnitStoredValueNames storedValue, int value)
        {
            string str1;
            if (storedValue == (UnitStoredValueNames)567235)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Spears" + string.Format(": {0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.white) + ">";
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
