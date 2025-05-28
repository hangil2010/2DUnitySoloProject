using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapChecker : MonoBehaviour
{
    public Tilemap groundTilemap;
    public Tilemap pathTilemap;
    public Camera mainCamera;
    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // 가장 먼저 충돌된 타일맵만 처리
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
            if (hit.collider != null)
            {
                GameObject hitObj = hit.collider.gameObject;
                string layerName = LayerMask.LayerToName(hitObj.layer);

                Vector3Int cellPos = groundTilemap.WorldToCell(mouseWorldPos);

                switch (layerName)
                {
                    case "Ground":
                        TileBase groundTile = groundTilemap.GetTile(cellPos);
                        if (groundTile != null)
                        {
                            Debug.Log($"[Ground] 타일 클릭됨 - 좌표: {cellPos}, 타일 타입: {groundTile.name}");
                        }
                        break;
                    case "Path":
                        TileBase pathTile = pathTilemap.GetTile(cellPos);
                        if (pathTile != null)
                        {
                            Debug.Log($"[Path] 타일 클릭됨 - 좌표: {cellPos}, 타일 타입: {pathTile.name}");
                        }
                        break;
                    default:
                        Debug.Log($"알 수 없는 레이어: {layerName}");
                        break;
                }
            }
            else
            {
                Debug.Log("타일맵과 충돌된 오브젝트가 없습니다.");
            }
        }
    }
}
