using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region SingleTone

    public static GameController instance = null;

    void Awake () {
        if (instance == null) {
            instance = this;
        } else if(instance == this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    #endregion

    [Header("Game Settings")] 
    [SerializeField] private float _ballSpeedFactor;
    [SerializeField] private float _maxDistanceFromAimToTarget;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _enemySpeedMinimum;
    [SerializeField] private float _enemySpeedFactor;
    [Header("Link")] 
    [SerializeField] private GameField _gameField;
    [SerializeField] private Camera _camera;
    [Header("Info")] 
    [SerializeField] private int _level;

    #region Getter/Setter

    public int GetLevel()
    {
        return _level;
    }
    public float GetEnemySpeed()
    {
        return _enemySpeed;
    }
    public float GetEnemySpeedMinimum()
    {
        return _enemySpeedMinimum;
    }
    public float GetEnemySpeedFactor()
    {
        return _enemySpeedFactor;
    }
    public float GetMaxDistanceFromAimToTarget()
    {
        return _maxDistanceFromAimToTarget;
    }
    public GameField GetGameField()
    {
        return _gameField;
    }
    public float GetBallSpeedFactor ()
    {
        return _ballSpeedFactor;
    }
    public Camera GetCamera()
    {
        return _camera;
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EnemyHitBall()
    {
        _gameField.RestartBall();
    }

    public void AllTargetDown()
    {
        _level++;
        _enemySpeed += _enemySpeedFactor;
        StartCoroutine(RestartGameField());
    }

    IEnumerator RestartGameField()
    {
        //yield return new WaitForSeconds(1f);
        yield return new WaitForEndOfFrame();
        _gameField.RestartGameField();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _gameField.RestartBall();
            _gameField.GetAim().PrepareToFire();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _gameField.GetAim().Fire();
        }
    }
}
