﻿using System;
using System.Collections.Generic;
using UnityEngine;

internal static class BroadcastReceivers
{
    private static readonly IDictionary<Type, IList<GameObject>> BroadcastsReceivers =
        new Dictionary<Type, IList<GameObject>>();

    public static IList<GameObject> GetHandlersForEvent<T>() where T : ICustomEventHandler
    {
        if (!BroadcastsReceivers.ContainsKey(typeof(T)))
        {
            return null;
        }
        return BroadcastsReceivers[typeof(T)];
    }

    public static void RegisterBroadcastReceiver<T>(GameObject go) where T : ICustomEventHandler
    {
        if (BroadcastsReceivers.ContainsKey(typeof(T)))
        {
            BroadcastsReceivers[typeof(T)].Add(go);
        }
        else
        {
            BroadcastsReceivers.Add(typeof(T), new List<GameObject>());
            BroadcastsReceivers[typeof(T)].Add(go);
        }
    }

    public static void UnregisterBroadcastReceiver<T>(GameObject go) where T : ICustomEventHandler
    {
        if (BroadcastsReceivers.ContainsKey(typeof(T)) && BroadcastsReceivers[typeof(T)].Contains(go))
        {
            BroadcastsReceivers[typeof(T)].Remove(go);
        }
        else
        {
            Debug.LogWarning($"{go.name} is not subscribed to handle {typeof(T)}");
        }
    }
}