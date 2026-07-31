using UnityEngine;

public class PointsCollision : MonoBehaviour
{
    [SerializeField] private PointsSpawner _pointsSpawner;
    [SerializeField] private Vector2 _frontPointOfContact;

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
            MirrorCollision(_hitObj);
        }
        else if (_hitObj.CompareTag("Target"))
        {
            TargetCollision(_hitObj);
        }
    }
    private void MirrorCollision(GameObject _hitObj)
    {
        MirrorData _mirrorCollision = _hitObj.GetComponent<MirrorData>();

        _pointsDirection.ChangeDirection(_mirrorCollision.GetAngleType());

        if (_pointsData._pointIndex == "front")
        {
            _pointsSpawner.SpawnNewPoint(this.transform.position);
        }
        else if (_pointsData._pointIndex == "rear")
        {
            _pointsSpawner.DestroyVertex();
        }
    }
    private void TargetCollision(GameObject _hitObj)
    {
        TargetCollision _targetCollision = _hitObj.GetComponent<TargetCollision>();

        if (_pointsData._pointIndex == "front")
        {
            _pointsMovement.StopPoint();
        }
        else if (_pointsData._pointIndex == "rear")
        {
            _pointsSpawner.DestroyAllPoints();
        }
    }
}