using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveToTarget(Transform target, float speed)
    {
        Vector3 force = target.transform.position - transform.position;
        force *= GameController.instance.GetBallSpeedFactor();
        force *= speed;
        _rigidbody.AddForce(force);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        // collision with "Target"
        Target hitTarget = other.gameObject.GetComponent<Target>();
        if (hitTarget != null)
        {
            _rigidbody.isKinematic = true;
            _rigidbody.isKinematic = false;
            gameObject.SetActive(false);
        }
        
        // collision with "Enemy"
        Enemy hitEnemy = other.gameObject.GetComponent<Enemy>();
        if (hitEnemy != null)
        {
            _rigidbody.isKinematic = true;
            _rigidbody.isKinematic = false;
            gameObject.SetActive(false);
        }
    }
}
