using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene("Intro_Skills");
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    // Called when the player clicks on the "Quit" button in the game
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
