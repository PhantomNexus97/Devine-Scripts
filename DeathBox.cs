using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour
{
    // Called when a collider enters the trigger zone
    void OnTriggerEnter(Collider col)
    {
        // Check if the collider has the "DeathBox" tag
        if (gameObject.tag == "DeathBox")
        {
            // Reload the "SampleScene" and reset time scale
            SceneManager.LoadScene("SampleScene");
            Time.timeScale = 1;
        }

        // Check if the collider has the "EndZone" tag
        if (gameObject.tag == "EndZone")
        {
            // Unlock the cursor, make it visible, load the "Main_Menu," and reset time scale
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Main_Menu");
            Time.timeScale = 1;
        }
    }
}
