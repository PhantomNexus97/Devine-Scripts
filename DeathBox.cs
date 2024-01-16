using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour
{
    // Called when a collider enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the "DeathBox" tag
        if (other.CompareTag("Player"))
        {
            // Reload the "SampleScene" and reset time scale
            SceneManager.LoadScene("SampleScene");
            Time.timeScale = 1;
        }

    }
}
