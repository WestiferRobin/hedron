using System;
using UnityEngine;

public class PrismMovement : MonoBehaviour
{
    private PrismCore model;
    public float moveSpeed = 5f;

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
    }
    #region Movement Methods
    public bool CanMove()
    {
        return model.Body.BodyParts.ContainsKey(BodyPart.Legs);
    }

    public bool Move(Vector3 targetPosition)
    {
        // Calculate the distance between current and target positions
        float distance = Vector3.Distance(transform.position, targetPosition);

        // Move the Prism towards the target tile
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

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

