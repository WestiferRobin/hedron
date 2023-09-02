using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCamera : MonoBehaviour
{
    public Transform target; // The target object to rotate around (your game board)
    public float rotationSpeed = 5.0f; // Adjust the rotation speed as needed

    void Update()
    {
        // Check for user input and rotate the camera
        HandleRotation();
    }

    void HandleRotation()
    {
        // Check for input to rotate the camera
        if (Input.GetKey(KeyCode.Q))
        {
            // Rotate counterclockwise
            RotateCamera(-rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            // Rotate clockwise
            RotateCamera(rotationSpeed);
        }
    }

    void RotateCamera(float angle)
    {
        // Calculate the rotation angle based on speed
        float rotationAngle = angle * Time.deltaTime;

        // Rotate the camera around the target
        transform.RotateAround(target.position, Vector3.up, rotationAngle);
    }
}
