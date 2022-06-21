using UnityEngine;
using UnityEngine.EventSystems;

internal class BroadcastEventDispatcher
{
    public static void Execute<T>(BaseEventData eventData, ExecuteEvents.EventFunction<T> functor) where T : ICustomEventHandler
    {
        var handlers = BroadcastReceivers.GetHandlersForEvent<T>();
        if (handlers == null) return;
        Debug.Log($"{typeof(T).Name} has {handlers.Count} invokable instances");
        foreach (var handler in handlers)
        {
            ExecuteEvents.Execute<T>(handler, eventData, functor);
        }
    }
}