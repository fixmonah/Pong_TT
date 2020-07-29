using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision other)
    {
        Ball hitObject = other.gameObject.GetComponent<Ball>();
        if (hitObject != null)
        {
            GameController.instance.EnemyHitBall();
        }
    }
}
