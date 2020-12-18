
using  System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class Notification : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        BuiltDefaultNotifChannel();
    }

    public void SendSimpleNotif()
    {
        string title = "Simple Notif";
        string text = "This is a simple notif";
        DateTime fireTime = DateTime.Now.AddSeconds(10);

        var notif = new AndroidNotification(title,text,fireTime);
        AndroidNotificationCenter.SendNotification(notif, "default");

    }
    public void BuiltDefaultNotifChannel()
    {
        string channel_id = "default";

        string channel_name = "Default Channel";

        Importance importance = Importance.Default;

        string channel_description = "Default channel for this game";

       var channel = new AndroidNotificationChannel(channel_id, channel_name, channel_description,importance);

       AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }
}
