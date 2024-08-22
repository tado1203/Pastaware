global using Player = MonoBehaviourPublicAPOb_vOb_pBo_UObBoVRUnique;
global using VRCPlayer = MonoBehaviour1PublicOb_pOb_s_pBoGaOb_pStUnique;
global using HighlightsFX = MonoBehaviourPublicInLi1MeHaInMeRe1MeUnique;
global using PlayerNet = MonoBehaviour1PublicOb_vInByInBoObBySiObUnique;
global using idk = MonoBehaviourPublicDaBoAc1ObDiOb2InHaUnique;

using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using UnityEngine;

namespace Pastaware;

    [BepInPlugin("Pastaware", "Pastaware", "1.0")]
    public class Main : BasePlugin
    {
        internal static new ManualLogSource Log;

        public override void Load()
        {
            Log = base.Log;

            AddComponent<MainMonoBehaviour>();
        }
    }

public class MainMonoBehaviour : MonoBehaviour
{
    public MainMonoBehaviour(IntPtr handle) : base(handle) {}

    void OnEnable()
    {
        ModuleManager.InitModules();
        PatchManager.PatchAll();
    }

    void Update()
    {
        foreach (var module in ModuleManager.Modules)
        {
            module.Update();
            if (Input.GetKeyDown(module.Keybind) && Input.GetKey(KeyCode.LeftShift))
            {
                module.Toggle();
            }
        }
    }

    void OnGUI()
    {
        foreach (var module in ModuleManager.Modules)
        {
            module.OnGUI();
        }
    }
}