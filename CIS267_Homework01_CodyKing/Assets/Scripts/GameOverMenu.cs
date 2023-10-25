using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject gameOverMenu;
    private GameManager gm;

    private void Start()
    {
        gm = gameManager.GetComponent<GameManager>();
    }

    private void Update()
    {
        if (gm.getGameOver() == true)
        {
            showGameOverMenu();
        }
    }

    public void showGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void restartGame()
    {
        gm.setGameOver(false);
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene("LevelOne");

    }
}
