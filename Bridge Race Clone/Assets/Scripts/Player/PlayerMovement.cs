using Manager.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharactersData _playerDataSO;
    [SerializeField] private InputReader _inputReader;
    private Rigidbody _rigidbody;
    private Vector2 _inputVector;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        _inputReader.MoveEvent += OnMove;
    }
    private void OnDisable()
    {
        _inputReader.MoveEvent -= OnMove;
    }
    private void FixedUpdate()
    {
        MovementController();
        Vector3 newRot = new Vector3(0, 90, 0);
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            transform.Rotate(newRot * 1f * Time.deltaTime);
        RotationObject();
    }
    private void OnMove(Vector2 movement)
    {
        _inputVector = movement;
    }
    private void MovementController()
    {
        if (_inputVector == Vector2.zero)
        {
            MasterSingleton.Instance.AnimationManager.ChangeAnimState(this.gameObject, "Idle");
            return;
        }
        //_rigidbody.velocity = new Vector3(0, 0, 0); //h�z�n son de�eri pozitif oldu�u i�in son andan �nce de�erleri 0 da �ekiyoruz ve daha sonra i�lem yapt�r�yoruz
        MasterSingleton.Instance.AnimationManager.ChangeAnimState(this.gameObject, "Run");
        _rigidbody.velocity = new Vector3(_inputVector.x * _playerDataSO.MovementSpeed, 0f, _inputVector.y * _playerDataSO.MovementSpeed);
    }
    private void RotationObject()
    {

        if (_inputVector != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(new Vector3(_inputVector.x, 0f, _inputVector.y), Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 5f);
        }
    }
}
