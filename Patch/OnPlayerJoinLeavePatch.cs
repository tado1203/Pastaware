using HarmonyLib;

[HarmonyPatch(typeof(idk), nameof(idk.OnPlayerJoined))]
class OnPlayerJoinPatch
{
    static void Prefix(Player param_1)
    {
        if (param_1.prop_VRCPlayerApi_0.isLocal)
        {
            foreach (var module in ModuleManager.Modules)
            {
                module.OnWorldChange();
            }
        }
        else
        {
            Logger.Log($"{param_1.prop_VRCPlayerApi_0.displayName} joined");
            NotificationManager.Add($"{param_1.prop_VRCPlayerApi_0.displayName} joined");
        }
    }
}

[HarmonyPatch(typeof(idk), nameof(idk.OnPlayerLeft))]
class OnPlayerLeftPatch
{
    static void Prefix(Player param_1)
    {
        if (!param_1.prop_VRCPlayerApi_0.isLocal)
        {
            Logger.Log($"{param_1.prop_VRCPlayerApi_0.displayName} left");
            NotificationManager.Add($"{param_1.prop_VRCPlayerApi_0.displayName} left");
        }
    }
}