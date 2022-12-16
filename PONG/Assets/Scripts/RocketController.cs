using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _limitX = 2.6f;
    [SerializeField] private float _aiSpeed;
  
    public bool isAi;
    void Start()
    {

    }

    void Update()
    {
        Moving();
    }
    private void Moving()
    {
        Vector3 newPosition = transform.position;
        if (!isAi)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            newPosition = transform.position + new Vector3(horizontalInput * _speed * Time.deltaTime, 0);
           
        }
        else
        {
            float ai = Mathf.Lerp(transform.position.x, BallController.Instance.transform.position.x, _aiSpeed * Time.deltaTime * GameManager.Instance.Score);
            newPosition.x = ai;
           
        }
        newPosition.x = Mathf.Clamp(newPosition.x, -_limitX, _limitX);
        transform.position = newPosition;

    }
}
