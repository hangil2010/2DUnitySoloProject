using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color hoverColor;
    private GameObject tower;
    private Color startColor;

    private void Start() => startColor = spriteRenderer.color;
    private void OnMouseEnter()
    {
        if (LevelManager.main.isPaused == true) return;
        spriteRenderer.color = hoverColor;
    }

    private void OnMouseExit()
    {
        if (LevelManager.main.isPaused == true) return;
        spriteRenderer.color = startColor;
    }

    private void OnMouseDown()
    {
        if (LevelManager.main.isPaused == true || tower != null) return;

        Tower towerBuild = BuildManager.main.GetSelectedTower();

        if (towerBuild.cost > LevelManager.main.currency) return;

        LevelManager.main.SpendCurrency(towerBuild.cost);
        
        tower = Instantiate(towerBuild.towerPrefab, transform.position, Quaternion.identity);
    }
}
