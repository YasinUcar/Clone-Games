using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _gridArea;
    void Start()
    {
        RandomizePositionFood();
    }
    void Update()
    {

    }
    void RandomizePositionFood()
    {
        Bounds bounds = _gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        //alanı ızgara gibi düşünürsek bunların hep tam sayı gelmesini istiyoruz o yüzden round ile dönüştürmemiz gerekiyor 
        //buda yılanla yemeğin tam olarak aynı hizaya gelmesini sağlamaktadır
        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            RandomizePositionFood();
    }
}
