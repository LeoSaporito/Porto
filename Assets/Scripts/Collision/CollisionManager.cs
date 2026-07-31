using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [HideInInspector] [SerializeField] private Vector2 _frontPointOfContact;
    
    [Header("Scripts")]
    [Header("Hierarchy")]
    [SerializeField] private PointsSpawner _pointsSpawner;

    [Header("Points Data")]
    [SerializeField] private PointsDirection _pointsDirection;
    [SerializeField] private PointsMovement _pointsMovement;
    [SerializeField] private PointsData _pointsData; 
    public void InitalizePointsSpawner(PointsSpawner _pointsSpawnerVar)
    {
        _pointsSpawner = _pointsSpawnerVar;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject _hitObj = collision.gameObject;

        if (_hitObj.CompareTag("Mirror"))
        {
            MirrorCollision _mirrorCollision = _hitObj.GetComponent<MirrorCollision>();

            _mirrorCollision.MirrorHit(this);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject _hitObj = collision.gameObject;

        if (_hitObj.CompareTag("Target"))
        {
            TargetManager _targetManager = _hitObj.GetComponent<TargetManager>();

            _targetManager.TargetHit(this);
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
