using System;
using UnityEngine;

[CreateAssetMenu(fileName ="New Enemy Info", menuName = "Enemy")]
public class EnemyInfo : ScriptableObject
{
    public string enemyName;
    public GameObject enemyPrefab;
    public float spawnWeight;
}
