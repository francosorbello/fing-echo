using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventHandler
{
    public void HandleEvent(GameEvent gameEvent, object data);
}
