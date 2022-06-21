using UnityEngine;

public class MessagePusher : MonoBehaviour
{
    public static long broadcastTime;

    private void Start()
    {
        broadcastTime = System.DateTime.Now.Ticks;
        Messenger.Broadcast<ISuperCustomEventHandler>(broadcastTime);
    }
}
