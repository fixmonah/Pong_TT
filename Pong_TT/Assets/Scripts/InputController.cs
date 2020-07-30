using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameController.instance.GetGameField().RestartBall();
            GameController.instance.GetGameField().GetAim().PrepareToFire();
        }

        if (Input.GetMouseButtonUp(0))
        {
            GameController.instance.GetGameField().GetAim().Fire();
        }
    }
}
