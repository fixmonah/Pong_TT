using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{

    [SerializeField] private GameObject _target1,_target2,_target3;
    [SerializeField] private Transform _enemyDefaultPoint;
    [SerializeField] private Transform _ballDefaultPoint;
    [SerializeField] private Transform _AimDefaultPoint;
    [SerializeField] private Aim _aim;
    [SerializeField] private Ball _ball;
    [SerializeField] private Enemy _enemy;

    #region MyRegion

    public Aim GetAim()
    {
        return _aim;
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
}
