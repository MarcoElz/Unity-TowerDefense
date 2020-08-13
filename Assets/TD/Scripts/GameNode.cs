using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNode : MonoBehaviour
{
    public bool IsEmpty { get { return Tower == null; } }

    public Tower Tower { get; private set; }

    public Tower test_tower;

    private void Start()
    {
        Tower = test_tower;
    }

    public void SetTower(Tower tower)
    {
        Tower = tower;
    }

}
