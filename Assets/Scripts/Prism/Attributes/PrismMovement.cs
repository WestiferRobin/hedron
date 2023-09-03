using System;
using UnityEngine;

public class PrismMovement : MonoBehaviour
{
    private PrismCore model;

    private Vector3 targetTilePosition;
    private bool isMoving = false;

    private Color primaryColor;
    private Color secondaryColor;
    private Color selectorColor = Color.yellow;

    #region Unity Methods
    public void Start()
    {
        Renderer myRenderer = GetComponent<Renderer>();

        if (myRenderer != null)
        {
            Material primary = myRenderer.materials[0];
            primaryColor = primary.color;
            Material secondary = myRenderer.materials[1];
            secondaryColor = secondary.color;
            var childrenSize = this.transform.childCount;
            for (int i = 0; i < childrenSize; i++)
            {
                var child = this.transform.GetChild(i);
                var childRenderer = child.GetComponent<Renderer>();
                if (childRenderer != null)
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

        if (TryGetComponent<PrismCore>(out var foundModel))
        {
            model = foundModel;
        }
        else
        {
            throw new ArgumentNullException("PrismModel not found for PrismMovement");
        }
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isMoving)
            {
                // Check if the click hits a valid tile (you may need to implement this logic)
                if (TrySelectTile(out targetTilePosition))
                {
                    // Set the move flag to true
                    isMoving = true;
                }
            }
        }

        if (isMoving)
        {
            // Calculate and perform Prism movement logic here
            Move(targetTilePosition);
        }
    }

    private bool TrySelectTile(out Vector3 tilePosition)
    {
        tilePosition = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<Tile>(out var tile))
            {
                tilePosition = tile.transform.position;
                return true;
            }
        }

        return false;
    }

    public void OnMouseDown()
    {
        Renderer myRenderer = GetComponent<Renderer>();
        if (myRenderer != null)
        {
            myRenderer.materials[0].color = selectorColor;
            myRenderer.materials[1].color = selectorColor;
        }
    }

    public void OnMouseUp()
    {
        Renderer myRenderer = GetComponent<Renderer>();
        if (myRenderer != null)
        {
            myRenderer.materials[0].color = primaryColor;
            myRenderer.materials[1].color = secondaryColor;
        }
    }
    #endregion

    #region Movement Methods
    public bool CanMove()
    {
        return model.Body.BodyParts.ContainsKey(BodyPart.Legs);
    }

    public void Move(Vector3 targetPosition)
    {
        // Calculate the distance between current and target positions
        float distance = Vector3.Distance(transform.position, targetPosition);

        // Move the Prism towards the target tile
        float moveSpeed = 5f; // Adjust the speed as needed
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // Check if the Prism has reached the target tile
        if (distance < 0.1f)
        {
            // Reset the move flag
            isMoving = false;
        }
    }

    public void Move()
    {
        int scaler = UnityEngine.Random.Range(1, 4);
        int x = UnityEngine.Random.Range(-1, 2) * scaler + (int)this.transform.position.x;
        int z = UnityEngine.Random.Range(-1, 2) * scaler + (int)this.transform.position.z;
        var position = new Vector3((int)x, 0, (int)z);
        Move(position);
    }

    public bool InRange(PrismCore target, float maxRange = 3)
    {
        float xDiff = target.transform.position.x - this.transform.position.x;
        float yDiff = target.transform.position.y - this.transform.position.y;

        // Calculate the Euclidean distance
        float distance = Mathf.Sqrt(xDiff * xDiff + yDiff * yDiff);

        // Check if the distance is within the specified range
        return distance <= maxRange;
    }
    #endregion
}

