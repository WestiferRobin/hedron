using System;
using System.Collections.Generic;
using UnityEngine;

public class PrismUI : MonoBehaviour
{
    private PrismInteraction interaction;

    private Tile targetTile;
    private bool isMoving = false;
    public float rotationOffset = 270.0f;

    private Color primaryColor;
    private Color secondaryColor;
    private Color selectorColor = Color.yellow;
    private bool isSelected = false;
    private List<Tile> inRangeTiles = new();

    public void Start()
    {

        if (TryGetComponent<Renderer>(out var myRenderer))
        {
            Material primary = myRenderer.materials[0];
            primaryColor = primary.color;
            Material secondary = myRenderer.materials[1];
            secondaryColor = secondary.color;
            var childrenSize = this.transform.childCount;
            for (int i = 0; i < childrenSize; i++)
            {
                var child = this.transform.GetChild(i);
                if (child.TryGetComponent<Renderer>(out var childRenderer))
                {
                    if (child.name.ToUpper().Contains("SPHERE"))
                    {
                        childRenderer.material = secondary;
                    }
                    else
                    {
                        childRenderer.material = primary;
                    }
                }
            }
        }
        else
        {
            Debug.LogError("Renderer component not found on this GameObject.");
        }

        if (TryGetComponent<PrismInteraction>(out var foundModel))
        {
            interaction = foundModel;
        }
        else
        {
            throw new ArgumentNullException("PrismInterction not found for PrismUI");
        }
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isSelected)
            {
                var board = GameObject.FindGameObjectWithTag("Board");

                foreach (Transform row in board.transform)
                {
                    foreach (Transform tile in row)
                    {
                        int maxRange = interaction.core.Stats.Agility;
                        if (interaction.movement.InRange(tile.position, maxRange))
                        {
                            if (tile.TryGetComponent<Tile>(out var tileComponet))
                            {
                                inRangeTiles.Add(tileComponet);
                            }
                        }
                    }
                }
                foreach (var rangeTile in inRangeTiles)
                {
                    rangeTile.SetColor(selectorColor);
                }
                Debug.Log(inRangeTiles);
            }
            if (!isMoving)
            { 

                //// Check if the click hits a valid tile (you may need to implement this logic)
                if (TrySelectTile(out targetTile))
                {
                    if (inRangeTiles.Contains(targetTile))
                    {
                        // Set the move flag to true
                        SetRotation(targetTile.transform.position);
                        isMoving = interaction.movement.CanMove();
                        foreach (var rangeTile in inRangeTiles)
                        {
                            rangeTile.SetColor(rangeTile.originalColor);
                        }
                        targetTile.SetColor(selectorColor);
                        inRangeTiles = new();
                    }
                }
            }
        }

        if (isMoving)
        {
            // Calculate and perform Prism movement logic here
            isMoving = interaction.movement.Move(targetTile.transform.position);
            targetTile.SetColor(targetTile.originalColor);
        }
    }

    private void SetRotation(Vector3 targetPosition)
    {
        // Calculate the direction to the target
        Vector3 direction = targetPosition - transform.position;

        // Ignore the Y-axis to keep the character upright
        direction.y = 0f;

        // Set the rotation directly to face the target
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            targetRotation *= Quaternion.Euler(0, rotationOffset, 0);
            transform.rotation = targetRotation;
        }
    }

    private bool TrySelectTile(out Tile selectedTile)
    {
        selectedTile = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<Tile>(out var tile))
            {
                selectedTile = tile;
                return true;
            }
        }

        return false;
    }

    public void OnMouseDown()
    {
        if (TryGetComponent<Renderer>(out var myRenderer))
        {
            myRenderer.materials[0].color = selectorColor;
            myRenderer.materials[1].color = selectorColor;
            isSelected = true;
        }
    }

    public void OnMouseUp()
    {
        if (TryGetComponent<Renderer>(out var myRenderer))
        {
            myRenderer.materials[0].color = primaryColor;
            myRenderer.materials[1].color = secondaryColor;
            isSelected = false;
        }
    }
}

