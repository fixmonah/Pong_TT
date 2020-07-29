using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _defaultPosition;
    private Ball _ball;
    private bool _resetPosition;
    private Vector3 _newPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        _defaultPosition = transform.position;
        _ball = GameController.instance.GetGameField().GetBall();
    }

    private void OnCollisionEnter(Collision other)
    {
        Ball hitObject = other.gameObject.GetComponent<Ball>();
        if (hitObject != null)
        {
            GameController.instance.EnemyHitBall();
        }
    }

    public void ResetPosition(Vector3 position)
    {
        _newPosition = position;
        _resetPosition = true;
    }

    void Update()
    {
        FollowBall();
    }

    private void FollowBall()
    {
        if (_resetPosition)
        {
            transform.position = _newPosition;
            _resetPosition = false;
        }
        else
        {
            float speed = GameController.instance.GetEnemySpeed();
            _newPosition = Vector3.Lerp(transform.position, _ball.transform.position, speed);
            _newPosition.y = _defaultPosition.y;
            _newPosition.z = _defaultPosition.z;
            transform.position = _newPosition;
        }
    }
}
