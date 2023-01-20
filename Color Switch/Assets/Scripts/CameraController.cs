using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    void Start()
    {

    }


    void Update()
    {
        if (_ball.transform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, _ball.transform.position.y, transform.position.z);
            
        }
    }
}
