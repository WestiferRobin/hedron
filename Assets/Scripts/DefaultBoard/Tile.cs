using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Renderer tileRenderer;
    private Color originalColor;

    private void Start()
    {
        // Get the renderer component
        tileRenderer = GetComponent<Renderer>();
        // Store the original color of the tile
        originalColor = tileRenderer.material.color;
    }

    private void OnMouseEnter()
    {
        // Change the color of the tile to indicate hover
        tileRenderer.material.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        // Revert the color of the tile back to its original color
        tileRenderer.material.color = originalColor;
    }

    private void OnMouseUp()
    {
        // Call a method in the Prism script to handle tile selection
        PrismMovement prism = FindObjectOfType<PrismMovement>();
        if (prism != null)
        {
            prism.Move(this.transform.position);
        }
    }
}
