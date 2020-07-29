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
}
