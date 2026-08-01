using UnityEngine;

public class PointsCollision : MonoBehaviour
{
    [SerializeField] private CollisionManager _collisionManager;
    [Header("Hitmarker")]
    [SerializeField] private GameObject _hitMarkerPrefab;
    public void Collide()
    {
        /*debug
        print(_targetCenter);
        print(_frontPointPosition);
        print(_rearPointPosition);*/
        FrontPointCheck();
        RearPointCheck();
    }
    private void FrontPointCheck()
    {
        if (_collisionManager.GetPointsData()._pointIndex == "front")
        {
            _collisionManager.GetPointsMovement().StopPoint();
            SpawnHitmarker(this.transform.position);
            print("Stop");
        }
    }
    private void RearPointCheck()
    {
        if (_collisionManager.GetPointsData()._pointIndex == "rear")
        {
            _collisionManager.GetPointsSpawner().DestroyLineRenderer();
            print("Destroy");
        }
    }
    public void SpawnHitmarker(Vector2 _spawnPosition)
    {
        GameObject _hitmarker = Instantiate(_hitMarkerPrefab, _spawnPosition, Quaternion.identity);
    }
}