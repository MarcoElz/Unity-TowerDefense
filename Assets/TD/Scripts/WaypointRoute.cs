using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XP.Pathfinding;

public class WaypointRoute : MonoBehaviour
{
    [SerializeField] Node[] route;

    public void SetRoute(Node[] nodes)
    {
        route = nodes;
    }

    public Node[] GetRoute()
    {
        return route;
    }


    private void OnDrawGizmosSelected()
    {
        for(int i = 0; i < route.Length; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(route[i].transform.position, 0.1f);

            if(i + 1 < route.Length )
                Gizmos.DrawLine(route[i].transform.position, route[i+1].transform.position);
        }
        
        
    }
}
