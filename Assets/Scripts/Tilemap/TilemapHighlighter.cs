using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapHighlighter : MonoBehaviour
{
    /*[Header("Tilemaps")]
    public Tilemap groundTilemap;         // 하이라이트 감지용
    public Tilemap highlightTilemap;      // 하이라이트 표시용

    [Header("Highlight Tile")]
    public TileBase highlightTile;            // 색이 다른 타일 (예: 반투명 등)

    private Vector3Int previousCell;

    void Update()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = groundTilemap.WorldToCell(worldPos);

        Debug.Log($"Mouse World: {worldPos}, Cell: {cellPos}");

        if (cellPos != previousCell)
        {
            highlightTilemap.SetTile(previousCell, null);

            if (groundTilemap.HasTile(cellPos))
            {
                Debug.Log($"Highlighting Cell {cellPos}");
                highlightTilemap.SetTile(cellPos, highlightTile);
                previousCell = cellPos;
            }
            else
            {
                Debug.Log("No tile at this cell.");
            }
        }
    }*/
}
