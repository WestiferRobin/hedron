using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PrismMovement : MonoBehaviour
{
    private PrismCore model;
    [SerializeField] public Tilemap tilemap;
    [SerializeField] private float moveSpeed = 2.0f;

    private Vector3Int currentTile;
    private Vector3 targetPosition;
    private bool isMoving = false;

    public void Start()
    {
        if (TryGetComponent<PrismCore>(out var core))
        {
            model = core;
        }
        else
        {
            throw new ArgumentNullException("PrismModel not found for PrismMovement");
        }
        // Initialize the current tile based on the starting position of the Prism
        currentTile = tilemap.WorldToCell(transform.position);
        targetPosition = transform.position;
    }

    private void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in world space
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Convert the mouse position to the nearest tile position
            Vector3Int targetTile = tilemap.WorldToCell(mouseWorldPos);

            // Check if the target tile is a valid tile within the Tilemap
            if (IsPositionValid(targetTile))
            {
                // Set the target position to the center of the target tile
                targetPosition = tilemap.GetCellCenterWorld(targetTile);

                // Start moving to the target position
                isMoving = true;
            }
        }

        // Move towards the target position if we're currently moving
        if (isMoving)
        {
            Move(targetPosition);
        }
    }
    #region Movement Methods
    public bool CanMove()
    {
        return model.Body.BodyParts.ContainsKey(BodyPart.Legs);
    }

    private bool IsPositionValid(Vector3Int position)
    {
        // Check if the position is within the bounds of the Tilemap
        return tilemap.HasTile(position);
    }

    public bool Move(Vector3 target)
    {
        // Calculate the distance between current and target positions
        float distance = Vector3.Distance(transform.position, target);

        // Move the Prism towards the target tile
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        return distance >= 0.1f;
    }

    public bool Move()
    {
        int scaler = UnityEngine.Random.Range(1, 4);
        int x = UnityEngine.Random.Range(-1, 2) * scaler + (int)this.transform.position.x;
        int z = UnityEngine.Random.Range(-1, 2) * scaler + (int)this.transform.position.z;
        var position = new Vector3(x, 0, z);
        return Move(position);
    }

    public bool InRange(Vector3 target, float maxRange)
    {
        int xPos = (int)transform.position.x;
        int zPos = (int)transform.position.z;
        int botX = xPos - (int)maxRange;
        int topX = xPos + (int)maxRange;
        int botZ = zPos - (int)maxRange;
        int topZ = zPos + (int)maxRange;
        int targetX = (int)target.x;
        int targetZ = (int)target.z;
        return botX <= targetX && targetX <= topX &&
            botZ <= targetZ && targetZ <= topZ;
    }
    #endregion
}

