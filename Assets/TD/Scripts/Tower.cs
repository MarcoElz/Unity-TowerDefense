using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform head = default;

    private void Update()
    {
        Enemy enemy = FindNearestEnemy();
        head.transform.LookAt(enemy.transform);
    }


    private Enemy FindNearestEnemy()
    {
        //Find all enemies
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        //Find the nearest one
        float shortestDistance = 99999f; //Initialize for a absurd big float number
        int index = -1;
        for(int i = 0; i < enemies.Length; i++)
        {
            Vector3 deltaVector = this.transform.position - enemies[i].transform.position;
            float currentDistance = Vector3.SqrMagnitude(deltaVector);

            if(currentDistance < shortestDistance)
            {
                shortestDistance = currentDistance;
                index = i;
            }
        }


        return enemies[index];
    }

}
