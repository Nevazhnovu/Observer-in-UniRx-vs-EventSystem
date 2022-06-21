using System;
using UnityEngine;

public static class Messenger
{
    public static void AddListener<T>(GameObject go) where T : ICustomEventHandler
    {
        BroadcastReceivers.RegisterBroadcastReceiver<T>(go);
    }

    public static void RemoveListener<T>(GameObject go) where T : ICustomEventHandler
    {
        BroadcastReceivers.UnregisterBroadcastReceiver<T>(go);
    }

    public static void Broadcast<T>(params object[] list) where T : ICustomEventHandler
    {
        Debug.LogWarning("T == " + typeof(T).Name);
        switch (typeof(T).Name)
        {
            case nameof(ISuperCustomEventHandler):
                BroadcastEventDispatcher.Execute<ISuperCustomEventHandler>(null, (i, d) => i.OnReady((long)list[0]));
                break;
            default: break;
        }
    }
}