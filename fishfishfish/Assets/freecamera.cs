using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freecamera : MonoBehaviour
{
    public float movementSpeed = 10.0f;  // Camera speed
    public float rotationSpeed = 100.0f; // Camera rotation speed

    public float verticalSpeed = 5.0f; // How fast the camera moves up and down

    private float pitch = 0.0f;  // Current pitch Angle
    private float yaw = 0.0f;    // Current yaw Angle

    void Update()
    {
        // Get keyboard input
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Control camera movement

        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);
        movement = Quaternion.Euler(0.0f, transform.eulerAngles.y, 0.0f) * movement;
        transform.position += movement * movementSpeed * Time.deltaTime;

        // Control camera rotation
        yaw += mouseX * rotationSpeed * Time.deltaTime;
        pitch -= mouseY * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(pitch, yaw, 0.0f);
      
        if (Input.GetKey(KeyCode.Space))
        {
            verticalMovement += 1.0f;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            verticalMovement -= 1.0f;
        }

        // Move the camera up and down
        Vector3 verticalTranslation = Vector3.up * verticalMovement * verticalSpeed * Time.deltaTime;
        transform.Translate(verticalTranslation);
    }
}
