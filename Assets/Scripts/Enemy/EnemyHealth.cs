using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] public int hitPoints = 2;
    [SerializeField] private int coinAmount = 50;
    private bool isDestoryed = false;
    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;
        if (hitPoints <= 0 && !isDestoryed)
        {
            SpawnManager.OnEnemyDestroyed?.Invoke();
            LevelManager.main.IncreaseCurrency(coinAmount);
            SpawnManager.main.enemiesKilled++;
            isDestoryed = true;
            Destroy(gameObject);
        }
    }
}
