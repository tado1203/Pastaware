using VRC.SDKBase;

public class Speed : Module
{
    public Speed() : base("Speed", false, UnityEngine.KeyCode.X) {}

    float OriginalWalkSpeed;

    public override void OnWorldChange()
    {
        OriginalWalkSpeed = Networking.LocalPlayer.GetWalkSpeed();
    }

    public override void OnEnable()
    {
        if (VRCUtil.IsInWorld())
        {
            OriginalWalkSpeed = Networking.LocalPlayer.GetWalkSpeed();

            Networking.LocalPlayer.SetWalkSpeed(10);
        }
    }

    public override void OnDisable()
    {
        if (VRCUtil.IsInWorld())
        {
            Networking.LocalPlayer.SetWalkSpeed(OriginalWalkSpeed);
        }
    }
}