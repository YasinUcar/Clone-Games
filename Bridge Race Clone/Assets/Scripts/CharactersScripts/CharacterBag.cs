using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBag : MonoBehaviour
{
    [SerializeField] private Transform _bagTransform;
    [SerializeField] private List<GameObject> _bricksGO;
    [SerializeField] private Vector3 _firstPos;
    private AIDestinationBricks _aiDestinationBricks;
    private float _yUp;
    private void Awake()
    {
        _aiDestinationBricks = GetComponent<AIDestinationBricks>();
    }
    private void Start()
    {
        _firstPos = _bagTransform.localPosition;
        _yUp = _bagTransform.localPosition.y;
    }
    public void AddBrick(GameObject outbrickGO)
    {
        outbrickGO.transform.parent = _bagTransform.gameObject.transform;
        outbrickGO.transform.localPosition = new Vector3(_firstPos.x, _yUp, _firstPos.z);

        _yUp += 0.20f;
        outbrickGO.transform.localRotation = Quaternion.Euler(0, 0, 0);
        outbrickGO.tag = "Empty";

        outbrickGO.GetComponent<BoxCollider>().enabled = false;
        _bricksGO.Add(outbrickGO);
    }
    public void RemoveBrick()
    {
        var tempRandomValue = Random.Range(0, _bricksGO.Count - 1);
        if (_aiDestinationBricks != null)
            _aiDestinationBricks.RemoveList(_bricksGO[tempRandomValue]);
        Destroy(_bricksGO[_bricksGO.Count - 1]);
        _bricksGO.RemoveAt(_bricksGO.Count - 1);//last member removing

        _yUp -= 0.20f;
    }



}
