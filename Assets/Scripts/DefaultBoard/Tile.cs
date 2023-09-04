using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Renderer tileRenderer;
    public Color originalColor;
    public Color selectorColor = Color.cyan;

    public void Start()
    {
        // Get the renderer component
        tileRenderer = GetComponent<Renderer>();
        // Store the original color of the tile
        originalColor = tileRenderer.material.color;
    }

    public void OnMouseEnter()
    {
        if (tileRenderer.material.color == originalColor)
        {
            SetColor(selectorColor);
        }
    }

    public void OnMouseExit()
    {
        if (tileRenderer.material.color == selectorColor)
        {
            SetColor(originalColor);
        }
    }

    public void SetColor(Color color)
    {
        tileRenderer.material.color = color;
    }

    public void OnMouseUp()
    {
        // Call a method in the Prism script to handle tile selection
        PrismMovement prism = FindObjectOfType<PrismMovement>();
        if (prism != null)
        {
            prism.Move(this.transform.position);
        }
    }
}
