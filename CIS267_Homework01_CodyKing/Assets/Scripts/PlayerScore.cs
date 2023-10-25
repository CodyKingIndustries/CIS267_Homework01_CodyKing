using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int playerScore;
    public TMP_Text guiScore;
    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
    }

    public int getScore()
    {
        return playerScore;
    }

    public void setPlayerScore(int totalScore)
    {
        playerScore += totalScore;
        guiScore.text = "Cow Score: " + playerScore.ToString();
    }
}
