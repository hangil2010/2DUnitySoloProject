using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int coinAmount = 50;
    private bool isDestoryed = false;
    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;
        if (hitPoints <= 0 && !isDestoryed)
        {
            EnemySpawner.OnEnemyDestoryed?.Invoke();
            LevelManager.main.IncreaseCurrency(coinAmount);
            isDestoryed = true;
            Destroy(gameObject);
        }
    }
}
