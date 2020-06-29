using System.Collections.Generic;

namespace XP.Pathfinding
{
    public class BFS : IPathfinder
    {
        public Node[] FindPath(Node start, Node goal)
        {
            Queue<Node> frontier = new Queue<Node>();
            List<Node> visited = new List<Node>();

            frontier.Enqueue(start);
            visited.Add(start);

            while (frontier.Count > 0)
            {
                Node currentNode = frontier.Dequeue();

                if (currentNode.Equals(goal))
                    break;

                for(int i = 0; i < currentNode.neighbors.Length; i++)
                {
                    Node neighbor = currentNode.neighbors[i];

                    if(neighbor.IsVisitable && !visited.Contains(neighbor))
                    {
                        frontier.Enqueue(neighbor);
                        visited.Add(neighbor);
                        neighbor.cameFrom = currentNode;
                    }           
                }
            }

            List<Node> path = new List<Node>();
            Node cameFrom = goal;
            while(!cameFrom.Equals(start))
            {
                path.Add(cameFrom);
                cameFrom = cameFrom.cameFrom;
            }

            path.Reverse();

            return path.ToArray();
        }
    }
}