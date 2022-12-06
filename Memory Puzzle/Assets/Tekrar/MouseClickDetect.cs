using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickDetect : MonoBehaviour
{
    [SerializeField] private GameObject _imageUnkown;
    private void OnMouseDown()
    {
        if (_imageUnkown.activeSelf)
        {
            _imageUnkown.SetActive(false);
        }

    }
    public void ChangeImage(Sprite image)
    {
        GetComponent<SpriteRenderer>().sprite = image;
    }
}
