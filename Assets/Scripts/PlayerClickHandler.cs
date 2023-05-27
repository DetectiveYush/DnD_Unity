using UnityEngine;

public class PlayerClickHandler : MonoBehaviour
{
    private GridManager gridManager; // Reference to the GridManager script
    private Vector2Int currentPosition; // Current position of the player object

    private void Awake()
    {
        // Retrieve the reference to the GridManager script
        gridManager = FindObjectOfType<GridManager>();
    }

    private void OnMouseDown()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Convert the world coordinates to grid coordinates
        Vector2Int clickedCell = gridManager.WorldToCell(mousePosition);

        // Handle the click event and player movement based on the clicked cell
        HandleClickEvent(clickedCell);
    }

    private void HandleClickEvent(Vector2Int clickedCell)
    {
        // Calculate the distance between the clicked cell and the current position
        int distanceX = Mathf.Abs(clickedCell.x - currentPosition.x);
        int distanceY = Mathf.Abs(clickedCell.y - currentPosition.y);

        // Check if the clicked cell is adjacent to the current position (assuming 4-directional movement)
        if ((distanceX == 1 && distanceY == 0) || (distanceX == 0 && distanceY == 1))
        {
            // Handle the special case when the value is equal to the minimum value
            if (clickedCell == new Vector2Int(int.MinValue, int.MinValue))
            {
                // Handle the special case without performing the negation operation
                Debug.Log("Special case: Minimum value");
            }
            else
            {
                // Update the current position to the clicked cell
                currentPosition = clickedCell;

                // Move the player object to the clicked cell position
                transform.position = gridManager.CellToWorld(clickedCell);

                // Perform any additional actions or updates related to player movement
                // ...
            }
        }
    }
}
