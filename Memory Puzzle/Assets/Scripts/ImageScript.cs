using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MemoryPuzzle.Base
{
    public class ImageScript : MonoBehaviour
    {
        [SerializeField] private GameObject image_unkown;
        [SerializeField] private GameController gameController;
        private int _spriteId;
        public int SpriteId { get => _spriteId; }
        private void OnMouseDown()
        {
            if (image_unkown.activeSelf && gameController.canOpen)
            {
                image_unkown.SetActive(false);
                gameController.imageOpened(this);
            }

        }

        public void ChangeSprite(int id, Sprite img)
        {
            _spriteId = id;
            GetComponent<SpriteRenderer>().sprite = img;
        }
        public void Close()
        {
            image_unkown.SetActive(true);//hide image
        }
    }
}