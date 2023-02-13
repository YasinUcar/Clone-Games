using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public Vector3 direction { get; private set; }
    public float sliceForce=5f;
    [SerializeField] private float _minSliceVelocity = 0.01f;
    private Camera _mainCamera;
    private bool _slicing;
    private TrailRenderer _bladeTrail;
    private Collider _bladeCollider;
    private void Awake()
    {
        _bladeCollider = GetComponent<Collider>();
        _mainCamera = Camera.main;
        _bladeTrail = GetComponentInChildren<TrailRenderer>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlicing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopSlicing();
        }
        else if (_slicing) //elimizi mouse'dan çekmediysek ortasıdaysak işlemin çalışır
        {
            ContinueSlicing();
        }
    }
    void StartSlicing()
    {
        //dilinlemeye başladığımız ilk anda çalışsın istiyoruz
        Vector3 newPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        transform.position = newPosition;

        _slicing = true;
        _bladeCollider.enabled = true;
        _bladeTrail.enabled = true;
        _bladeTrail.Clear();
    }
    void StopSlicing()
    {
        _slicing = false;
        _bladeCollider.enabled = false;
        _bladeTrail.enabled = false;
    }
    void ContinueSlicing()
    {
        Vector3 newPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        direction = newPosition - transform.position; //bıçağımızın hareket ettiği yönü buluyoruz

        //magnitude : Vector3 değişkeninin büyüklük, uzunluk değerini float cinsinden döndürür. X*X+*Y*Y+*Z*Z = MAG

        float velocity = direction.magnitude / Time.deltaTime;//bu yönden ne kadar hızlı olduğunu buluyoruz 



        _bladeCollider.enabled = velocity > _minSliceVelocity;

        transform.position = newPosition;

    }
    private void OnEnable()
    {
        StopSlicing();//her şey tekrar normale dönsün
    }
    private void OnDisable()
    {
        StopSlicing();
    }
}
