using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //used to reload scene

public class PauseMenu : MonoBehaviour
{
    //Register if user has has pressed the esc or pause key

    public GameObject ui;

    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf); //Checks if its active or not

        if(ui.activeSelf)
        {
            Time.timeScale = 0f; //speed at which the game is running, dont have to set time.delta time to zero, as we are stopping the game, would have to do it if we were speeding things up or slowingit down
        }        
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
