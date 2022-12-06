using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MemoryPuzzle.Base
{
    public class ImageScript : MonoBehaviour
    {
        [SerializeField] private GameObject image_unkown;
        private int _spriteId;
        public int SpriteId { get => _spriteId; }
        private void OnMouseDown()
        {
            if (image_unkown.activeSelf)
            {
                image_unkown.SetActive(false);
            }
            
        }

        public void ChangeSprite(int id, Sprite img)
        {
            _spriteId = id;
            GetComponent<SpriteRenderer>().sprite = img;
        }
    }
}