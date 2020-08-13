using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XP.Pathfinding;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] EnemyType type = default;
    [SerializeField] int startHP = 100;
    [SerializeField] int rewardGold = 10;
    [SerializeField] int attack = 10;

    public EnemyType Type { get { return type; } }
    private IMovable movable;

    private int currentHP;

    private void Awake()
    {
        movable = GetComponent<IMovable>();
    }

    public void Init(Node goal)
    {      
        int x = Mathf.RoundToInt(transform.position.x);
        int z = Mathf.RoundToInt(transform.position.z);
        Node start = FindObjectOfType<GridManager>().GetNodeAtPosition(x, z);

        if(start != null)
        {
            IPathfinder pathfinder = new BFS();
            Node[] nodes = pathfinder.FindPath(start, goal);
            movable.SetPath(nodes);
        }
        else
        {
            Debug.LogWarning("Enemy is not in a valid Node.");
        }

        currentHP = startHP;
    }

    public void Damage(int amount)
    {
        currentHP -= amount;

        if(currentHP <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(this.gameObject);
        FindObjectOfType<Inventory>().AddGold(rewardGold); //TODO: Cambiar por otro metodo
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerBase playerBase = other.GetComponent<PlayerBase>();
        if(playerBase != null)
        {
            playerBase.Damage(attack);
        }
    }
}
