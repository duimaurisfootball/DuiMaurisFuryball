using System.Text;

namespace Dui_Mauris_Furyball
{
    [HarmonyPatch]
    public static class MultiSpecialStoredValuePatches
    {
        [HarmonyPatch(typeof(CombatVisualizationController), nameof(CombatVisualizationController.ShowcaseInfoAttackTooltip))]
        [HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> ModifySpecialStoredValuesAbility(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.Calls(abilityLocData))
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Ldloc_1);
                    yield return new CodeInstruction(OpCodes.Ldloca_S, 2);
                    yield return new CodeInstruction(OpCodes.Call, modifyAbility);
                }
                yield return instruction;
            }
        }

        [HarmonyPatch(typeof(CombatVisualizationController), nameof(CombatVisualizationController.ShowcaseInfoPassiveTooltip))]
        [HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> ModifySpecialStoredValuesPassive(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.Calls(passiveLocData))
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Ldloc_1);
                    yield return new CodeInstruction(OpCodes.Ldloca_S, 2);
                    yield return new CodeInstruction(OpCodes.Call, modifyPassive);
                }
                yield return instruction;
            }
        }

        private static AbilitySO ModifyExtraContentAbility(AbilitySO current, CombatVisualizationController visualization, IReadOnlyDictionary<UnitStoredValueNames, int> storedValues, ref string extraContent)
        {
            if (current is IMultiSpecialStoredValueHaver ability && storedValues != null)
            {
                var extraStoredValues = ability.ExtraStoredValues;
                if (extraStoredValues == null)
                {
                    return current;
                }
                var sb = new StringBuilder();
                if (!string.IsNullOrEmpty(extraContent))
                {
                    sb.Append(extraContent).AppendLine();
                }
                foreach (var seName in extraStoredValues)
                {
                    if (storedValues.TryGetValue(seName, out var val))
                    {
                        var extra = visualization._tooltipData.ProcessStoredValue(seName, val);
                        if (!string.IsNullOrEmpty(extra))
                        {
                            sb.Append(extra).AppendLine();
                        }
                    }
                }
                extraContent = sb.ToString();
            }
            return current;
        }

        private static BasePassiveAbilitySO ModifyExtraContentPassive(BasePassiveAbilitySO current, CombatVisualizationController visualization, IReadOnlyDictionary<UnitStoredValueNames, int> storedValues, ref string extraContent)
        {
            if (current is IMultiSpecialStoredValueHaver passive && storedValues != null)
            {
                var extraStoredValues = passive.ExtraStoredValues;
                if (extraStoredValues == null)
                {
                    return current;
                }
                var sb = new StringBuilder();
                if (!string.IsNullOrEmpty(extraContent))
                {
                    sb.Append(extraContent).AppendLine();
                }
                foreach (var seName in extraStoredValues)
                {
                    if (storedValues.TryGetValue(seName, out var val))
                    {
                        var extra = visualization._tooltipData.ProcessStoredValue(seName, val);
                        if (!string.IsNullOrEmpty(extra))
                        {
                            sb.Append(extra).AppendLine();
                        }
                    }
                }
                extraContent = sb.ToString();
            }
            return current;
        }

        private static MethodInfo abilityLocData = AccessTools.Method(typeof(AbilitySO), nameof(AbilitySO.GetAbilityLocData));
        private static MethodInfo passiveLocData = AccessTools.Method(typeof(BasePassiveAbilitySO), nameof(BasePassiveAbilitySO.GetPassiveLocData));

        private static MethodInfo modifyAbility = AccessTools.Method(typeof(MultiSpecialStoredValuePatches), nameof(ModifyExtraContentAbility));
        private static MethodInfo modifyPassive = AccessTools.Method(typeof(MultiSpecialStoredValuePatches), nameof(ModifyExtraContentPassive));
    }

    public interface IMultiSpecialStoredValueHaver
    {
        public IEnumerable<UnitStoredValueNames> ExtraStoredValues { get; }
    }

    public class MultiSpecialStoredValueAbilitySO : AbilitySO, IMultiSpecialStoredValueHaver
    {
        public UnitStoredValueNames[] extraStoredValues;

        public IEnumerable<UnitStoredValueNames> ExtraStoredValues => extraStoredValues;
}

    public abstract class MultiSpecialStoredValuePassiveSO : BasePassiveAbilitySO, IMultiSpecialStoredValueHaver
    {
        public UnitStoredValueNames[] extraStoredValues;

        public IEnumerable<UnitStoredValueNames> ExtraStoredValues => extraStoredValues;
}

    public class MultiSpecialStoredValuePerfomEffectPassive : PerformEffectPassiveAbility, IMultiSpecialStoredValueHaver
    {
        public UnitStoredValueNames[] extraStoredValues;

        public IEnumerable<UnitStoredValueNames> ExtraStoredValues => extraStoredValues;
}

    public class MultiSpecialStoredValuePerfomEffectOnConnectPassive : Connection_PerformEffectPassiveAbility, IMultiSpecialStoredValueHaver
    {
        public UnitStoredValueNames[] extraStoredValues;

        public IEnumerable<UnitStoredValueNames> ExtraStoredValues => extraStoredValues;
}
}
