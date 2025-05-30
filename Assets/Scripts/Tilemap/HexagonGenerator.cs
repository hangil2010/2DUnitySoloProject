using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonGenerator : MonoBehaviour
{
    [Header("Hex Tile Settings")]
    public GameObject hexPrefab; // 육각형 프리팹
    public int rows = 5;
    public int columns = 5;
    public float hexRadius = 0.5f; // 육각형 한 변의 중심~꼭지점 길이

    private void Start()
    {
        GenerateHexGrid();
    }

    private void GenerateHexGrid()
    {
        float width = Mathf.Sqrt(3) * hexRadius;
        float height = 2f * hexRadius;
        float offsetY = 0.75f * height;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float xOffset = (row % 2 == 0) ? 0 : width / 2f;

                float xPos = col * width + xOffset;
                float yPos = row * offsetY;

                Vector3 position = new Vector3(xPos, yPos, 0);
                GameObject tile = Instantiate(hexPrefab, position, Quaternion.identity, this.transform);
                tile.name = $"Hex_{row}_{col}";
            }
        }
    }
}
