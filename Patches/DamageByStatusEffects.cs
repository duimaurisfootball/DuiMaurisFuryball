namespace Dui_Mauris_Furyball
{
    [HarmonyPatch]
    public static class WillApplyDamagePatch
    {
        public const string WILL_APPLY_DAMAGE_CONTEXT_EVENT = "Dui_Mauris_Football.Furyball_WillApplyDamageContext";


        private static MethodInfo gmv = AccessTools.Method(typeof(DamageDealtValueChangeException), nameof(DamageDealtValueChangeException.GetModifiedValue));
        private static MethodInfo context = AccessTools.Method(typeof(WillApplyDamagePatch), nameof(AddContextTrigger));

        [HarmonyPatch(typeof(CharacterCombat), nameof(CharacterCombat.WillApplyDamage))]
        [HarmonyPatch(typeof(EnemyCombat), nameof(EnemyCombat.WillApplyDamage))]
        [HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> AddStuff(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.Calls(gmv))
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Ldarg_2);
                    yield return new CodeInstruction(OpCodes.Call, context);
                }
                yield return instruction;
            }
        }

        private static DamageDealtValueChangeException AddContextTrigger(DamageDealtValueChangeException ex, IUnit attacker, IUnit target)
        {
            CombatManager.Instance.PostNotification(WILL_APPLY_DAMAGE_CONTEXT_EVENT, attacker, new WillApplyDamageContext(ex, target));
            return ex;
        }
    }

    public class WillApplyDamageContext
    {
        public DamageDealtValueChangeException exception;
        public IUnit target;

        public WillApplyDamageContext(DamageDealtValueChangeException ex, IUnit t)
        {
            exception = ex;
            target = t;
        }
    }
}

