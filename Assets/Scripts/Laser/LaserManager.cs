using UnityEngine;

public class LaserManager : MonoBehaviour
{
    [SerializeField] private GameObject _lineRendererPrefab;
    [SerializeField] private Transform _playerTransform;
    public void FireLaser()
    {
        SpawnLaser();
    }
    public void SpawnLaser()
    {
        Vector3 _spawnPosition = _playerTransform.position;
        GameObject _lineRendererSpawned = Instantiate(_lineRendererPrefab, _spawnPosition, Quaternion.identity, transform);
    }
}
