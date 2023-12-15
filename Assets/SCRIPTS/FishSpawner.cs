using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject[] fishPrefabs;
    public float minSpawnDistance = 10f;
    public float spawnDistance = 20f;
    public float initialSpawnDelay = 2f;
    public float repeatSpawnDelay = 10f;

    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            SpawnFishNearCrocodile();
        }

        StartCoroutine(RepeatFishSpawn());
    }

    void SpawnFishNearCrocodile()
    {
        GameObject crocodile = GameObject.FindGameObjectWithTag("Player");

        if (crocodile != null)
        {
            Vector3 spawnPosition = crocodile.transform.position + Random.onUnitSphere * spawnDistance;
            spawnPosition.y = crocodile.transform.position.y;
       
            float distanceToCrocodile = Vector3.Distance(spawnPosition, crocodile.transform.position);
            if (distanceToCrocodile >= minSpawnDistance)
            {
                GameObject randomFishPrefab = fishPrefabs[Random.Range(0, fishPrefabs.Length)];

                Instantiate(randomFishPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                SpawnFishNearCrocodile();
            }
        }
        else
        {
            Debug.LogError("Krokodil nicht gefunden. Stelle sicher, dass der Tag des Krokodils auf 'Player' gesetzt ist.");
        }
    }

    IEnumerator RepeatFishSpawn()
    {
        yield return new WaitForSeconds(initialSpawnDelay);

        while (true)
        {
            SpawnFishNearCrocodile();
            yield return new WaitForSeconds(repeatSpawnDelay);
        }
    }
}