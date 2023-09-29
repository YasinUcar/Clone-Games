using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData", order = 1)]
public class CharactersData : ScriptableObject
{
    [Header("Movement")]
    [SerializeField] private float _movementSpeed;

    [SerializeField] private string _colorCharacter;
    [SerializeField] private string _targetColor;
    [SerializeField] private int _brickCount;
    [SerializeField] private Material _colorMat;
    
    public float MovementSpeed
    {
        get
        {
            return _movementSpeed;
        }
    }
    public string ColorCharacter { get => _colorCharacter; }
    public int BrickCount { get => _brickCount; set => _brickCount = value; }
    public string TargetColor { get => _targetColor; }
    public Material ColorMat { get => _colorMat; }

}
