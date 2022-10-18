using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject pipe;
    [SerializeField] float minY, maxY;
    Coroutine spawnerCorutine = null;
    Score score;
    void Start()
    {
        spawnerCorutine = StartCoroutine(SpawnerPipes());
        
    }
    void Update()
    {
        if (spawnerCorutine == null)
        {
            spawnerCorutine = StartCoroutine(SpawnerPipes());
        }
    }
    IEnumerator SpawnerPipes()
    {
        GameObject pipes = Instantiate(pipe, new Vector2(pipe.transform.position.x, Random.Range(minY, maxY)), Quaternion.identity);
        pipes.transform.SetParent(transform);
        yield return new WaitForSeconds(2f);
        spawnerCorutine = null;
    }
}
