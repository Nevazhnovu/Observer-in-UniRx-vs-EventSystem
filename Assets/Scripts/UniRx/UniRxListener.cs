using System;
using UniRx;
using UnityEngine;

public class UniRxListener : MonoBehaviour
{
    private void Awake()
    {
        SomeScript.DataStream
            .Subscribe(OnReady) // Perform an action when data is fired
            .AddTo(this); // Terminate subscription once object destroys
    }

    private void OnReady(long invokeTime)
    {
        var now = System.DateTime.Now.Ticks;
        Debug.Log("UniRx: Time between message sent and received = "+ TimeSpan.FromTicks(now - invokeTime).TotalMilliseconds.ToString() + " milliseconds");
    }
}
