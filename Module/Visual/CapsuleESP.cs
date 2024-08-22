using System.Collections.Generic;
using UnityEngine;
using VRC.SDKBase;

public class CapsuleESP : Module
{
    public CapsuleESP() : base("CapsuleESP", true, KeyCode.None) {}

    List<MeshRenderer> ActiveESP = new List<MeshRenderer>();

    public override void Update()
    {
        if (VRCUtil.IsInWorld() && IsEnabled)
        {
            if (ActiveESP.Count != VRCPlayerApi.AllPlayers.Count - 1)
            {
                foreach (var player in VRCPlayerApi.AllPlayers)
                {
                    Transform transform = player.gameObject.transform.Find("SelectRegion");
                    if (transform != null)
                    {
                        MeshRenderer renderer = transform.GetComponent<MeshRenderer>();
                        if (renderer != null)
                        {
                            VRCUtil.SetHighlightsFX(renderer, true);

                            ActiveESP.Add(renderer);
                        }
                    }
                }
            }
        }
    }

    public override void OnDisable()
    {
        if (VRCUtil.IsInWorld())
        {
            foreach (var renderer in ActiveESP)
            {
                VRCUtil.SetHighlightsFX(renderer, false);
            }
        }
    }
}