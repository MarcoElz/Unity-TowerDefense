using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tower : MonoBehaviour
{
    [SerializeField] TowerData data = default;
    [SerializeField] Transform head = default;
    [SerializeField] Transform bulletOrigin = default;
    [SerializeField] GameObject bulletPrefab = default;

    private float timeBetweenAttacks;

    private float timeOfLastAttack;

    Enemy currentEnemy;

    bool canAttack;

    public void StartAttack()
    {
        canAttack = true;
    }

    private void Start()
    {
        timeBetweenAttacks = 1f / data.baseStats.attackSpeed;
    }

    private void Update()
    {
        if (!canAttack)
            return;

        currentEnemy = FindNearestEnemy();

        if(currentEnemy != null)
        {
            head.transform.LookAt(currentEnemy.transform);

            if (Time.time > timeOfLastAttack + timeBetweenAttacks)
                Attack();
        }
        
    }

    public TowerData GetData()
    {
        return data;
    }

    public Tower Evolve(Evolution evolution)
    {
        GameObject newTowerObject = Instantiate(evolution.tower.prefab, this.transform.position, this.transform.rotation);
        Tower newTower = newTowerObject.GetComponent<Tower>();

        Destroy(this.gameObject);

        return newTower;
    }

    private void Attack()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.Init(data.baseStats.damage);
        timeOfLastAttack = Time.time;
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
            if(CanAttackByType(enemies[i].Type))
            {
                Vector3 deltaVector = this.transform.position - enemies[i].transform.position;
                float currentDistance = Vector3.Magnitude(deltaVector);

                if (currentDistance < shortestDistance && currentDistance < data.baseStats.range)
                {
                    shortestDistance = currentDistance;
                    index = i;
                }
            }
         
        }

        if(index < 0)
        {
            return null;
        }

        return enemies[index];
    }

    private bool CanAttackByType(EnemyType type)
    {
        for(int i = 0; i < data.baseStats.types.Length; i++)
        {
            if (data.baseStats.types[i].Equals(type))
                return true;
        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, data.baseStats.range);
    }

}
