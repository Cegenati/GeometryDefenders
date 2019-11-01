using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool GameIsOver = false; //if we were to reset the game, game would still be over as it carries thoughout the scene
    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
