using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameEvent
{
    OnPlacementSelected
}

public class GlobalEventSystem
{
    private static GlobalEventSystem instance;
    public static GlobalEventSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GlobalEventSystem();
            }
            return instance;
        }
    }

    private Dictionary<GameEvent, List<IEventHandler>> eventHandlers = new Dictionary<GameEvent, List<IEventHandler>>();

    public void RegisterHandler(GameEvent gameEvent, IEventHandler handler)
    {
        if (!eventHandlers.ContainsKey(gameEvent))
        {
            eventHandlers.Add(gameEvent, new List<IEventHandler>());
        }
        eventHandlers[gameEvent].Add(handler);
    }

    public void UnregisterHandler(GameEvent gameEvent, IEventHandler handler)
    {
        if (eventHandlers.ContainsKey(gameEvent))
        {
            eventHandlers[gameEvent].Remove(handler);
        }
    }

    public void TriggerEvent(GameEvent gameEvent, object data)
    {
        if (eventHandlers.ContainsKey(gameEvent))
        {
            foreach (var handler in eventHandlers[gameEvent])
            {
                handler.HandleEvent(gameEvent, data);
            }
        }
    }
}
