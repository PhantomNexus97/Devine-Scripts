using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Sensitivity for mouse movement along the X and Y axes
    public float sensX;
    public float sensY;

    // Reference to the player's orientation (typically the player's body)
    public Transform orientation;

    // Current X and Y rotation angles
    float xRotation;
    float yRotation;

    // Called when the script is started
    private void Start()
    {
        // Lock the cursor to the center of the screen and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Called every frame
    private void Update()
    {
        // Mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Update Y rotation based on mouse X movement
        yRotation += mouseX;

        // Update X rotation based on mouse Y movement, clamping it to a range to prevent over-rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Set the rotation of the camera based on X and Y rotation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        // Set the orientation rotation (usually the player's body) based on Y rotation
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}

