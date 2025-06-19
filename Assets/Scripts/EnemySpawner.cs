using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
class EnemySpawnData
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float minSpawnDistance = 3f;
    public float maxSpawnDistance = 7f;
    public float timer;
}




public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<EnemySpawnData> enemyTypes = new();

    void Update()
    {
        foreach (var enemy in enemyTypes)
        {
            enemy.timer += Time.deltaTime;

            if (enemy.timer >= enemy.spawnInterval)
            {
                Spawn(enemy);
                enemy.timer = 0f;
            }
        }
    }

    void Spawn(EnemySpawnData data)
    {
        var player = GameObject.FindWithTag("Player").transform;

        float distance = Random.Range(data.minSpawnDistance, data.maxSpawnDistance);
        Vector2 dir = Random.insideUnitCircle.normalized;
        Vector2 spawnPos = (Vector2)player.position + dir * distance;

        Instantiate(data.enemyPrefab, spawnPos, Quaternion.identity);
    }
}
