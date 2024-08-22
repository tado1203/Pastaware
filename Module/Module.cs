using Pastaware;
using UnityEngine;

public class Module
{
    public string Name;
    public bool IsEnabled;
    public KeyCode Keybind;
    public Animator Animation;

    public Module(string name, bool isEnabled, KeyCode keybind)
    {
        Name = name;
        IsEnabled = isEnabled;
        Keybind = keybind;
        Animation = new Animator();
    }

    public virtual void Update() {}
    public virtual void OnGUI() {}
    public virtual void OnEnable() {}
    public virtual void OnDisable() {}
    public virtual void OnWorldChange() {}

    public void Toggle()
    {
        IsEnabled = !IsEnabled;
        if (IsEnabled)
        {
            Logger.Log("Enabled " + Name);
            NotificationManager.Add("Enabled " + Name);
            OnEnable();
        }
        else
        {
            Logger.Log("Disabled " + Name);
            NotificationManager.Add("Disabled " + Name);
            OnDisable();
        }
    }
}