using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [HideInInspector] [SerializeField] private Vector2 _frontPointOfContact;
    
    [Header("Scripts")]
    [Header("Hierarchy")]
    [SerializeField] private PointsSpawner _pointsSpawner;

    [Header("Data")]
    [SerializeField] private PointsDirection _pointsDirection;
    [SerializeField] private PointsMovement _pointsMovement;
    [SerializeField] private PointsData _pointsData;

    [Header("Collisions")]
    [SerializeField] private MirrorCollision _mirrorCollision;
    [SerializeField] private TargetCollision _targetCollision;
    public void InitalizePointsSpawner(PointsSpawner _pointsSpawnerVar)
    {
        _pointsSpawner = _pointsSpawnerVar;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject _hitObj = collision.gameObject;

        if (_hitObj.CompareTag("Mirror"))
        {
            _mirrorCollision.MirrorCollider(_hitObj);
        }
        else if (_hitObj.CompareTag("Target"))
        {
            _targetCollision.TargetCollider(_hitObj);
        }
    }
    public PointsSpawner GetPointsSpawner()
    {
        return _pointsSpawner;
    }
    public PointsDirection GetPointsDirection()
    {
        return _pointsDirection;
    }
    public PointsMovement GetPointsMovement()
    {
        return _pointsMovement;
    }
    public PointsData GetPointsData()
    {
        return _pointsData;
    }
}
