using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CokBoyutluDize : MonoBehaviour
{
    private int[,] _bridgeColorArray = new int[4, 2];
    void Start()
    {
        StartCoroutine(DenemeYazdir());
        _bridgeColorArray[0, 0] = 5;
        _bridgeColorArray[0, 1] = 6;
        _bridgeColorArray[1, 0] = 15;
        _bridgeColorArray[1, 1] = 18;
        _bridgeColorArray[2, 0] = 77;
        _bridgeColorArray[2, 1] = 4;
        _bridgeColorArray[3, 0] = 33;
        _bridgeColorArray[3, 1] = 28;
    }
    void Update()
    {

        //for (int i = 0; i < 4; i++)
        //{
        //    for (int k = 0; k < 2; k++)
        //    {
        //        print(_bridgeColorArray[i, k]);
        //    }
        //}

    }
    IEnumerator DenemeYazdir()
    {
        yield return new WaitForSeconds(2f);
        print("Yazdir");
    }
}
