using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayGame : MonoBehaviour
{

    [SerializeField] GameObject startingGameCanvas;
    TimerController timer;

    private void Start()
    {
        timer = GameObject.Find("Time").GetComponent<TimerController>();
        timer.currentTime = 100f;

    }
    void Update()
    {
        Time.timeScale = 0f;
        if (Input.GetKeyDown(KeyCode.M))
        {
            this.gameObject.SetActive(false);
            startingGameCanvas.SetActive(true);

        }
    }
}
