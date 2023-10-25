using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlienScore : MonoBehaviour
{
    private int alienScore;
    public TMP_Text guiAlienScore;
    // Start is called before the first frame update
    void Start()
    {
        alienScore = 0;
    }

    public int getAlienScore()
    {
        return alienScore;
    }

    public void setAlienScore(int totalScore)
    {
        alienScore += totalScore;
        guiAlienScore.text = "Alien Score: " + alienScore.ToString();
    }
}
