using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] float minSpawnDistance = 3f;
    [SerializeField] float maxSpawnDistance = 7f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        var player = GameObject.FindWithTag("Player").transform;

        float distance = Random.Range(minSpawnDistance, maxSpawnDistance);
        Vector2 direction = Random.insideUnitCircle.normalized;
        Vector2 spawnPos = (Vector2)player.position + direction * distance;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
