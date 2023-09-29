using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Controller;
using Event.Brick;
using System.Runtime.InteropServices.WindowsRuntime;

public class AIDestinationBridge : MonoBehaviour
{
    [SerializeField] BridgeData[] _bridgesData;
    [SerializeField] private CharactersData _charactersData;
    private AIDestinationController _destinationController;
    private int[,] _bridgeColorArray = new int[4, 2]; //0 : Blue 1: Red 2:Green 3:Yellow
    private string _targetColor;
    private int _targetNumber = 0;

    private int _bridge1OtherBricksCount = 0, _bridge2OtherBricksCount = 0;
    private int _bridge1TargetTotalCount = 0, _bridge2TargetTotalCount = 0;

    private void Awake()
    {
        _destinationController = GetComponent<AIDestinationController>();
        _targetColor = _charactersData.TargetColor;
        BrickEvent.FirstDestinationEvent += ControlBrick;
        BrickEvent.NextDestinationControllerEvent += ControlBrick;
        BrickEvent.BridgeBrickEvent += ControlBrick;
    }
    void ControlBrick()
    {
        //TODO: Buradaki d�ng� i�in daha mant�kl� bir ��z�m bulunabilir mi
        for (int i = 0; i < _bridgesData.Length; i++)
        {
            for (int k = 0; k < 4; k++)
            {
                if (k == 0)
                    _bridgeColorArray[k, i] = _bridgesData[i].BlueCount;
                if (k == 1)
                    _bridgeColorArray[k, i] = _bridgesData[i].RedCount;
                if (k == 2)
                    _bridgeColorArray[k, i] = _bridgesData[i].GreenCount;
                if (k == 3)
                    _bridgeColorArray[k, i] = _bridgesData[i].YellowCount;
            }
        }
        TotalBridgeCount();
    }
    void TotalBridgeCount()
    {
        switch (_targetColor)
        {
            case "Blue":
                _targetNumber = 0;
                break;
            case "Red":
                _targetNumber = 1;
                break;
        }
        for (int i = 0; i < _bridgesData.Length; i++)
        {
            for (int k = 0; k < 4; k++)
            {
                if (i == 0)
                {
                    //_bridgesData[0].TotalCount += _bridgeColorArray[k, i];
                    if (_targetNumber != k)
                        _bridge1OtherBricksCount += _bridgeColorArray[k, i];
                    else if (_targetNumber == k)
                    {
                        if (i == 0)
                            _bridge1TargetTotalCount += _bridgeColorArray[k, i];
                    }
                    if (i == 1)
                    {
                        // _bridgesData[1].TotalCount += _bridgeColorArray[k, i];
                        if (_targetNumber != k)
                            _bridge2OtherBricksCount += _bridgeColorArray[k, i];
                        else if (_targetNumber == k)
                        {
                            if (i == 1)
                                _bridge2TargetTotalCount += _bridgeColorArray[k, i];
                        }
                    }

                }
            }
        }
        OptimalBridge();
    }
    private BridgeData OptimalBridgeData()
    {
        int differenceBridge1 = _bridgesData[0].TotalCount - _bridge1TargetTotalCount;
        int differenceBridge2 = _bridgesData[1].TotalCount - _bridge2TargetTotalCount;

        if (differenceBridge1 < differenceBridge2)
        {
            _bridgesData[0].TotalDifferenceTarget = differenceBridge1;
            return _bridgesData[0];
        }

        else if (differenceBridge2 < differenceBridge1)
        {
            _bridgesData[1].TotalDifferenceTarget = differenceBridge2;
            return _bridgesData[1];
        }
        else if (differenceBridge1 == differenceBridge2)
        {
            if (_bridge1OtherBricksCount < _bridge2OtherBricksCount)
            {
                _bridgesData[0].TotalDifferenceTarget = differenceBridge1;
                return _bridgesData[0];
            }
            else if (_bridge1OtherBricksCount > _bridge2OtherBricksCount)
            {
                _bridgesData[1].TotalDifferenceTarget = differenceBridge2;
                return _bridgesData[1];
            }
            else if (_bridge1OtherBricksCount == _bridge2OtherBricksCount)
                return ClosestBridge();
            else
            {
                int tempRand = Random.Range(0, _bridgesData.Length);
                return _bridgesData[tempRand];
            }
        }
        else
            return null;

    }
    private BridgeData ClosestBridge()
    {
        int bridgeDataNumber = 0;
        for (int i = 0; i < _bridgesData.Length - 1; i++)
        {
            var firstBridge1 = Vector3.Distance(this.transform.position, _bridgesData[i].BridgeLastLocation.position);
            var secondBridge = Vector3.Distance(this.transform.position, _bridgesData[i + 1].BridgeLastLocation.position);
            if (secondBridge < firstBridge1)
            {
                bridgeDataNumber = i + 1;
            }
            else
            {
                bridgeDataNumber = i;
            }
        }
        _bridgesData[bridgeDataNumber].TotalDifferenceTarget = _bridgesData[bridgeDataNumber].TotalCount - _bridge1TargetTotalCount;
        return _bridgesData[bridgeDataNumber];
    }

    void OptimalBridge()
    {
        var data = OptimalBridgeData();
        _destinationController.DestinationObject(data);

    }
    //public Vector3 OptimalBridge()
    //{
    //    return OptimalBridgeData().BridgeLocation;
    //}

    private void OnDestroy()
    {
        BrickEvent.FirstDestinationEvent -= ControlBrick;
        BrickEvent.NextDestinationControllerEvent -= ControlBrick;
        BrickEvent.BridgeBrickEvent -= ControlBrick;
    }
}



