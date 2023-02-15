using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    [SerializeField] private Transform _segmentPrefab; //segment : parça
    private List<Transform> _segments;
    Vector2 _direction = Vector2.right;
    void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        transform.Translate(_direction.x, _direction.y, 0f); //speed ayarlaması project settings fixed timestep'den değiştirildi
    }
    void Grow()
    {
        Transform segment = Instantiate(_segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }
    // if (lastIndex == 3)
    //     {
    //         return;
    //     }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up / 2;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down / 2;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right / 2;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left / 2;
        }
    }
    void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++) //ilk objeyi silmiyoruz
            Destroy(_segments[i].gameObject);

        _segments.Clear(); //listeyi tekrar sıfırlıyoruz
        _segments.Add(this.transform);//başlangıçta oluşturduğumuz transformu tekrar dahil ediyoruz

        this.transform.position = Vector3.zero;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
            Grow();
        else if (other.CompareTag("Obstacle"))
            ResetState();
    }
}

