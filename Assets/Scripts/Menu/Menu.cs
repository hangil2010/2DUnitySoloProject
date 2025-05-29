using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] TextMeshProUGUI currentMonsterCountUI;
    [SerializeField] Animator animator;

    private bool isMenuOpen = true;
    private void OnGUI()
    {
        currencyUI.text = LevelManager.main.currency.ToString();
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
