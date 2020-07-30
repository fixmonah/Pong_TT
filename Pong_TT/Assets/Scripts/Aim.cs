using System;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private GameObject _arrow;
    [SerializeField] private GameObject _sprite;

    private Camera _camera;
    private bool _moveFlag;
    private RaycastHit _raycastHit;
    private float _distanceToBall;
    private float _maxDistanceFromAimToBall;
    private Vector3 _arrowLocaleScaleAtStart;
    private Vector3 _positionBeforeFire;

    private void Start()
    {
        _distanceToBall = Vector3.Distance(_ball.transform.position, transform.position);
        _arrowLocaleScaleAtStart = transform.localScale;
        _sprite.transform.localScale = _arrowLocaleScaleAtStart * _distanceToBall * 0.2f;
    }

    public void PrepareToFire()
    {
        _camera = GameController.instance.GetCamera();
        _maxDistanceFromAimToBall = GameController.instance.GetMaxDistanceFromAimToTarget();
        _positionBeforeFire = transform.position;
        _moveFlag = true;
    }

    public void Fire()
    {
        if (_positionBeforeFire != transform.position)
        {
            _moveFlag = false;
            _ball.MoveToTarget(transform, _distanceToBall);
            gameObject.SetActive(false);
        }
        else
        {
            _moveFlag = false;
        }
    }

    private void MoveToNewPoint()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Vector3 newPoint = _raycastHit.point;
        
        if (Physics.Raycast(ray, out _raycastHit)) {
            newPoint.y = transform.position.y;
        }

        _distanceToBall = Vector3.Distance(_ball.transform.position, newPoint);
        
        if (_distanceToBall < _maxDistanceFromAimToBall)
        {
            transform.position = newPoint;
            _sprite.transform.localScale = _arrowLocaleScaleAtStart * _distanceToBall * 0.2f;
        }
    }

    private void Update()
    {
        Vector3 rotation = _arrow.transform.localPosition;
        rotation.x = 0;
        _arrow.transform.localPosition = rotation;
        _arrow.transform.LookAt(_ball.transform);
        
        if (_moveFlag)
        {
            MoveToNewPoint();
        }
    }
}