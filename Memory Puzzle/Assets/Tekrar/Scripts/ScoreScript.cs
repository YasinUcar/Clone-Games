using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private int _score = 0;
    private int _attemps = 0;


    public void IncreaseScore()
    {
        _score++;
    }
    public void IncreaseAttempts()
    {
        _attemps++;
    }
    public int GetScore()
    {
        return _score;
    }
    public int GetAttemps()
    {
        return _attemps;
    }
}
