using HarmonyLib;

public class PatchManager
{
    public static void PatchAll()
    {
        Harmony harmony = new Harmony("Patcher");
        
        harmony.PatchAll(typeof(OnPlayerJoinPatch));
        harmony.PatchAll(typeof(OnPlayerLeftPatch));

        harmony.PatchAll(typeof(AllowAvatarCopingPatch));
    }
}