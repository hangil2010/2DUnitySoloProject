using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    //[SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private List<EnemyInfo> enemyPrefabs;

    public void Spawn()
    {
        EnemyInfo enemyToSpawn = GetRandomEnemy();
        Instantiate(enemyToSpawn.enemyPrefab, LevelManager.main.startPoint.position, Quaternion.identity);
    }

    private EnemyInfo GetRandomEnemy()
    {
        float totalWeight = 0f;
        for (int i = 0; i < enemyPrefabs.Count; i++)
        {
            totalWeight += enemyPrefabs[i].spawnWeight;
        }
        float randomValue = Random.value * totalWeight;
        float currentWeight = 0f;
        for (int i = 0; i < enemyPrefabs.Count; i++)
        {
            currentWeight += enemyPrefabs[i].spawnWeight;
            if (randomValue <= currentWeight) return enemyPrefabs[i];
        }
        return null;
    }
}
