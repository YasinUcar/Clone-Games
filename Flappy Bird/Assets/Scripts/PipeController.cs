using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] float speed;
    void Start()
    {

    }


    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        Destroy(this.gameObject, 4f);
    }
}
