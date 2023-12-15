using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    // Rotation speed of the platform
    public float _rotationSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the platform using the RotateSpinner method
        RotateSpinner();
    }

    // Function to rotate the platform
    private void RotateSpinner()
    {
        // Rotate the spinner around its y-axis based on the rotation speed and frame time
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
