using UnityEngine;

public class GUIUtil
{
    public static Vector2 CalcTextSize(string str)
    {
        GUIContent content = new GUIContent(str);
        GUIStyle style = GUI.skin.box;

        float sizeX = style.CalcSize(content).x;
        float sizeY = style.CalcHeight(content, sizeX);

        return new Vector2(sizeX, sizeY);
    }
}