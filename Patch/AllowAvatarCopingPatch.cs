using HarmonyLib;
using VRC.Core;

[HarmonyPatch(typeof(APIUser), nameof(APIUser.allowAvatarCopying), MethodType.Getter)]
class AllowAvatarCopingPatch
{
    static bool Prefix(ref bool __result)
    {
        __result = true;
        return false;
    }
}