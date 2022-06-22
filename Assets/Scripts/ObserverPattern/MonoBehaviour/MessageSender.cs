using UnityEngine;

public class MessageSender : MonoBehaviour
{
    private void Start()
    {
        var broadcastTime = System.DateTime.Now.Ticks;
        Messenger.Broadcast<ISuperCustomEventHandler>(broadcastTime);
    }
}
