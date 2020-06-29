using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XP.Pathfinding
{
    public interface IPathfinder
    {
        Node[] FindPath(Node start, Node goal);
    }
}