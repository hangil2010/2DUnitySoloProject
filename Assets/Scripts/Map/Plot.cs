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
        spriteRenderer.color = hoverColor;
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = startColor;
    }

    private void OnMouseDown()
    {
        if (tower != null) return;

        GameObject towerBuild = BuildManager.main.GetSelectedTower();
        tower = Instantiate(towerBuild, transform.position, Quaternion.identity);
    }
}
