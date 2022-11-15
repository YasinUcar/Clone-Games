using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    public int currentScore = 0;
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }
    int GetCurrentScore()
    {
        scoreText.text = "Score: " + currentScore.ToString();
        return currentScore;
    }

    public void IncreaseScore(int score)
    {
        currentScore += score;
        GetCurrentScore();
    }
    public void ReduceScore(int score)
    {
        currentScore -= score;
        GetCurrentScore();
    }
}
