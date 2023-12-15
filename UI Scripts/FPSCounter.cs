using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public TextMeshProUGUI _fpsCounterText;  // Reference to the TextMeshProUGUI component for displaying FPS.
    public float _deltaTime;  // Time difference between frames for calculating FPS.

    void Update()
    {
        // Smoothly calculate the delta time to avoid sudden fluctuations.
        _deltaTime += (Time.deltaTime - _deltaTime) * 0.1f;

        // Calculate Frames Per Second (FPS) using the smoothed delta time.
        float fps = 1.0f / _deltaTime;

        // Update the FPS counter text with the rounded-up value of FPS.
        _fpsCounterText.text = Mathf.Ceil(fps).ToString();
    }
}

