using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f;             // Speed of camera panning
    public float zoomSpeed = 20f;            // Speed of camera zooming
    public float rotationSpeed = 50f;        // Speed of camera rotation

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isRotating = false;
    private float rotationX;

    private void Start()
    {
        // Store the initial position and rotation of the camera
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        // Camera panning with WASD keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 panDirection = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(panDirection * panSpeed * Time.deltaTime, Space.Self);

        // Camera zooming with the mouse button
        if (Input.GetMouseButton(0))
        {
            float zoomInput = Input.GetAxis("Mouse Y");
            transform.Translate(Vector3.forward * zoomInput * zoomSpeed * Time.deltaTime, Space.Self);
        }

        // Camera rotation
        if (Input.GetMouseButtonDown(2))
        {
            isRotating = true;
            rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetMouseButtonUp(2))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            float rotationY = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationY);
        }

        // Reset camera position and rotation with right-click
        if (Input.GetMouseButtonDown(1))
        {
            transform.position = initialPosition;
            transform.rotation = initialRotation;
        }
    }
}
