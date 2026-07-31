using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    [SerializeField] private CollisionManager _collisionManager;
    [SerializeField] private TargetManager _targetManager;

    public void InitalizeCollisionManager(CollisionManager _collisionManagerScript)
    {
        _collisionManager = _collisionManagerScript;
    }
    public void Target()
    {
        Vector2 _targetCenter = GetComponent<SpriteRenderer>().bounds.center;
        
        Vector2 _direction = _collisionManager.GetPointsMovement().GetDirection();

        if (_direction.x != 0)
        {
            HorizontalCollision(_direction.x, "Horizontal");
        }
        else if (_direction.y != 0)
        {
            VerticalCollision(_direction.y, "Vertical");
        }
    }
    public void HorizontalCollision(float _direction, string _movementAxis)
    {
        //Get center of the targets position
        Vector2 _targetCenter = GetComponent<CircleCollider2D>().bounds.center;

        //Get the front and rear points positions from the line renderer
        PointsSpawner _pointsSpawner = _collisionManager.GetPointsSpawner();
        LineRenderer _lineRenderer = _pointsSpawner.GetComponent<LineRenderer>();

        Vector2 _frontPointPosition = _lineRenderer.GetPosition(0);
        Vector2 _rearPointPosition = _lineRenderer.GetPosition(_lineRenderer.positionCount - 1);

        //debug
        print(_targetCenter);
        print(_frontPointPosition);
        print(_rearPointPosition);

        //if the point is halfway between the bottom and top of the target (center line from top to bottom)
        //collide with the target            

        //when front point collides, stop point movement
        //^^^
        // --> if the y position of the laser is either the same, or greater than the y position of the target
        // (input logic)
        // --> else if the y position of the laser is either the same or less than the y position of the target
        // (input logic)
        FrontPointCheck(_frontPointPosition.x, _targetCenter.x, _direction);

        // --> when rear point collides, destroy the laser && spawn a hitmarker
        //^^^
        // --> if the y position of the laser is either the same, or greater than the y position of the target
        // (input logic)
        // --> else if the y position of the laser is either the same or less than the y position of the target
        // (input logic)
        RearPointCheck(_frontPointPosition.x, _targetCenter.x, _direction, _movementAxis);
    }
    public void VerticalCollision(float _direction, string _movementAxis)
    {
        //Get center of the targets position
        Vector2 _targetCenter = GetComponent<CircleCollider2D>().bounds.center;

        //Get the front and rear points positions from the line renderer
        PointsSpawner _pointsSpawner = _collisionManager.GetPointsSpawner();
        LineRenderer _lineRenderer = _pointsSpawner.GetComponent<LineRenderer>();

        Vector2 _frontPointPosition = _lineRenderer.GetPosition(0);
        Vector2 _rearPointPosition = _lineRenderer.GetPosition(_lineRenderer.positionCount - 1);

        //debug
        print(_targetCenter);
        print(_frontPointPosition);
        print(_rearPointPosition);

        //if the point is halfway between the bottom and top of the target (center line from top to bottom)
        //collide with the target            

        //when front point collides, stop point movement
        //^^^
        // --> if the y position of the laser is either the same, or greater than the y position of the target
        // (input logic)
        // --> else if the y position of the laser is either the same or less than the y position of the target
        // (input logic)
        FrontPointCheck(_frontPointPosition.y, _targetCenter.y, _direction);

        // --> when rear point collides, destroy the laser && spawn a hitmarker
        //^^^
        // --> if the y position of the laser is either the same, or greater than the y position of the target
        // (input logic)
        // --> else if the y position of the laser is either the same or less than the y position of the target
        // (input logic)
        RearPointCheck(_frontPointPosition.y, _targetCenter.y, _direction, _movementAxis);
    }
    private void FrontPointCheck(float _frontPointPosition, float _targetCenter, float _direction)
    {
        //lasers direction is going up/right
        if (_frontPointPosition >= _targetCenter && _direction > 0)
        {
            _collisionManager.GetPointsMovement().StopPoint();
            print("Stop");
        }
        //lasers direction is going down/left
        else if (_frontPointPosition <= _targetCenter && _direction < 0)
        {
            _collisionManager.GetPointsMovement().StopPoint();
            print("Stop");
        }
    }
    private void RearPointCheck(float _rearPointPosition, float _targetCenter, float _direction, string _movementAxis)
    {
        //lasers direction is going up/right
        if (_rearPointPosition >= _targetCenter && _direction > 0)
        {
            _collisionManager.GetPointsSpawner().DestroyLineRenderer();
            SpawnHitmarker(_movementAxis, _targetCenter);
            print("Destroy");
        }
        //lasers direction is going down/left
        else if (_rearPointPosition <= _targetCenter && _direction < 0)
        {
            _collisionManager.GetPointsSpawner().DestroyLineRenderer();
            SpawnHitmarker(_movementAxis, _targetCenter);
            print("Destroy");
        }
    }
    private void SpawnHitmarker(string _movementAxis, float _targetCenter)
    {
        _targetManager = GetComponent<TargetManager>();

        if (_movementAxis == "Vertical")
        {
            _targetManager.SpawnHitmarker(new Vector2(_collisionManager.transform.position.x, _targetCenter));
        }
        else if (_movementAxis == "Horizontal")
        {
            _targetManager.SpawnHitmarker(new Vector2(_targetCenter, _collisionManager.transform.position.y));
        }
    }
}

//public void TargetCollider(GameObject _hitObj)
//{
//    TargetCollision _targetCollision = _hitObj.GetComponent<TargetCollision>();

//    if (_collisionManager.GetPointsData()._pointIndex == "front")
//    {
//        _collisionManager.GetPointsMovement().StopPoint();
//    }
//    else if (_collisionManager.GetPointsData()._pointIndex == "rear")
//    {
//        _collisionManager.GetPointsSpawner().DestroyLineRenderer();
//    }
//}
