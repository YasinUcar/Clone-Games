using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BridgeBrickController : MonoBehaviour
{

    private MeshRenderer _meshRenderer;
    private BoxCollider _boxCollider;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _boxCollider = GetComponent<BoxCollider>();

    }
    public void ChangeMat(CharactersData _charactersData, CharacterBag _characterBag)
    {
        if (_charactersData.BrickCount <= 0)
            return;
        if (this.gameObject.tag == _charactersData.TargetColor + "BridgeBrick")
            return;


        //if (_charactersData.BrickCount > 0)
        //{
        _meshRenderer.enabled = true;
        _charactersData.BrickCount--;
        this.gameObject.tag = _charactersData.TargetColor + "BridgeBrick";
        GetComponent<Renderer>().material = _charactersData.ColorMat;
        _characterBag.RemoveBrick();

        if (GetComponentInParent<BridgeController>() != null)
        {

            if (this.gameObject.CompareTag("BridgeBrick"))
                GetComponentInParent<BridgeController>().AddData(_charactersData.TargetColor);
            else
            {
                string tag = this.gameObject.tag;
                GetComponentInParent<BridgeController>().ReduceData(tag);
                GetComponentInParent<BridgeController>().AddData(_charactersData.TargetColor);
            }


        }
        //}
    }

    public void ChangeTriggerStatus(bool triggerStatus)
    {
        _boxCollider.isTrigger = triggerStatus;
        print("Trigger Çalişti");
    }
}