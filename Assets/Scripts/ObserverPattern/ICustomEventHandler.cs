using UnityEngine.EventSystems;

public interface ICustomEventHandler : IEventSystemHandler { }

public interface ISuperCustomEventHandler : ICustomEventHandler
{
    public void OnReady(long invokeTime);
}