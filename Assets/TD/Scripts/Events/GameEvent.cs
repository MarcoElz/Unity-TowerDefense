using System;
using UnityEngine;


[CreateAssetMenu(fileName = "GameEvent", menuName = "Game/Event", order = 1)]
public class GameEvent : ScriptableObject
{
    public event Action onEventRaised;

    public void Raise()
    {
        onEventRaised?.Invoke();
    }
}

