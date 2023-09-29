using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Event.Brick;
using AI.Controller;
public class AIDestinationBricks : MonoBehaviour
{
    [SerializeField] List<GameObject> _brickList = new List<GameObject>();
    [SerializeField] private CharactersData _charactersData;
    private AIDestinationController _aiDestinationController;
    private string _targetColor;
    private bool _allgathered;

    private void Awake()
    {
        _aiDestinationController = GetComponent<AIDestinationController>();
        _targetColor = _charactersData.TargetColor;
        BrickEvent.FirstDestinationEvent += ListToBricks;
        BrickEvent.NextDestinationControllerEvent += ClosestBrick;
        BrickEvent.BridgeBrickEvent += ClosestBrick;
    }

    void ListToBricks()
    {
        foreach (GameObject temp in GameObject.FindGameObjectsWithTag(_targetColor))
        {
            _brickList.Add(temp);
        }
        ClosestBrick();
    }
    void ClosestBrick()
    {
        if (_brickList.Count <= 0)
            return;
        GameObject gonderilecekObje = null;
        for (int i = 0; i < _brickList.Count - 1; i++)
        {
            gonderilecekObje = _brickList[i].gameObject;
            float closestObje = Vector2.Distance(this.transform.position, _brickList[i].transform.position);
            if (closestObje > Vector2.Distance(this.transform.position, _brickList[i + 1].transform.position))
            {
                gonderilecekObje = _brickList[i + 1];
                //_brickList.RemoveAt(i + 1);
            }
            //else
            //    _brickList.RemoveAt(i);

        }
        _aiDestinationController.DestinationObject(gonderilecekObje.transform);

        //RemoveList(gonderilecekObje);
        // _brickList.Remove(gonderilecekObje);

        //_allgathered = true;
    }
    public void RemoveList(GameObject gameObject)
    {
        _brickList.Remove(gameObject);
    }

    private void OnDestroy()
    {

        BrickEvent.FirstDestinationEvent -= ListToBricks;
        BrickEvent.NextDestinationControllerEvent -= ListToBricks;
        BrickEvent.BridgeBrickEvent -= ListToBricks;
    }
}
