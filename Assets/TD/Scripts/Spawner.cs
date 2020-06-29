using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XP.Pathfinding;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform target = default;
    [SerializeField] GameObject[] enemiesPrefab = default;
    [SerializeField] float spawnRate = 1f;


    GridManager gridManager;
    Node targetNode;

    private void Start()
    {
        //Find Grid Manager
        gridManager = FindObjectOfType<GridManager>();

        //Get the Target Node
        int x = Mathf.RoundToInt(target.position.x);
        int z = Mathf.RoundToInt(target.position.z);
        targetNode = gridManager.GetNodeAtPosition(x, z);

        if(targetNode != null)
        {
            StartCoroutine(SpawnCoroutine(enemiesPrefab));
        }
        else
        {
            Debug.LogWarning("Target is not in a valid Node");
        }
    }

    private IEnumerator SpawnCoroutine(GameObject[] prefabs)
    {
        WaitForSeconds waitForSpawnRate = new WaitForSeconds(spawnRate);

        while (true) //TODO: Change to GameManager.Instance.IsGameRunning
        {
            int random = Random.Range(0, prefabs.Length);
            Spawn(prefabs[random]);
            yield return waitForSpawnRate;
        }
    }

    private void Spawn(GameObject prefab)
    {
        GameObject go = Instantiate(prefab, transform.position, Quaternion.identity);
        Enemy enemy = go.GetComponent<Enemy>();
        enemy.Init(targetNode);
    }

    
}
