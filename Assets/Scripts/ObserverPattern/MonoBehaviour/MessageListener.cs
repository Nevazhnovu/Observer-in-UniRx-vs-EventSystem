using System;
using UnityEngine;

public class MessageListener : MonoBehaviour, ISuperCustomEventHandler
{
    private void Awake()
    {
        Messenger.AddListener<ISuperCustomEventHandler>(this.gameObject);
    }
    
    public void OnReady(long invokeTime)
    {
        var now = System.DateTime.Now.Ticks;
        Debug.Log("Time between message sent and received = "+ TimeSpan.FromTicks(now - invokeTime).TotalMilliseconds.ToString() + " milliseconds");
    }
    
    private void OnDestroy()
    {
        Messenger.RemoveListener<ISuperCustomEventHandler>(this.gameObject);
    }
}