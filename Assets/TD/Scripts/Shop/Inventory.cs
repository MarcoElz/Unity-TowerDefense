using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int CurrentGold { get; private set; }

    public event Action<int> onGoldAmountChanged;

    private void Start()
    {
        onGoldAmountChanged?.Invoke(0);
    }

    public void AddGold(int amount)
    {
        CurrentGold += amount;
        onGoldAmountChanged?.Invoke(CurrentGold);
    }

    public void ReduceGold(int amount)
    {
        CurrentGold -= amount;
        onGoldAmountChanged?.Invoke(CurrentGold);
    }

    [ContextMenu("Add 100 Gold")]
    public void Test_AddGold()
    {
        AddGold(100);
    }

}
