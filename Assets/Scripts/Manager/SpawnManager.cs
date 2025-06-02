using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager main;

    [Header("Spawner")]
    [SerializeField] private EnemySpawner spawner;

    [Header("Attributes")]
    [SerializeField] public int baseEnemies = 8;
    [SerializeField] public float timeBetweenWaves = 5f;
    [SerializeField] public float enemiesSpawnPerSecond = 1f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;
    [SerializeField] private float enemiesPerSecondCap = 10f;
    [Header("UI References")]
    public int currentWave = 1;
    public int enemiesAlive = 0;
    public int enemiesKilled = 0;
    public int currentWaveSpawnEnemyCount = 0;


    private int enemiesLeftToSpawn = 0;
    private float enemiesPerSecond;
    private float timeSinceLastSpawn = 0f;
    private bool isSpawning = false;

    public static UnityEvent OnEnemyDestroyed = new UnityEvent();

    private void Awake()
    {
        main = this;
        OnEnemyDestroyed.AddListener(() => enemiesAlive--);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= 1f / enemiesPerSecond && enemiesLeftToSpawn > 0)
        {
            spawner.Spawn();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private IEnumerator StartWave()
    {
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
        enemiesPerSecond = EnemiesPerSecond();
        currentWaveSpawnEnemyCount = enemiesLeftToSpawn;
        enemiesKilled = 0;
        
        yield return new WaitForSeconds(timeBetweenWaves);
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }

    private float EnemiesPerSecond()
    {
        return Math.Clamp(enemiesSpawnPerSecond * Mathf.Pow(currentWave, difficultyScalingFactor), 0f, enemiesPerSecondCap);
    }
}
