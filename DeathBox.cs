using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (gameObject.tag == "DeathBox")
        {
            SceneManager.LoadScene("SampleScene");
            Time.timeScale = 1;
        }

        if (gameObject.tag == "EndZone")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Main_Menu");
            Time.timeScale = 1;
        }
    }
}
