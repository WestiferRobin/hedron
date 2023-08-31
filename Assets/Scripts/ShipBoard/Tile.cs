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

    private void OnCollisionEnter(Collision collision)
    {
        string name = collision.gameObject.name;
        if (collision.gameObject.CompareTag("Prism"))
        {
            // Handle collision behavior with Prism here
            Debug.Log($"{name} collided with the tile!");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        string name = collision.gameObject.name;
        if (collision.gameObject.CompareTag("Prism"))
        {
            // Handle collision exit behavior with Prism here
            Debug.Log($"{name} exited the tile!");
        }
    }
}
