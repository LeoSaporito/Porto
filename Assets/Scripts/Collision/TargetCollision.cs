using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    [SerializeField] private CollisionManager _collisionManager;
    [SerializeField] private PointsMovement _pointsMovement;
    public void TargetCollider(GameObject _hitObj)
    {
        Vector2 _targetCenter = _hitObj.GetComponent<SpriteRenderer>().bounds.center;

        Vector2 _direction = _pointsMovement.GetDirection();

        if (_direction.x != 0)
        {
            HorizontalCollision();
        }
        else if (_direction.y != 0)
        {
            VerticalCollision();
        }
    }
    public void HorizontalCollision()
    {

    }
    public void VerticalCollision()
    {

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
