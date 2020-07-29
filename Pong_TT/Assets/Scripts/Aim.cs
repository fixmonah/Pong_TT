using System;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private GameObject _arrow;

    private Camera _camera;
    private bool _moveFlag;
    private RaycastHit _raycastHit;
    private float _distanceToBall;
    private float _maxDistanceFromAimToTarget;
    private Vector3 _scaleBefore;
    
    public void PrepareToFire()
    {
        _camera = GameController.instance.GetCamera();
        _maxDistanceFromAimToTarget = GameController.instance.GetMaxDistanceFromAimToTarget();
        _scaleBefore = transform.localScale;
        _moveFlag = true;
    }

    public void Fire()
    {
        _moveFlag = false;
        _ball.MoveToTarget(transform, _distanceToBall);
        gameObject.SetActive(false);
    }

    private void MoveToNewPoint()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Vector3 newPoint = _raycastHit.point;
        
        if (Physics.Raycast(ray, out _raycastHit)) {
            newPoint.y = transform.position.y;
        }

        _distanceToBall = Vector3.Distance(_ball.transform.position, newPoint);
        
        if (_distanceToBall < _maxDistanceFromAimToTarget)
        {
            transform.position = newPoint;
            _arrow.transform.localScale = _scaleBefore * _distanceToBall * 0.2f;
        }
    }

    private void Update()
    {
        _arrow.transform.LookAt(_ball.transform);
        
        if (_moveFlag)
        {
            MoveToNewPoint();
        }
    }
}