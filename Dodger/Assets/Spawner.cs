using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnObjects;
    Camera camera;
    Vector2 minBounds, maxBounds;
    void Start()
    {
        camera = Camera.main;
        minBounds = camera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = camera.ViewportToWorldPoint(new Vector2(1, 1));
        StartCoroutine(ObjectSpawner());

    }

    IEnumerator ObjectSpawner()
    {
        while (true)
        {
            var randPos = Random.Range(minBounds.x, maxBounds.x);
            var position = new Vector2(randPos, transform.position.y);
            GameObject gameObject = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject, 5f);

        }
    }
}
