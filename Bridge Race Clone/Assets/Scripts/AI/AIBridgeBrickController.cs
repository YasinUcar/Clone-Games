using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBridgeBrickController : MonoBehaviour
{
    [SerializeField] CharactersData _charactersData;
    private CharacterBag _characterBag;
    private string _playerColorName;

    private void Awake()
    {
        _playerColorName = _charactersData.ColorCharacter + "BridgeBrick";
        _characterBag = GetComponent<CharacterBag>();
    }
    public void ControlBrickStatus(string tagName, BridgeBrickController bridgeBrickController)
    {
        if (tagName == _playerColorName)
            return;
        switch (tagName)
        {
            case "BlueBridgeBrick":
                bridgeBrickController.ChangeMat(_charactersData, _characterBag);
                break;
        }
    }

}
