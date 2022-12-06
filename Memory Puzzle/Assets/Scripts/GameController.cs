using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MemoryPuzzle.Base
{
    public class GameController : MonoBehaviour
    {
        public const int colums = 4;
        public const int row = 2;
        public const float XSpace = 4f;
        public const float YSpace = -5f;
        [SerializeField] private ImageScript startObject;
        [SerializeField] private Sprite[] _images;
        private int[] _randomIser(int[] locations)
        {
            int[] array = locations.Clone() as int[];
            for (int i = 0; i < array.Length; i++)
            {
                int newArray = array[i];
                int j = Random.Range(i, array.Length);
                array[i] = j;
                array[j] = newArray;
            }
            return array;
        }
        private void Start()
        {
            int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3 };
            locations = _randomIser(locations);
            Vector3 startPosition = startObject.transform.position;
            for (int i = 0; i < colums; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    ImageScript gameImage;
                    if (i == 0 && j == 0)
                        gameImage = startObject;
                    else
                        gameImage = Instantiate(startObject);

                    int index = j * colums + i;
                    int id = locations[index];

                    gameImage.ChangeSprite(id, _images[id]);

                    float positionX = (XSpace * i) + startPosition.x;
                    float positionY = (YSpace * j) + startPosition.y;

                    gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
                }
            }
        }

    }
}