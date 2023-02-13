using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _fruitPrefabs;
    [SerializeField] private float _minSpawnDelay = 0.25f, _maxSpawnDelay = 1f;
    [SerializeField] private float _minAngle = -15f, _maxAngle = 15f;
    [SerializeField] private float _minForce = 18f, _maxForce = 22f;
    [SerializeField] private float _maxLifeTime = 5f;

    private Collider _spawnArea;


    private void Awake()
    {
        _spawnArea = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f); //ilk oluşturulurken 2 saniye bekle
        while (enabled)
        {

            float randomTime = Random.Range(_minSpawnDelay, _maxSpawnDelay);
            GameObject prefab = _fruitPrefabs[Random.Range(0, _fruitPrefabs.Length)];
            Vector3 position = new Vector3();
            position.x = Random.Range(_spawnArea.bounds.min.x, _spawnArea.bounds.max.x);
            position.y = Random.Range(_spawnArea.bounds.min.y, _spawnArea.bounds.max.y);
            position.z = Random.Range(_spawnArea.bounds.min.z, _spawnArea.bounds.max.z);

            Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(_minAngle, _maxAngle));
            GameObject fruit = Instantiate(prefab, position, rotation);
            float force = Random.Range(_minForce, _maxForce);
            //ForceMode Impulse : Objeye anlık bir kuvvet ekler Force ise sürekli ekler
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);

            Destroy(fruit, _maxLifeTime);
            yield return new WaitForSeconds(randomTime);
        }
    }
}