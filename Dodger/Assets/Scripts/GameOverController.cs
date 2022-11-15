using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    TimerController timer;
    void Start()
    {
        StartCoroutine(FindTimerController());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    IEnumerator FindTimerController()
    {

        timer = GameObject.Find("Time").GetComponent<TimerController>();
        yield return timer != null;


    }
    private void Update()
    {
        if (timer.GetCurrentTime() <= Mathf.Epsilon)
        {
            gameOverCanvas.SetActive(true);

        }
    }
}
