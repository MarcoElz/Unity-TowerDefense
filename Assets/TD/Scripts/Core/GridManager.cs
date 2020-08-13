using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XP.Pathfinding;

public class GridManager : MonoBehaviour
{
    private Node[][] grid;

    private void Awake()
    {
        FindNodeNeighbors();
    }

    public Node GetNodeAtPosition(int x, int y)
    {
        if(x < grid.Length && y < grid[x].Length)
            return grid[x][y];

        return null;
    }

    private void FindNodeNeighbors()
    {
        //1. Buscar todos los nodos
        Node[] nodes = FindObjectsOfType<Node>();

        //2. Almacenarlos en la grid (matriz) en su posicion correcta 

        //Busco la posicion mas grande en x y en z
        float maxX = 0;
        float maxZ = 0;
        for(int i = 0; i < nodes.Length; i++)
        {
            if (nodes[i].transform.position.x > maxX)
                maxX = nodes[i].transform.position.x;

            if (nodes[i].transform.position.z > maxZ)
                maxZ = nodes[i].transform.position.z;
        }

        //Inicializar matriz con esas posiciones + 1
        int xSize = Mathf.RoundToInt(maxX + 1);
        int zSize = Mathf.RoundToInt(maxZ + 1);
        grid = new Node[xSize][];
        for (int i = 0; i < grid.Length; i++)
        {
            grid[i] = new Node[zSize];
        }

        //Añadir los nodos en la posicion correspondiente de la matriz
        for (int i = 0; i < nodes.Length; i++)
        {
            int x = Mathf.RoundToInt(nodes[i].transform.position.x);
            int z = Mathf.RoundToInt(nodes[i].transform.position.z);
            grid[x][z] = nodes[i];
        }


        //3. Por cada nodo de la matriz...
        //buscar sus nodos vecinos
        for(int i = 0; i < grid.Length; i++)
        {
            for(int j = 0; j < grid[i].Length; j++)
            {
                Node node = grid[i][j];

                List<Node> neighbors = new List<Node>();

                if(i - 1 >= 0 && grid[i - 1][j] != null)
                    neighbors.Add(grid[i - 1][j]);

                if(i + 1 < grid.Length && grid[i + 1][j])
                    neighbors.Add(grid[i + 1][j]);

                if(j - 1 >= 0 && grid[i][j - 1])
                    neighbors.Add(grid[i][j - 1]);

                if(j + 1 < grid[i].Length && grid[i][j + 1])
                    neighbors.Add(grid[i][j + 1]);


                node.SetNeighbors(neighbors.ToArray());
            }
        }

    }

}
