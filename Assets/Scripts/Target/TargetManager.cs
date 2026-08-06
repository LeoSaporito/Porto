using System;
using UnityEngine;

using UnityEngine.SceneManagement;
public class TargetManager : MonoBehaviour
{
    [SerializeField] private CollisionManager _collisionManager;
    [SerializeField] private float _tolerance;
    public void InitalizeCollisionManager(CollisionManager _collisionManagerScript)
    {
        _collisionManager = _collisionManagerScript;
    }
    public void TargetHit()
    {
        TargetDirectionCheck();
    }
    private void TargetDirectionCheck()
    {
        PointsMovement _pointsMovement = _collisionManager.GetPointsMovement();

        Vector2 _direction = _pointsMovement.GetDirection();
        
        if (_direction.x != 0)
        {
            VerticalTarget(_direction.x);
        }
        else if (_direction.y != 0)
        {
            HorizontalTarget(_direction.y);
        }
    }
    private void HorizontalTarget(float _yDirection)
    {
        Vector2 _frontPoint = GetFrontPoint();
        Vector2 _rearPoint = GetRearPoint();

        float _yCenter = GetComponent<SpriteRenderer>().bounds.center.y;

        /*//debug
        print("y Center: " + _yCenter);
        print("front:" + _frontPoint);
        print("rear:" + _rearPoint);*/

        if (_frontPoint.y < _yCenter + _tolerance && _frontPoint.y > _yCenter - _tolerance)
        {
            _collisionManager.GetComponent<PointsCollision>().Collide();
            
            //<--------------------------------->//
            //Main menu stuff
            UnlockedNewLevel();
        }
    }
    private void VerticalTarget(float _xDirection)
    {
        Vector2 _frontPoint = GetFrontPoint();
        Vector2 _rearPoint = GetRearPoint();

        float _xCenter = GetComponent<SpriteRenderer>().bounds.center.x;

        /*//debug
        print("y Center: " + _yCenter);
        print("front:" + _frontPoint);
        print("rear:" + _rearPoint);*/

        if (_frontPoint.x < _xCenter + _tolerance && _frontPoint.x > _xCenter - _tolerance)
        {
            _collisionManager.GetComponent<PointsCollision>().Collide();

            //<--------------------------------->//
            //Main menu stuff
            UnlockedNewLevel();
        }
    }
    private Vector2 GetFrontPoint()
    {
        PointsSpawner _pointsSpawner = _collisionManager.GetPointsSpawner();
        LineRenderer _lineRenderer = _pointsSpawner.GetComponent<LineRenderer>();

        Vector2 _frontPointPosition = _lineRenderer.GetPosition(0);

        return _frontPointPosition;
    }
    private Vector2 GetRearPoint()
    {
        PointsSpawner _pointsSpawner = _collisionManager.GetPointsSpawner();
        LineRenderer _lineRenderer = _pointsSpawner.GetComponent<LineRenderer>();

        Vector2 _rearPointPosition = _lineRenderer.GetPosition(_lineRenderer.positionCount - 1);

        return _rearPointPosition;
    }

    //<------------------------------------------------------------------------------------------>//

    public void UnlockedNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();

        }
    }
}
