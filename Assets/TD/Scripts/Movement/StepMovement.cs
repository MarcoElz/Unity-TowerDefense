using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XP.Pathfinding;

public class StepMovement : MonoBehaviour , IMovable
{
    public void SetPath(Node[] path)
    {
        StartCoroutine(MoveRoutine(path));
    }

    IEnumerator MoveRoutine(Node[] path)
    {
        for(int i = 0; i < path.Length; i++)
        {
            transform.position = path[i].transform.position;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
