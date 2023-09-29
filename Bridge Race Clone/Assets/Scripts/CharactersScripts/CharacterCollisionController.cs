using AI.Controller;
using Event.Brick;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterCollisionController : MonoBehaviour
{
    [SerializeField] private CharactersData _charactersData;
    private AIDestinationController _aiDestinationController;
    private AIDestinationBricks _aIDestinationBricks;
    private CharacterBag _characterBag;
    private string _playerColorName;
    private string _targetColorName;

    private void Awake()
    {
        _characterBag = GetComponent<CharacterBag>();
        _playerColorName = _charactersData.ColorCharacter;
        _targetColorName = _charactersData.TargetColor;
        _aiDestinationController = GetComponent<AIDestinationController>();
        _aIDestinationBricks = GetComponent<AIDestinationBricks>();

    }
    private void Start()
    {
        // this.gameObject.tag = _playerColorName;
        int layerNumber = LayerMask.NameToLayer(_playerColorName);
        this.gameObject.layer = layerNumber;
        //TODO : Bu k�s�m oyunun ba�lad��� bir  event ile kontrol edilirse daha sa�l�kl� olacakt�r
        _charactersData.BrickCount = 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_targetColorName))
        {
            _charactersData.BrickCount++;
            _characterBag.AddBrick(other.gameObject);
            if (GetComponent<AIDestinationBricks>() != null)
            {
                _aIDestinationBricks.RemoveList(other.gameObject);
                BrickEvent.NextDestinationControllerEvent?.Invoke();


            }
        }
        if (_charactersData.BrickCount != 0)
        {
            if (other.gameObject.CompareTag("BridgeBrick"))
            {

                if (other.gameObject.GetComponent<BridgeBrickController>() != null)
                {
                    other.gameObject.GetComponent<BridgeBrickController>().ChangeMat(_charactersData, _characterBag);
                    other.gameObject.GetComponent<BridgeBrickController>().ChangeTriggerStatus(false);
                    
                }
            }

            if (GetComponent<AIBridgeBrickController>() != null)
            {
                GetComponent<AIBridgeBrickController>().ControlBrickStatus(other.gameObject.tag, other.gameObject.GetComponent<BridgeBrickController>());
            }
        }
        else
        {
            if (GetComponent<AIDestinationController>() != null)
            {

                _aiDestinationController.StopDestination();

            }
        }
    }
    //TODO : Bu kısım düzenlenmeli
    private void OnCollisionStay(Collision collision)
    {
        //TODO : Diğer renkler buraya yazılacak
        if (collision.gameObject.CompareTag("Blue" + "BridgeBrick") || collision.gameObject.CompareTag("Red" + "BridgeBrick"))
        {
            if (collision.gameObject.GetComponent<StairClimb>() != null)
            {
                GetComponent<StairClimb>().stepClimb();

            }
        }
    }
    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (_charactersData.BrickCount != 0)
    //     {
    //         if (collision.gameObject.CompareTag("BridgeBrick"))
    //         {
    //             print("�ali�ti");
    //             if (collision.gameObject.GetComponent<BridgeBrickController>() != null)
    //             {
    //                 collision.gameObject.GetComponent<BridgeBrickController>().ChangeMat(_charactersData, _characterBag);
    //                 collision.gameObject.GetComponent<BridgeBrickController>().ChangeTriggerStatus(false);
    //             }
    //         }

    //         if (GetComponent<AIBridgeBrickController>() != null)
    //         {
    //             GetComponent<AIBridgeBrickController>().ControlBrickStatus(collision.gameObject.tag, collision.gameObject.GetComponent<BridgeBrickController>());
    //         }
    //     }
    // }
}

