[HarmonyPatch]
public static class DisjointedStatusPassivePatch
{
    public const string ANYONE_MOVED = "Dui_Mauris_Football.Furyball_AnyoneMoved";

    [HarmonyPatch(typeof(EnemyCombat), nameof(EnemyCombat.SwappedTo))]
    [HarmonyPatch(typeof(CharacterCombat), nameof(CharacterCombat.SwappedTo))]
    [HarmonyPatch(typeof(EnemyCombat), nameof(EnemyCombat.SwapTo))]
    [HarmonyPatch(typeof(CharacterCombat), nameof(CharacterCombat.SwapTo))]
    [HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> AddNotification(IEnumerable<CodeInstruction> instructions)
    {
        foreach (var instruction in instructions)
        {
            if (instruction.opcode == OpCodes.Ret)
            {
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return new CodeInstruction(OpCodes.Ldloc_0);
                yield return new CodeInstruction(OpCodes.Call, postnotif);
            }
            yield return instruction;
        }
    }

    private static void PostAnyoneMovedNotification(IUnit unit, int oldsid)
    {
        foreach (var kvp in CombatManager.Instance._stats.EnemiesOnField)
        {
            CombatManager.Instance.PostNotification(ANYONE_MOVED, kvp.Value, new AnyoneMovedNotificationInfo(unit, oldsid));
        }
        foreach (var kvp in CombatManager.Instance._stats.CharactersOnField)
        {
            CombatManager.Instance.PostNotification(ANYONE_MOVED, kvp.Value, new AnyoneMovedNotificationInfo(unit, oldsid));
        }
    }

    private static MethodInfo postnotif = AccessTools.Method(typeof(DisjointedStatusPassivePatch), nameof(PostAnyoneMovedNotification));
}

public class AnyoneMovedNotificationInfo(IUnit u, int oldsid)
{
    public IUnit unit = u;
    public int oldSlotId = oldsid;
}