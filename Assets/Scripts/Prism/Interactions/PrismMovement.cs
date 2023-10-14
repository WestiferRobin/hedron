using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PrismMovement : MonoBehaviour
{
    private PrismCore model;
    public Tilemap tilemap;
    public float moveSpeed = 15.0f;

    private Vector2 targetPosition;
    private bool isMoving = false;

    private Rigidbody2D rigidBody;
    private Animator animator;

    public void Start()
    {
        var gameBoard = GameObject.FindWithTag("Board");
        if (gameBoard != null)
        {
            if (gameBoard.TryGetComponent<Tilemap>(out var tilemap))
            {
                this.tilemap = tilemap;
            }
            else
            {
                throw new ArgumentNullException("Can't find Tilemap for Prism to go on");
            }
        }
        else if (this.tilemap != null)
        {
            throw new ArgumentNullException("Can't find Tilemap for Prism to go on");
        }

        if (TryGetComponent<Rigidbody2D>(out var foundRigidBody))
        {
            this.rigidBody = foundRigidBody;
        }
        else
        {
            throw new ArgumentNullException("Rigidbody2D not found for PrismMovement");
        }
        if (TryGetComponent<Animator>(out var foundAnimator))
        {
            this.animator = foundAnimator;
        }
        else
        {
            throw new ArgumentNullException("Animator not found for PrismMovement");
        }
        if (TryGetComponent<PrismCore>(out var core))
        {
            model = core;
        }
        else
        {
            throw new ArgumentNullException("PrismModel not found for PrismMovement");
        }
        targetPosition = rigidBody.position; // Initialize the target position with the current position
    }

    private void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in world space
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

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

    public bool IsPositionValid(Vector3Int position)
    {
        // Check if the position is within the bounds of the Tilemap
        return tilemap.HasTile(position);
    }


    public bool IsPositionValid(Vector3 position)
    {
        var positionInt = new Vector3Int((int)position.x, (int)position.y);
        return IsPositionValid(positionInt);
    }

    public void Move(Vector2 target)
    {
        // Calculate the direction from current position to target position
        Vector2 direction = (target - rigidBody.position).normalized;

        // Calculate the new position
        Vector2 newPosition = rigidBody.position + moveSpeed * Time.deltaTime * direction;
        rigidBody.MovePosition(newPosition);

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);

        var distance = Vector2.Distance(rigidBody.position, target);

        // Check if we have reached the target position
        if (distance < 0.1f)
        {
            isMoving = false;
        }
        animator.SetFloat("Speed", isMoving ? 1 : 0);
    }
    #endregion
}
