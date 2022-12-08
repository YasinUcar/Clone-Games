using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private MainImageScript mainImage;
    [SerializeField] float xSpace = 3.5f, ySpace = -7f;
    private List<int> _numberList = new List<int>();
    private int _column, _row;

    private void Start()
    {
        NumberListLenght();
        CreateGameObjects();

    }
    private List<int> RandomIser(List<int> oldList)
    {
        List<int> newList = new List<int>(oldList);
        for (int i = 0; i < newList.Count; i++)
        {
            int oldNumber = newList[i];
            int randNumber = Random.Range(i, newList.Count);
            newList[i] = newList[randNumber];
            newList[randNumber] = oldNumber;

        }
        return newList;
    }
    private void NumberListLenght()
    {

        for (int i = 0; i < _sprites.Length; i++)
        {
            _numberList.Add(i);

        }
        DublicateNumber(_numberList.Count);
    }
    private void DublicateNumber(int numberCount)
    {
        for (int i = 0; i < numberCount; i++)
        {
            int oldNumber = _numberList[i];
            _numberList.Add(oldNumber);
        }
        GridNumbers();
    }
    private void CreateGameObjects()
    {
        Vector3 startPost = mainImage.transform.position;

        _numberList = RandomIser(_numberList);
        for (int i = 0; i < _column; i++)
        {
            for (int j = 0; j < _row; j++)
            {
                MainImageScript newImage;
                if (i == 0 && j == 0)
                    newImage = mainImage;
                else
                    newImage = Instantiate(mainImage);

                int index = j * _column + i;
                int id = _numberList[index];

                newImage.ChangeImage(id, _sprites[id]);

                float xLocation = (xSpace * i) + startPost.x;
                float yLocation = (ySpace * j) + startPost.y;
                newImage.transform.position = new Vector3(xLocation, yLocation, startPost.z);
            }
        }
    }
    private void GridNumbers()
    {
        _column = _numberList.Count / 2;
        _row = _column / 2;
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
