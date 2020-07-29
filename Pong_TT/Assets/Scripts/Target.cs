using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Ball hitObject = other.gameObject.GetComponent<Ball>();
        if (hitObject != null)
        {
            GameController.instance.GetGameField().TargetGetHit();
            gameObject.SetActive(false);
        }
    }
}