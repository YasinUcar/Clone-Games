using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _targetObject;
    [SerializeField] private Vector3 _cameraPositionOffset;
    [SerializeField] private float _cameraraLerpSpeed;
    private void Start()
    {
       
    }
    void Update()
    {
        transform.position = Vector3.Lerp(this.transform.position, _targetObject.position + _cameraPositionOffset, _cameraraLerpSpeed * Time.deltaTime);
    }
}
