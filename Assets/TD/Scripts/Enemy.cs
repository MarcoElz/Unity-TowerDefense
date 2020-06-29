using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XP.Pathfinding;


public class Enemy : MonoBehaviour
{
    private IMovable movable;

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
        
    }
}
