using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Define the properties of your grid
    public int gridSizeX;
    public int gridSizeY;
    public float cellSize;

    // Implement the WorldToCell method to convert world coordinates to grid coordinates
    public Vector2Int WorldToCell(Vector3 worldPosition)
    {
        int cellX = Mathf.FloorToInt(worldPosition.x / cellSize);
        int cellY = Mathf.FloorToInt(worldPosition.y / cellSize);

        return new Vector2Int(cellX, cellY);
    }

    // Implement the CellToWorld method to convert grid coordinates to world coordinates
    public Vector3 CellToWorld(Vector2Int cellPosition)
    {
        float worldX = cellPosition.x * cellSize + cellSize / 2f;
        float worldY = cellPosition.y * cellSize + cellSize / 2f;

        return new Vector3(worldX, worldY, 0f);
    }
}

