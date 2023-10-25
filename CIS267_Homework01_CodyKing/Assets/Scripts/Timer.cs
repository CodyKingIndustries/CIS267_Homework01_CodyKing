using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float time;
    public TMP_Text guiTime;
    public GameObject gameManager;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = gameManager.GetComponent<GameManager>();
        time = 0;
        updateGUIText();
    }

    // Update is called once per frame
    void Update()
    {
        timerTick();
    }

    public void timerTick()
    {
        time += Time.deltaTime;
        updateGUIText();
    }

    public void updateGUIText()
    {
        int second = Mathf.FloorToInt(time);
        guiTime.text = "Time: " + second;
    }
}
