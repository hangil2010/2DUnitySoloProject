using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text healthTextUI;
    [SerializeField] Health enemyHealth;
    private void OnGUI()
    {
        healthTextUI.text = enemyHealth.hitPoints.ToString(); 
    }
}
