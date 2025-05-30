using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] TextMeshProUGUI monsterKillCountUI;
    [SerializeField] TextMeshProUGUI currentMonsterCountUI;
    [SerializeField] TextMeshProUGUI currentWaveUI;
    [SerializeField] Animator animator;

    private bool isMenuOpen = true;
    private void OnGUI()
    {
        currencyUI.text = LevelManager.main.currency.ToString();
        monsterKillCountUI.text = SpawnManager.main.enemiesKilled.ToString();
        currentMonsterCountUI.text = SpawnManager.main.currentWaveSpawnEnemyCount.ToString();
        currentWaveUI.text = SpawnManager.main.currentWave.ToString();
    }

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        animator.SetBool("MenuOpen", isMenuOpen);   
    }
    public void SetTower()
    {

    }
}
