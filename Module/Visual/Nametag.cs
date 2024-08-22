using UnityEngine;
using VRC.SDKBase;

public class Nametag : Module
{
    public Nametag() : base("Nametag", true, KeyCode.N) {}

    public override void OnGUI()
    {
        if (VRCUtil.IsInWorld() && IsEnabled)
        {
            foreach (var player in VRCPlayerApi.AllPlayers)
            {
                if (player.isLocal) continue;

                Vector3 pos = Camera.main.WorldToScreenPoint(player.gameObject.transform.position);
                Vector3 headpos = Camera.main.WorldToScreenPoint(player.GetBonePosition(HumanBodyBones.Head));
                
                PlayerNet playerNet = VRCUtil.GetPlayerNet(player);

                if (pos.z < 0f) continue;

                float height = headpos.y - pos.y;
                Vector2 nameTextSize = GUIUtil.CalcTextSize(player.displayName);
                Vector2 statusTextSize = GUIUtil.CalcTextSize($"[F: {VRCUtil.GetFPS(playerNet)}][P: {VRCUtil.GetPing(playerNet)}]");

                GUI.Label(new Rect(pos.x + 1 - (nameTextSize.x / 2), Screen.height - pos.y - height + 1, 200, 200), $"<color=black>{player.displayName}</color>");
                GUI.Label(new Rect(pos.x - 1 - (nameTextSize.x / 2), Screen.height - pos.y - height + 1, 200, 200), $"<color=black>{player.displayName}</color>");
                GUI.Label(new Rect(pos.x - 1 - (nameTextSize.x / 2), Screen.height - pos.y - height - 1, 200, 200), $"<color=black>{player.displayName}</color>");
                GUI.Label(new Rect(pos.x + 1 - (nameTextSize.x / 2), Screen.height - pos.y - height - 1, 200, 200), $"<color=black>{player.displayName}</color>");

                GUI.Label(new Rect(pos.x + 1 - statusTextSize.x / 2, Screen.height - pos.y - height - statusTextSize.y + 1, 200, 200), $"<color=black>[F: {VRCUtil.GetFPS(playerNet)}][P: {VRCUtil.GetPing(playerNet)}]</color>");
                GUI.Label(new Rect(pos.x - 1 - statusTextSize.x / 2, Screen.height - pos.y - height - statusTextSize.y + 1, 200, 200), $"<color=black>[F: {VRCUtil.GetFPS(playerNet)}][P: {VRCUtil.GetPing(playerNet)}]</color>");
                GUI.Label(new Rect(pos.x - 1 - statusTextSize.x / 2, Screen.height - pos.y - height - statusTextSize.y - 1, 200, 200), $"<color=black>[F: {VRCUtil.GetFPS(playerNet)}][P: {VRCUtil.GetPing(playerNet)}]</color>");
                GUI.Label(new Rect(pos.x + 1 - statusTextSize.x / 2, Screen.height - pos.y - height - statusTextSize.y - 1, 200, 200), $"<color=black>[F: {VRCUtil.GetFPS(playerNet)}][P: {VRCUtil.GetPing(playerNet)}]</color>");

                GUI.Label(new Rect(pos.x - statusTextSize.x / 2, Screen.height - pos.y - height - statusTextSize.y, 200, 200), $"[F: {VRCUtil.GetFPS(playerNet)}][P: {VRCUtil.GetPing(playerNet)}]");

                switch (VRCUtil.GetTrustRank(player))
                {
                    case VRCUtil.TrustRanks.NIGGER:
                        GUI.Label(new Rect(pos.x - nameTextSize.x / 2, Screen.height - pos.y - height, 200, 200), $"<color=white>{player.displayName}</color>");
                        break;
                    case VRCUtil.TrustRanks.NEWUSER:
                        GUI.Label(new Rect(pos.x - nameTextSize.x / 2, Screen.height - pos.y - height, 200, 200), $"<color=blue>{player.displayName}</color>");
                        break;
                    case VRCUtil.TrustRanks.USER:
                        GUI.Label(new Rect(pos.x - nameTextSize.x / 2, Screen.height - pos.y - height, 200, 200), $"<color=green>{player.displayName}</color>");
                        break;
                    case VRCUtil.TrustRanks.KNOWN:
                        GUI.Label(new Rect(pos.x - nameTextSize.x / 2, Screen.height - pos.y - height, 200, 200), $"<color=red>{player.displayName}</color>");
                        break;
                    case VRCUtil.TrustRanks.TRUSTED:
                        GUI.Label(new Rect(pos.x - nameTextSize.x / 2, Screen.height - pos.y - height, 200, 200), $"<color=magenta>{player.displayName}</color>");
                        break;
                }
            }
        }
    }
}