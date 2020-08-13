using System.Collections;
using UnityEngine;
using XP.Pathfinding;

public class WaveSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] Wave[] waves;
    [SerializeField] float spawnRate = 1f;
    [SerializeField] float waveDelay = 5f;

    private GridManager gridManager;
    private Transform target;
    private Node targetNode;

    public void StartSpawn()
    {
        target = FindObjectOfType<PlayerBase>().transform;

        //Find Grid Manager
        gridManager = FindObjectOfType<GridManager>();

        //Get the Target Node
        int x = Mathf.RoundToInt(target.position.x);
        int z = Mathf.RoundToInt(target.position.z);
        targetNode = gridManager.GetNodeAtPosition(x, z);

        if (targetNode == null)
        {
            Debug.LogWarning("Target is not in a valid Node");
        }
        else
        {
            StartCoroutine(SpawningRoutine());
        }   
    }

    IEnumerator SpawningRoutine()
    {  
        for(int i = 0; i < waves.Length; i++)
        {
            for(int j = 0; j < waves[i].enemies.Length; j++)
            {
                Spawn(waves[i].enemies[j].prefab);
                yield return new WaitForSeconds(spawnRate);
            }

            yield return new WaitForSeconds(waveDelay);
        }
    }

    private void Spawn(GameObject prefab)
    {
        GameObject go = Instantiate(prefab, transform.position, Quaternion.identity);
        Enemy enemy = go.GetComponent<Enemy>();
        enemy.Init(targetNode);
    }
}
