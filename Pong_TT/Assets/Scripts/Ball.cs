using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float _velocity;
    [SerializeField] private Transform _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player);
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 force = _player.transform.position - transform.position;
            force *= 10;
            _rigidbody.AddForce(force);
            
            //_rigidbody.AddForceAtPosition(Vector3.forward, _player.transform.position,ForceMode.Impulse);
            //_rigidbody.AddForce(1000,0,1000);
            
            //direction = _player.transform.position;
            //direction *= -100;
            //_rigidbody.AddForceAtPosition(direction, _player.transform.position);
            
            
        }

        _velocity = _rigidbody.velocity.magnitude;
    }
}
