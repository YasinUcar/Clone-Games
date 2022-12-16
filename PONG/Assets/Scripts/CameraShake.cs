using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }
    [SerializeField] private float _shakeDuration = 0.5f;
    [SerializeField] private float _shakeMagnitude = 0.25f;
    private Vector3 _startingPosition;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _startingPosition = transform.position;
    }

    public void PlayShake()
    {
        StartCoroutine(Shake());
    }
    IEnumerator Shake()
    {
        float elapsedTime = 0; //geçen süre
        while (elapsedTime < _shakeDuration)
        {
            transform.position = _startingPosition + (Vector3)Random.insideUnitCircle * _shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame(); // komutlarımızı karenin sonuna kadar bekletmemizi sağlar.

        }
        transform.position = _startingPosition; //return starting.poss
    }
}
