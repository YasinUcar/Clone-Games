using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingScript : MonoBehaviour
{
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject gameOverCanvas;
    TimerController timer;
    PlayerController player;
    Spawner spawner;
    ScoreManager score;
    public bool infiniteMode;
    private void Awake()
    {
        gameOverCanvas.SetActive(false);
    }
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        timer = GameObject.Find("Time").GetComponent<TimerController>();
        player.enabled = false;
        Time.timeScale = 0f;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            infiniteMode = false;
            spawner.enabled = true;
            scoreText.SetActive(true);
            timer.GameMod();
            player.enabled = true;
            player.StartingGame();
            score.currentScore = 0;
            this.gameObject.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            infiniteMode = true;
            spawner.enabled = true;
            scoreText.SetActive(true);
            timer.GameMod();
            player.enabled = true;
            player.StartingGame();
            score.currentScore = 0;
            this.gameObject.SetActive(false);
        }
    }
}
