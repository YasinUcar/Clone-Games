using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using Event.Brick;
using Unity.Mathematics;

public class BrickController : MonoBehaviour
{
    [SerializeField] private GameObject _brickGO;

    [SerializeField] private int brickAmount = 12;

    //TODO : Bu yap� daha sadece �ekilde nas�l kurulabilir material i�erden mi olu�turulmal�

    [SerializeField] private Material _yellowMat, _blueMat, _greenMat, _redMat;
    [ReadOnly]
    [SerializeField] private List<Material> _brickColors; //0 : Yellow 1: Blue 2:Green 3:Red
    private int yellowBrickCount, blueBrickCount, redBrickCount, greenBrickCount;


    [SerializeField] private Transform _minLocation;
    [SerializeField] private Transform _maxLocation;
    private float _firstLocation, _lastLocation;

    private void Awake()
    {
        BrickEvent.CreateFirstBricks += LocationsUpgrader;
        BrickEvent.CreateFirstBricks += BrickColors;
        BrickEvent.CreateFirstBricks += RandomBrickInstantiate;
    }
    private void Start()
    {
        BrickEvent.CreateFirstBricks?.Invoke();
    }
    private void LocationsUpgrader()
    {
        _firstLocation = _minLocation.position.x;
        _lastLocation = _maxLocation.position.x;
    }
    void RandomBrickInstantiate()
    {
        for (int i = 0; i < brickAmount; i++)
        {
            Vector3 newPos = new Vector3(_firstLocation, _brickGO.transform.position.y, _minLocation.position.z);
            GameObject tempBrick = Instantiate(_brickGO.gameObject, newPos, Quaternion.identity);
            tempBrick.transform.parent = this.gameObject.transform;

            tempBrick.GetComponent<Renderer>().material = _brickColors[i];//Change MaterialA
            tempBrick.tag = _brickColors[i].name;
            tempBrick.name = _brickColors[i].name;

            if (_firstLocation < _lastLocation)
            {
                _firstLocation += 1.5f;
            }
            else
            {
                _minLocation.position = new Vector3(_minLocation.position.x, _minLocation.position.y, _minLocation.position.z - 1);
                LocationsUpgrader();

            }
        }
        BrickEvent.FirstDestinationEvent?.Invoke();
    }

    void BrickColors()
    {
        for (int i = 0; i < brickAmount; i++)
        {
            int maxColor = brickAmount / 4;
            if (yellowBrickCount < maxColor)
            {
                _brickColors.Add(_yellowMat);
                yellowBrickCount++;
            }
            else if (blueBrickCount < maxColor)
            {
                _brickColors.Add(_blueMat);
                blueBrickCount++;
            }
            else if (greenBrickCount < maxColor)
            {
                _brickColors.Add(_greenMat);
                greenBrickCount++;
            }
            else if (redBrickCount < maxColor)
            {
                _brickColors.Add(_redMat);
                redBrickCount++;
            }
            ShuffleList(_brickColors);
        }

        void ShuffleList(List<Material> matList)
        {
            for (int i = 0; i < matList.Count - 1; i++)
            {
                var r = UnityEngine.Random.Range(i, matList.Count - 1);
                {
                    var tmp = matList[i];
                    matList[i] = matList[r];
                    matList[r] = tmp;
                }
            }
        }
    }
    private void OnDestroy()
    {
        BrickEvent.CreateFirstBricks -= RandomBrickInstantiate;
        BrickEvent.CreateFirstBricks -= LocationsUpgrader;
        BrickEvent.CreateFirstBricks -= BrickColors;
    }
}
