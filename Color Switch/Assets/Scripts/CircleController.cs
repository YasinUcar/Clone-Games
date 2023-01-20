using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private bool _direction;
    void Start()
    {

    }


    void Update()
    {
        if (!_direction)
            transform.Rotate(0, 0, _speed * Time.deltaTime);
        else
            transform.Rotate(0, 0, -_speed * Time.deltaTime);

    }
}
