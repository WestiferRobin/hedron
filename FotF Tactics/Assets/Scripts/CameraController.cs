using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f;         // Speed of camera panning
    public float zoomSpeed = 20f;        // Speed of camera zooming
    public float rotationSpeed = 50f;    // Speed of camera rotation

    private void Update()
    {
        // Camera panning
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 panDirection = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(panDirection * panSpeed * Time.deltaTime, Space.World);

        // Camera zooming
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(Vector3.forward * zoomInput * zoomSpeed * Time.deltaTime, Space.Self);

        // Camera rotation
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
