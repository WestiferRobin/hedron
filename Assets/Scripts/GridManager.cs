using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public Tilemap gridTilemap;
    public TileBase gridTile;             // The default grid tile
    public TileBase highlightedGridTile;  // The highlighted grid tile

    public int gridSizeX = 10;
    public int gridSizeY = 10;

    private Vector3Int lastHighlightedCell = new(-1, -1, 0);

    private void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        gridTilemap.ClearAllTiles();

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3Int cellPosition = new(x, y, 0);
                gridTilemap.SetTile(cellPosition, gridTile);
            }
        }
    }

    private void Update()
    {
        // Check for mouse hover
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = gridTilemap.WorldToCell(mouseWorldPos);

        // Check if the mouse is over a different cell
        if (cellPosition != lastHighlightedCell)
        {
            // Clear the previously highlighted cell
            if (lastHighlightedCell != new Vector3Int(-1, -1, 0))
            {
                gridTilemap.SetTile(lastHighlightedCell, gridTile);
            }

            // Highlight the new cell
            if (gridTilemap.GetTile(cellPosition) == gridTile)
            {
                gridTilemap.SetTile(cellPosition, highlightedGridTile);
                lastHighlightedCell = cellPosition;
            }
        }
    }
}
