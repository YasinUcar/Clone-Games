using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    float horizontal, vertical;
    Rigidbody2D rig2d;
    Camera camera;
    Vector2 minBounds, maxBounds;
    void Start()
    {
        Bounds();
        rig2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Movement();
    }
    void Movement()
    {

        horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime; //Getaxis bir yumuşatma uygularken raw direk değeri verir -1 1 ve 0 gibi ara değerler bulundurmaz
        vertical = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        //rig2d.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + horizontal, minBounds.x + 1, maxBounds.x - 1);
        newPos.y = Mathf.Clamp(transform.position.y + vertical, minBounds.y + 1, maxBounds.y - 1);
        transform.position = newPos;



    }
    void Bounds()
    {
        camera = Camera.main;
        minBounds = camera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = camera.ViewportToWorldPoint(new Vector2(1, 1));

    }
}
