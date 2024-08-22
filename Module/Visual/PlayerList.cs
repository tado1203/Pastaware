using UnityEngine;
using VRC.SDKBase;

public class PlayerList : Module
{
    public PlayerList() : base("PlayerList", true, UnityEngine.KeyCode.None) {}

    public override void OnGUI()
    {
        if (VRCUtil.IsInWorld() && IsEnabled)
        {
            float offsetY = 0f;

            GUI.Box(new Rect(0, (Screen.height / 2) - 200 - 20, 300, 50 + 14 * VRCPlayerApi.AllPlayers.Count), "");
            
            GUI.Label(new Rect(0, (Screen.height / 2) - 200 - 20, 300, 200), $"<size=20>PlayerList: {VRCPlayerApi.AllPlayers.Count}</size>");

            foreach (var player in VRCPlayerApi.AllPlayers)
            {
                PlayerNet playerNet = VRCUtil.GetPlayerNet(player);

                switch (VRCUtil.GetTrustRank(player))
                {
                    case VRCUtil.TrustRanks.NIGGER:
                        GUI.Label(new Rect(0, (Screen.height / 2) - 200 + offsetY, 300, 200), $"<size=14><color=white>{player.displayName}</color>[F: {VRCUtil.GetFPS(playerNet)}][P: {VRCUtil.GetPing(playerNet)}]</size>");
                        break;
                    case VRCUtil.TrustRanks.NEWUSER:
                        GUI.Label(new Rect(0, (Screen.height / 2) - 200 + offsetY, 300, 200), $"<size=14><color=blue>{player.displayName}</color>[F: {VRCUtil.GetFPS(playerNet)}][P: {VRCUtil.GetPing(playerNet)}]</size>");
                        break;
                    case VRCUtil.TrustRanks.USER:
                        GUI.Label(new Rect(0, (Screen.height / 2) - 200 + offsetY, 300, 200), $"<size=14><color=green>{player.displayName}</color>[F: {VRCUtil.GetFPS(playerNet)}][P: {VRCUtil.GetPing(playerNet)}]</size>");
                        break;
                    case VRCUtil.TrustRanks.KNOWN:
                        GUI.Label(new Rect(0, (Screen.height / 2) - 200 + offsetY, 300, 200), $"<size=14><color=red>{player.displayName}</color>[F: {VRCUtil.GetFPS(playerNet)}][P: {VRCUtil.GetPing(playerNet)}]</size>");
                        break;
                    case VRCUtil.TrustRanks.TRUSTED:
                        GUI.Label(new Rect(0, (Screen.height / 2) - 200 + offsetY, 300, 200), $"<size=14><color=magenta>{player.displayName}</color>[F: {VRCUtil.GetFPS(playerNet)}][P: {VRCUtil.GetPing(playerNet)}]</size>");
                        break;
                }
                
                offsetY += 14;
            }
        }  
    }
}