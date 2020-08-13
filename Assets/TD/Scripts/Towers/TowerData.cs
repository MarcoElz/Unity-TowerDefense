using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "TowerDefense/TowerData", order = 1)]
public class TowerData : ScriptableObject
{
    public TowerBaseStats baseStats;
    public string towerName = "Tower Name";
    public Sprite sprite;
    public GameObject prefab;
    public Evolution[] evolutions;
}


[System.Serializable]
public struct TowerBaseStats
{
    public int damage;
    public float attackSpeed;
    public float range;
    public EnemyType[] types;
}

[System.Serializable]
public struct Evolution
{
    public int cost;
    public TowerData tower;
}