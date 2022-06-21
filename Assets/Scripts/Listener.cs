using UnityEngine;

public class Listener : MonoBehaviour, ISuperCustomEventHandler
{
    
    private void Awake()
    {
        Messenger.AddListener<ISuperCustomEventHandler>(this.gameObject);
    }
    
    public void OnReady(long invokeTime)
    {
        Debug.Log("Time between message sent and received = "+ (invokeTime - MessagePusher.broadcastTime).ToString() + " ticks");
    }
    
    private void OnDestroy()
    {
        Messenger.RemoveListener<ISuperCustomEventHandler>(this.gameObject);
    }
}