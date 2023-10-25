using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnMainMenu : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void loadLevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void loadLevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void loadLevelThree()
    {
        SceneManager.LoadScene("LevelThree");
    }

    public void exitGame()
    {
        //will not work in Unity editor
        Application.Quit();
    }

    public void loadInfo()
    {
        SceneManager.LoadScene("GameInfo");
    }

    public void loadHighScore()
    {
        SceneManager.LoadScene("HighScores");
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
