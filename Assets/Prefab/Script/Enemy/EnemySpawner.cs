using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuration of Spawner")]
    public float playerDetectionRange = 10f;
    public float spawnRange = 20f;
    public int maxEnemyCount = 4;
    public int spawningDelay = 5;

    [Header("Enemy to Spawn")]
    public GameObject enemyPrefab;
    //can be change to a list
 

    private Transform player;
    private float lastTimeSpawn;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckSpawnable();
    }
    private void CheckSpawnable()
    {
        if (Vector3.Distance(transform.position, player.position) <= playerDetectionRange)
        {
            // Count existing enemies within spawn range
            int currentEnemyCount = CountEnemiesInRange();

            // Spawn a new enemy if conditions are met
            if (currentEnemyCount < maxEnemyCount)
            {

                if ((Time.time - lastTimeSpawn) >= spawningDelay)
                {
                   SpawnEnemy();
                   lastTimeSpawn = Time.time;
                }
            }
        }
    }
    private int CountEnemiesInRange()
    {

        int count = 0;
        Collider[] colliders = Physics.OverlapSphere(transform.position, spawnRange);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                count++;
            }
        }
        //Debug.Log(count);
        return count;
    }
    private void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere;
        spawnPosition.y = 0.5f; // Ensure enemies spawn at ground level or desired height

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}   
