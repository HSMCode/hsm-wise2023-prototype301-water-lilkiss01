using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform playerTransform;
    public int initialEnemyCount = 4;
    public float spawnInterval = 5f;
    public float minSpawnDistance = 7f;

    void Start()
    {
        SpawnInitialEnemies();

        StartCoroutine(SpawnEnemiesRoutine());
    }

    void SpawnInitialEnemies()
    {
        for (int i = 0; i < initialEnemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    IEnumerator SpawnEnemiesRoutine()
    {
        yield return new WaitForSeconds(spawnInterval);

        while (true)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        Vector3 randomSpawnPosition = GetRandomSpawnPosition();

        Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = 0;

        Vector3 randomSpawnPosition = playerTransform.position + randomDirection * minSpawnDistance;

        return randomSpawnPosition;
    }
}