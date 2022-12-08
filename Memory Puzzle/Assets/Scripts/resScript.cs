using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MemoryPuzzle.Base
{
    public class resScript : MonoBehaviour
    {
        //  [SerializeField] private GameController gameController;
        [SerializeField] private GameManager gameController;
        [SerializeField] private string functionOnClick;

        private void OnMouseOver()
        {
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            if (sprite != null)
            {
                sprite.color = Color.cyan;
            }
        }
        private void OnMouseDown()
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 1.0f);
        }
        private void OnMouseUp()
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 1f);
            if (gameController != null)
            {
                gameController.SendMessage(functionOnClick);
            }
        }
        private void OnMouseExit()
        {
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            if (sprite != null)
            {
                sprite.color = Color.white;
            }
        }
    }
}