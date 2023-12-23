using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDistance = 15f;
    public float spawnInterval = 2f;

    private Transform player;
    private float distance;

    void Start()
    {
        player = Camera.main.transform;
       
        {
            InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
        }
    }
       

    void SpawnEnemy()
    {
        Vector3 spawnPoint = player.position + player.forward * spawnDistance;
        spawnPoint += Random.onUnitSphere * spawnDistance;
        spawnPoint.y = 0f;
        distance = Vector3.Distance(player.position, spawnPoint);
        if (distance < 10f)
        {
            SpawnEnemy();
        }
        else if (!croco.isAlive)
        {

        }
        else
        {
            Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
        }

       
    }
}
