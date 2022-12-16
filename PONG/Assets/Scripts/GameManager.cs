using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Canvas _gameCanvas;
    [SerializeField] private TextMeshProUGUI _start, _playAgain;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Animator _scoreTextAnim;
    [SerializeField] private TrailRenderer _trailRenderer;
    private int _score;
    public int Score
    {
        get { return _score; }
        set
        {

            _score = value;
            _scoreText.text = Score.ToString();
            if (_scoreTextAnim.enabled)
            {
                _scoreTextAnim.Play(0);
            }
            else
            {
                _scoreTextAnim.enabled = true;
            }
        }
    }
    private void Start()
    {
        Instance = this;
    }
    public void OnClickStart()
    {
        BallController.Instance.OnStart();
        Score = 1;
        _gameCanvas.enabled = false;
        _start.enabled = false;
        _trailRenderer.Clear();
        
    }
    public void GameOver()
    {
        _gameCanvas.enabled = true;
        _playAgain.enabled = true;
    }
}
