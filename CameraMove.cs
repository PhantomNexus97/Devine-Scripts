using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Reference to the transform representing the camera position
    public Transform cameraPosition;

    // Update is called once per frame
    void Update()
    {
        // Set the position of the current object to match the position of the specified cameraPosition transform
        transform.position = cameraPosition.position;
    }
}

