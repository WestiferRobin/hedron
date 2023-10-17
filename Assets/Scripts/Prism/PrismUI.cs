using UnityEngine;

public class PrismUI : MonoBehaviour
{
    private PrismInteraction interaction;
    private Renderer myRenderer;
    private Color originalColor;
    private Color selectedColor = Color.yellow;

    private void Start()
    {
        if (TryGetComponent<PrismInteraction>(out var foundModel))
        {
            interaction = foundModel;
        }
        else
        {
            throw new System.ArgumentNullException("PrismInteraction not found for PrismUI");
        }

        // Store the original color of the object's renderer
        myRenderer = GetComponent<Renderer>();
        originalColor = myRenderer.material.color;
    }

    private void OnMouseDown()
    {
        // Check if the unit can be selected (you can customize this logic)
        if (CanSelect())
        {
            // Change the color or apply any other visual feedback
            myRenderer.material.color = selectedColor;
        }
    }

    private void OnMouseUp()
    {
        // Restore the original color when the mouse button is released
        myRenderer.material.color = originalColor;
    }

    private bool CanSelect()
    {
        // Add your logic here to determine if the unit can be selected
        // For example, check if it's the player's turn, or if it's within the movement range, etc.
        return true; // Modify this condition as needed
    }
}
