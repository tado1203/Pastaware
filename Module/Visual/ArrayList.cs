using UnityEngine;

public class ArrayList : Module
{
    public ArrayList() : base("ArrayList", true, KeyCode.None) {}

    float Speed = 2f;

    public override void OnGUI()
    {
        int offsetY = 0;

        foreach (var module in ModuleManager.Modules)
        {
            Vector2 textsize = GUIUtil.CalcTextSize("<size=30>" + module.Name + "</size>");
            
            if (module.IsEnabled)
            {
                GUI.Label(new Rect(Screen.width - (textsize.x * Easing.OutQuart(module.Animation.GetProgress())), offsetY, 400, 400), "<size=30>" + module.Name + "</size>");
                
                module.Animation.IncreaseProgress(Speed * Time.deltaTime);
                offsetY += 30;
            }
            else
            {
                GUI.Label(new Rect(Screen.width - (textsize.x * Easing.OutQuart(module.Animation.GetProgress())), offsetY, 400, 400), "<size=30>" + module.Name + "</size>");
                
                module.Animation.DecreaseProgress(Speed * Time.deltaTime);
                if (!module.Animation.IsMinimum())
                {
                    offsetY += 30;
                }
            }
        }
    }
}