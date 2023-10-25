using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameOver;
    public GameObject player;
    public GameObject alien;
    private PlayerScore playerScore;
    private AlienScore alienScore;
    private float finalScore;

    private void Start()
    {
        playerScore = player.GetComponent<PlayerScore>();
        alienScore = alien.GetComponent<AlienScore>();
        Debug.Log("You Got a High Score: " + SaveData.loadScore());
        setGameOver(false);
    }

    public bool getGameOver()
    {
        return gameOver;
    }

    public void setGameOver(bool g)
    {
        gameOver = g;
        evaluatGameState();
    }

    public void evaluatGameState()
    {
        if (gameOver)
        {
            finalScore = playerScore.getScore() * (alienScore.getAlienScore() / 2f);
            SaveData.saveScore((int)finalScore);
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
