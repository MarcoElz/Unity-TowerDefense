using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] GameEvent gameEvent = default;
    [SerializeField] UnityEvent response = default;


    private void OnEnable()
    {
        gameEvent.onEventRaised += RaiseEvent;
    }

    private void OnDisable()
    {
        gameEvent.onEventRaised -= RaiseEvent;
    }

    public void RaiseEvent()
    {
        response?.Invoke();
    }

}
