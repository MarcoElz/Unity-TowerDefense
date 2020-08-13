using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_Spawn", menuName = "TowerDefense/Enemy Spawn", order = 1)]
public class EnemySpawn : ScriptableObject
{
    public GameObject prefab;
}
