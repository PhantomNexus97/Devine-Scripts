using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float _rotationSpeed = 50f; // Rotation speed of the platform

    void Update()
    {
        RotateSpinner();
    }

    private void RotateSpinner()
    {
        // Rotate the spinner around its y-axis
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
