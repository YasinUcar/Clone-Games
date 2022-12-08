using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainImageScript : MonoBehaviour
{
    [SerializeField] private CheckGuessed _checkGuessed;
    [SerializeField] private GameObject _imageUnkown;
    private int _spriteId;
    public int SpriteId { get => _spriteId; }
    private void OnMouseUp()
    {
        if (_imageUnkown.activeSelf && _checkGuessed.canOpen)
        {
            _imageUnkown.SetActive(false);
            _checkGuessed.ImageOpen(this);
        }
    }
    public void ChangeImage(int id, Sprite image)
    {
        _spriteId = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
    public void Close()
    {
        _imageUnkown.SetActive(true);
    }
}
