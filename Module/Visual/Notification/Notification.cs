using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NotificationData
{
    public string Text;
    public Animator Animation;
    public DateTime AddedTime;

    public NotificationData(string text)
    {
        Text = text;
        Animation = new Animator();
        AddedTime = DateTime.Now;
    }

    public bool IsEnd()
    {
        return (DateTime.Now - AddedTime).TotalSeconds > 3f;
    }
}

public class NotificationManager
{
    public static List<NotificationData> Notifications = new List<NotificationData>();

    public static void Add(string text)
    {
        Notifications.Add(new NotificationData(text));
    }
}

public class Notification : Module
{
    float Speed = 1;
    Vector2 Size = new Vector2(300, 25);

    public Notification() : base("Notification", true, UnityEngine.KeyCode.None) {}

    public override void OnGUI()
    {
        int index = 0;
        foreach (var notif in NotificationManager.Notifications.ToList())
        {
            if (!notif.IsEnd())
            {
                notif.Animation.IncreaseProgress(Speed * Time.deltaTime);
            }
            else
            {
                notif.Animation.DecreaseProgress(Speed * Time.deltaTime);
            }

            GUI.Box(new Rect(((Screen.width - Size.x) / 2) + (Screen.width - (Screen.width - Size.x) / 2) * (1 - Easing.OutExpo(notif.Animation.GetProgress())), 
            (Screen.height / 2) + 100 - (Size.y * index),
            Size.x, Size.y), notif.Text);

            if (notif.IsEnd() && notif.Animation.IsMinimum())
            {
                NotificationManager.Notifications.Remove(notif);
            }

            index++;
        }
    }
}