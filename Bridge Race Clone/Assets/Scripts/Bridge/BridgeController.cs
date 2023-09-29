using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEditor.AI;
using UnityEngine;

public class BridgeController : MonoBehaviour
{

    [SerializeField] private BridgeData _bridgeData;
    [SerializeField] private GameObject[] _brickArrays;
    [SerializeField] private Transform _lastLocation;

    //DELETE
    private void AddArrayData()
    {
        for (int i = 0; i < _brickArrays.Length; i++)
            _bridgeData.BridgeArray[i] = _brickArrays[i];
    }
    private void Awake()
    {
        //TODO : Bu k�s�m oyunun ba�lad��� bir  event ile kontrol edilirse daha sa�l�kl� olacakt�r
        AddArrayData();
        _bridgeData.RedCount = 0;
        _bridgeData.BlueCount = 0;
        _bridgeData.BridgeLastLocation = _lastLocation;
        ChangePos();

    }
    void ChangePos()
    {
        for (int i = 1; i < _brickArrays.Length; i++)
        {
            _brickArrays[i].transform.position = new Vector3(_brickArrays[i].transform.position.x, _brickArrays[i - 1].transform.position.y + 0.11f, _brickArrays[i - 1].transform.position.z + 0.35f);
        }
    }
    public void AddData(string _colorName)
    {
        switch (_colorName)
        {
            case "Blue":
                _bridgeData.BlueCount++;
                break;
            case "Red":
                _bridgeData.RedCount++;
                break;
        }
        // ControlTotalCount();
    }
    //TODO : Azalatma i�lemi buradan yap�lacak
    public void ReduceData(string _colorName)
    {
        switch (_colorName)
        {
            case "Blue":
                _bridgeData.BlueCount--;
                break;
            case "Red":
                _bridgeData.RedCount--;
                break;
        }
    }

    //void ControlTotalCount()
    //{
    //    if (_bridgeData.BlueCount >= _bridgeData.TotalCount)
    //        print("Oyun Bitti");
    //    if (_bridgeData.RedCount >= _bridgeData.TotalCount)
    //        print("Oyun Bitti");
    //}
}
