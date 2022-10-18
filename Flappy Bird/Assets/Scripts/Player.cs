using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    [SerializeField][Range(0, 100)] int jumpSpeed;
    [SerializeField] TextMeshProUGUI scoreText;
    Rigidbody2D rigidbody;
    Score score;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        score = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Score>();
    }
    void Update()
    {
        Jump();
    }
    void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.velocity += Vector2.up * jumpSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Score")
        {
            print("Score çalişti");
            score.currentScore++;
            scoreText.text = score.currentScore.ToString();
        }
        else
        {
            Time.timeScale=0;
        }
    }

}
