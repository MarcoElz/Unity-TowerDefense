using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XP.Pathfinding;

public class LinearSmoothMovement : MonoBehaviour, IMovable
{
    [SerializeField] float speed = 0.5f;

    Node[] path;
    int actualNodeIndex;

    Vector3 direction;

    public void SetPath(Node[] path)
    {
        this.path = path;
        actualNodeIndex = 0;
        transform.position = path[0].transform.position;
    }


    private void Update()
    {
        if (path == null) return;

        //Do movement
        transform.position = Vector3.Lerp(transform.position, path[actualNodeIndex + 1].transform.position, Time.deltaTime * speed);

        //Check if is near of next node
        float distance = Vector3.Distance(this.transform.position, path[actualNodeIndex + 1].transform.position);

        if (distance < 0.15f)
        {
            ChangeNode();
        }
    }

    private void ChangeNode()
    {
        actualNodeIndex++;

        if (actualNodeIndex >= path.Length - 1)
        {
            Destroy(this.gameObject);
            return;
        }
    }
}
