using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave_", menuName = "TowerDefense/Wave", order = 1)]
public class Wave : ScriptableObject
{
    public EnemySpawn[] enemies;
}
