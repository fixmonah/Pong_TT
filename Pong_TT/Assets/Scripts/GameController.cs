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
    [Header("Link")] 
    [SerializeField] private GameField _gameField;
    [SerializeField] private Camera _camera;


    #region Getter/Setter

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

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _gameField.GetAim().PrepareToFire();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _gameField.GetAim().Fire();
        }
    }


}
