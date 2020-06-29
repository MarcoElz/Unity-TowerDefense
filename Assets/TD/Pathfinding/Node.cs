using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XP.Pathfinding
{
    public class Node : MonoBehaviour
    {
        [SerializeField] bool isVisitable = true;

        public Node cameFrom;

        public bool IsVisitable { get { return isVisitable; } }

        public Node[] neighbors;

        public void SetNeighbors(Node[] neighbors)
        {
            this.neighbors = neighbors;
        }
    }
}