
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BridgeNumber", menuName = "ScriptableObjects/BridgeData", order = 1)]
public class BridgeData : ScriptableObject
{
    //TODO :Burada bulunan baz� yap�lar daha kompleks olabilir �rne�in totalCount manuel olarak de�il bir start i�lemide arama yaparak de�er alabilir

    [SerializeField] private int _totalCount;
    [SerializeField] private int _redCount;
    [SerializeField] private int _greenCount;
    [SerializeField] private int _blueCount;
    [SerializeField] private int _yellowCount;
    [SerializeField] private int _totalDifferenceTarget;
    private Transform _bridgeLastLocation;
    private GameObject[] _bridgeArray;
    public int TotalCount { get => _totalCount; set => _totalCount = value; }
    public int BlueCount { get => _blueCount; set => _blueCount = value; }
    public int RedCount { get => _redCount; set => _redCount = value; }
    public int GreenCount { get => _greenCount; set => _greenCount = value; }
    public int YellowCount { get => _yellowCount; set => _yellowCount = value; }
    public Transform BridgeLastLocation { get => _bridgeLastLocation; set => _bridgeLastLocation = value; }
    public int TotalDifferenceTarget { get => _totalDifferenceTarget; set => _totalDifferenceTarget = value; }
    public GameObject[] BridgeArray { get => _bridgeArray; set => _bridgeArray = value; }



}
