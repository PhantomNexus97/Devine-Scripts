using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the "EndZone" tag
        if (other.CompareTag("Player"))
        {
            // Unlock the cursor, make it visible, load the "Main_Menu," and reset time scale
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Main_Menu");
            Time.timeScale = 1;
        }

    }
}
