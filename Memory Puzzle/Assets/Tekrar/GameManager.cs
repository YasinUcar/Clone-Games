using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MouseClickDetect _mouseClickDetect;
    [SerializeField] private Sprite[] _images;
    private List<int> liste = new List<int> { 0, 1, 2, 3, 4 };
    List<int> newList;
    private int _listLenght;
    int[] arrayDeneme = { 43, 23, 13, 15 };
    int colum, row;
    float xSpace = 4f;
    float ySpace = -5f;


    List<int> randomIzer(List<int> currentList)
    {
        List<int> newList = new List<int>(currentList);
        for (int i = 0; i < newList.Count; i++)
        {
            int oldNumber = newList[i];
            int randNumber = Random.Range(i, newList.Count);
            newList[i] = randNumber;
            newList[randNumber] = oldNumber;
        }

        return newList;
    }
    private void Awake()
    {
        _listLenght = liste.Count;
        SayiUret();

    }
    private void Start()
    {
        Vector3 startPosition = _mouseClickDetect.transform.position;
        randomIzer(liste);
        for (int i = 0; i < colum; i++)
        {
            for (int j = 0; j < row; j++)
            {
                MouseClickDetect gameImage;
                if (i == 0 && j == 0)
                    gameImage = _mouseClickDetect;
                else
                    gameImage = Instantiate(_mouseClickDetect);
                int index = j * colum + i;
                int id = liste[index];
                _mouseClickDetect.ChangeImage(_images[id]);
                float positionX = (xSpace * i) + startPosition.x;
                float positionY = (ySpace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);

            }
        }
    }

    private void SayiUret()
    {
        for (int i = 0; i < _listLenght; i++)
        {
            int oldNumber = liste[i];
            liste.Add(oldNumber);
        }
        liste.Sort();
        OlcuBelirle();
    }
    private void OlcuBelirle()
    {
        colum = liste.Count / 2;
        row = 2;
    }
}
