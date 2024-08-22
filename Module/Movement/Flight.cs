using UnityEngine;
using VRC.SDKBase;

public class Flight : Module
{
    public Flight() : base("Flight", false, KeyCode.F) {}

    float Speed = 5f;

    public override void Update()
    {
        if (Networking.LocalPlayer != null && IsEnabled)
        {
            VRCPlayerApi localplayer = Networking.LocalPlayer;
            if (localplayer.IsUserInVR())
            {
                if (Input.GetAxis("Vertical") != 0f)
                {
                    localplayer.gameObject.transform.position += localplayer.gameObject.transform.forward * Speed * Time.deltaTime * Input.GetAxis("Vertical"); 
                }
                if (Input.GetAxis("Horizontal") != 0f)
                {
                    localplayer.gameObject.transform.position += localplayer.gameObject.transform.right * Speed * Time.deltaTime * Input.GetAxis("Horizontal"); 
                }
                if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") != 0f)
                {
                    localplayer.gameObject.transform.position += localplayer.gameObject.transform.up * Speed * Time.deltaTime * Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical");
                }

                Networking.LocalPlayer.SetVelocity(Vector3.zero);
            }
            else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    localplayer.gameObject.transform.position += localplayer.gameObject.transform.forward * Speed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    localplayer.gameObject.transform.position -= localplayer.gameObject.transform.forward * Speed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    localplayer.gameObject.transform.position -= localplayer.gameObject.transform.right * Speed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    localplayer.gameObject.transform.position += localplayer.gameObject.transform.right * Speed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    localplayer.gameObject.transform.position -= localplayer.gameObject.transform.up * Speed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.E))
                {
                    localplayer.gameObject.transform.position += localplayer.gameObject.transform.up * Speed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Speed = 30f;
                }
                else
                {
                    Speed = 5f;
                }

                Networking.LocalPlayer.SetVelocity(Vector3.zero);
            }

            return;
        }
    }

    public override void OnEnable()
    {
        if (Networking.LocalPlayer != null)
        {
            Networking.LocalPlayer.gameObject.GetComponent<CharacterController>().enabled = false;
        }
    }

    public override void OnDisable()
    {
        if (Networking.LocalPlayer != null)
        {
            Networking.LocalPlayer.gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }

    public override void OnWorldChange()
    {
        if (IsEnabled)
        {
            Networking.LocalPlayer.gameObject.GetComponent<CharacterController>().enabled = false;
        }
    }
}