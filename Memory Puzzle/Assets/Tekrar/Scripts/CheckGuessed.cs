using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CheckGuessed : MonoBehaviour
{

    [SerializeField] private ScoreScript _scoreScript;
    [SerializeField] TextMeshProUGUI _scoreText, _attempsText;
    private MainImageScript _firstOpen;
    private MainImageScript _secondOpen;

    public bool canOpen
    {
        get
        {
            return _secondOpen == null;
        }
    }
    public void ImageOpen(MainImageScript startObject)
    {
        if (_firstOpen == null)
        {
            _firstOpen = startObject;
        }
        else
        {
            _secondOpen = startObject;
            StartCoroutine(CheckingID());
        }
    }
    private IEnumerator CheckingID()
    {
        if (_firstOpen.SpriteId == _secondOpen.SpriteId)
        {
            _scoreScript.IncreaseScore();
            _scoreText.text = "Score: " + _scoreScript.GetScore();
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            _firstOpen.Close();
            _secondOpen.Close();

        }
        _scoreScript.IncreaseAttempts();
        _attempsText.text = "Attempts: " + _scoreScript.GetAttemps();

        _firstOpen = null;
        _secondOpen = null;
    }


}
