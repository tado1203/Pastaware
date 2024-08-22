using UnityEngine;
using VRC.Core;
using VRC.SDKBase;

public class VRCUtil
{
    public enum TrustRanks
    {
        NIGGER,
		NEWUSER,
		USER,
		KNOWN,
		TRUSTED,
		VETERAN,
		LEGENDARY
    }

    public static bool IsInWorld()
    {
        return Networking.LocalPlayer != null;
    }

    public static TrustRanks GetTrustRank(APIUser user)
    {
        if (user != null && user.tags != null && user.tags.Count > 0)
		{
			if (user.tags.Contains("system_legend") && user.tags.Contains("system_trust_legend") && user.tags.Contains("system_trust_trusted"))
			{
				return TrustRanks.LEGENDARY;
			}
			if (user.tags.Contains("system_trust_legend") && user.tags.Contains("system_trust_trusted"))
			{
				return TrustRanks.VETERAN;
			}
			if (user.tags.Contains("system_trust_veteran") && user.tags.Contains("system_trust_trusted"))
			{
				return TrustRanks.TRUSTED;
			}
			if (user.tags.Contains("system_trust_trusted"))
			{
				return TrustRanks.KNOWN;
			}
			if (user.tags.Contains("system_trust_known"))
			{
				return TrustRanks.USER;
			}
			if (user.tags.Contains("system_trust_basic"))
			{
				return TrustRanks.NEWUSER;
			}
		}

        return TrustRanks.NIGGER;
    }

    public static TrustRanks GetTrustRank(VRCPlayerApi player)
    {
        return GetTrustRank(GetAPIUser(player));
    }

    public static APIUser GetAPIUser(Player player)
    {
        return player.prop_APIUser_0;
    }

    public static APIUser GetAPIUser(VRCPlayerApi player)
    {
        return GetAPIUser(GetPlayer(player));
    }

    public static Player GetPlayer(VRCPlayerApi player)
    {
        return player.gameObject.GetComponent<Player>();
    }

	public static PlayerNet GetPlayerNet(VRCPlayerApi player)
	{
		return GetPlayerNet(GetPlayer(player));
	}

	public static PlayerNet GetPlayerNet(Player player)
	{
		return player._playerNet;
	}

	public static int GetPing(PlayerNet playerNet)
	{
		return playerNet.prop_Int16_0;
	}

	public static int GetFPS(PlayerNet playerNet)
	{
		if (playerNet.prop_Byte_0 == 0)
		{
			return 0;
		}
		return 1000 / playerNet.prop_Byte_0;
	}

	public static void SetHighlightsFX(Renderer renderer, bool v)
	{
		HighlightsFX.Method_Internal_Static_Void_Renderer_Boolean_PDM_0(renderer, v);
	}
}