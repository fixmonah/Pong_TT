using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GameField : MonoBehaviour
{

    [SerializeField] private GameObject _target1,_target2,_target3;
    [SerializeField] private Transform _enemyDefaultPoint;
    [SerializeField] private Transform _ballDefaultPoint;
    [SerializeField] private Transform _AimDefaultPoint;
    [SerializeField] private Aim _aim;
    [SerializeField] private Ball _ball;
    [SerializeField] private Enemy _enemy;

    private int targetCount = 3;
    private int targetCountDefault = 3;
    
    #region MyRegion

    public Aim GetAim()
    {
        return _aim;
    }
    public Ball GetBall()
    {
        return _ball;
    }

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TargetGetHit()
    {
        targetCount--;
        CheckTarget();
    }

    public void CheckTarget()
    {
        if (targetCount <= 0)
        {
            GameController.instance.AllTargetDown();
        }
        else
        {
            RestartBall();
        }
    }

    public void RestartBall()
    {
        _ball.GetComponent<Rigidbody>().isKinematic = true;
        _ball.transform.position = _ballDefaultPoint.position;
        _ball.GetComponent<Rigidbody>().isKinematic = false;
        _ball.gameObject.SetActive(true);
        RestartAim();
    }

    private void RestartAim()
    {
        _aim.transform.position = _AimDefaultPoint.position;
        _aim.gameObject.SetActive(true);
    }

    public void RestartEnemy()
    {
        _enemy.ResetPosition(_enemyDefaultPoint.position);
    }

    public void RestartTarget()
    {
        _target1.SetActive(true);
        _target2.SetActive(true);
        _target3.SetActive(true);

        targetCount = targetCountDefault;
    }

    public void RestartGameField()
    {
        RestartTarget();
        RestartBall();
        RestartEnemy();
    }
}
