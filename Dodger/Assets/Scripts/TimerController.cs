using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerController : MonoBehaviour
{
    TextMeshProUGUI timeText;
    StartingScript startingScript;
    bool infiniteMode, startGame;
    public float currentTime = 100f;
    void Start()
    {

        startingScript = GameObject.Find("StartingGameCanvas").GetComponent<StartingScript>();
        timeText = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if (startGame)
        {
            if (infiniteMode == true)
            {
                currentTime += Time.deltaTime;
                timeText.text = "Time: " + Mathf.RoundToInt(currentTime).ToString();
            }
            else
            {
                currentTime -= Time.deltaTime;
                timeText.text = "Time: " + Mathf.RoundToInt(currentTime).ToString();
            }
        }
    }
    public void GameMod()
    {
        switch (startingScript.infiniteMode)
        {
            case true:
                currentTime = 1;
                infiniteMode = true;
                startGame = true;
                break;
            case false:
                currentTime = 20;
                infiniteMode = false;
                startGame = true;
                break;
        }
    }
    public float GetCurrentTime()
    {
        return currentTime;
    }


}
