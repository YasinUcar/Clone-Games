using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallController : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] Color _colorCyan, _colorYellow, _colorPink, _colorPurple;
    private string _currentColor;
    private Rigidbody2D _rigidbody2D;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        RandomColor();
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {

            _rigidbody2D.velocity = new Vector2(0, _jumpForce);
        }
    }
    void RandomColor()
    {
        int randIndex = Random.Range(0, 4);
        SpriteRenderer _sr = GetComponent<SpriteRenderer>();
        switch (randIndex)
        {
            case 0:
                _currentColor = "Cyan";
                _sr.color = _colorCyan;
                break;
            case 1:
                _currentColor = "Yellow";
                _sr.color = _colorYellow;
                break;
            case 2:
                _currentColor = "Pink";
                _sr.color = _colorPink;
                break;
            case 3:
                _currentColor = "Purple";
                _sr.color = _colorPurple;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Color Changer")
        {
            RandomColor();
            Destroy(other.gameObject);
            return;
        }
        if (other.gameObject.tag != _currentColor)
            print("Game Over");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
