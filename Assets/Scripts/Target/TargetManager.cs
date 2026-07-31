using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [Header("Hitmarker")]
    [SerializeField] private GameObject _hitMarkerPrefab;

    public void TargetHit(CollisionManager _collisionManager)
    {
        TargetCollision _targetCollision = GetComponent<TargetCollision>();
        
        _targetCollision.InitalizeCollisionManager(_collisionManager);
        _targetCollision.Target();
    }
    public void SpawnHitmarker(Vector2 _spawnPosition)
    {
        GameObject _hitmarker = Instantiate(_hitMarkerPrefab, _spawnPosition, Quaternion.identity);
    }
}
