using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XP.Pathfinding;

public class FlyMovement : MonoBehaviour, IMovable
{
    [SerializeField] float speed = 2.5f;


    private Vector3 destination;
    private Vector3 direction;

    public void SetPath(Node[] path)
    {
        destination = path[path.Length - 1].transform.position;
 Vector3 startPosition = path[0].transform.position;

        startPosition.y = 2f;
        destination.y = 2f;
        transform.position = startPosition;
    }

    private void Update()
    {
        direction = (destination - transform.position).normalized;
        direction.y = 0f;
        transform.position += direction * speed * Time.deltaTime;


        float distance = Vector3.Distance(this.transform.position, destination);

        if (distance < 0.15f)
        {
            Destroy(this.gameObject);
        }
    }


}
