using System;
using UnityEngine;

public class PlayerBase : MonoBehaviour, IDamageable
{
    [SerializeField] int startHP = 100;
    [SerializeField] GameEvent onGameStart = default;
    [SerializeField] GameEvent onGameOver = default;

    public event Action<int> onHPChanged;
    private int curentHP;

    private void OnEnable() => onGameStart.onEventRaised += RestartHP;
    private void OnDisable() => onGameStart.onEventRaised -= RestartHP;

    private void Start() => RestartHP();

    private void RestartHP()
    {
        curentHP = startHP;
        onHPChanged?.Invoke(curentHP);
    }

    public void Damage(int amount)
    {
        curentHP -= amount;

        if(curentHP <= 0)
        {
            curentHP = 0;
            onGameOver.Raise();
        }

        onHPChanged?.Invoke(curentHP);
    }
}
