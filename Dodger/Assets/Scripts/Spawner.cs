using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnObjects;
    Camera camera;
    ScoreManager score;
    Vector2 minBounds, maxBounds;
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
        camera = Camera.main;
        minBounds = camera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = camera.ViewportToWorldPoint(new Vector2(1, 1));
        StartCoroutine(ObjectSpawner());

    }

    IEnumerator ObjectSpawner()
    {
        while (true)
        {
            var randPos = Random.Range(minBounds.x + 0.5f, maxBounds.x - 0.5f);
            var position = new Vector2(randPos, transform.position.y);
            GameObject gameObject = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.1f,0.4f));
            Destroy(gameObject, 5f);
            score.IncreaseScore(10);
        }
    }
}
