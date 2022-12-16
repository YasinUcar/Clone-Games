using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController Instance;
    [SerializeField] private float _speed;
    [SerializeField] private AudioClip _trickSFX, _scoreSFX;
    [SerializeField] private AudioManager _audioPlayer;
    [SerializeField] private TrailRenderer _trailRenderer;

    private Rigidbody2D _rig2d;

    private void Awake()
    {

        Instance = this;
        _rig2d = GetComponent<Rigidbody2D>();
    }
    public void OnStart()
    {
        _trailRenderer.Clear();
        _rig2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        _rig2d.AddForce(Vector2.down * _speed);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Rocket"))
        {
            _audioPlayer.PlaySound(_trickSFX);
            RocketController rocket = other.gameObject.GetComponent<RocketController>();
            int verticalPower = rocket.isAi ? -1 : 1;
            float horizontalForce = rocket.transform.position.x - transform.position.x;
            _rig2d.AddForce(new Vector2(horizontalForce, verticalPower).normalized * _speed);
            CameraShake.Instance.PlayShake();

        }
        if (other.gameObject.CompareTag("DeadZoneAI"))
        {
            GameManager.Instance.Score++;
            OnStart();
            _audioPlayer.PlaySound(_scoreSFX);
        }
        if (other.gameObject.CompareTag("DeadZonePlayer"))
        {
            GameManager.Instance.GameOver();
            _rig2d.velocity = Vector2.zero;
            _audioPlayer.PlaySound(_scoreSFX);
        }
    }



}
