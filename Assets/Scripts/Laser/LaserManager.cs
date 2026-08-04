using UnityEngine;

public class LaserManager : MonoBehaviour
{
    [SerializeField] private GameObject _lineRendererPrefab;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _laserSpawned;

    [SerializeField] private MirrorManager _mirrorManager;

    public void FireLaser()
    {
        SpawnLaser();
    }
    public void SpawnLaser()
    {
        Vector3 _spawnPosition = _playerTransform.position;
        _laserSpawned = Instantiate(_lineRendererPrefab, _spawnPosition, Quaternion.identity, transform);

        _laserSpawned.GetComponent<PointsSpawner>().InitalizeLaserManager(this);
    }
    public void ResetMirrors()
    {
        _mirrorManager.ResetMirrorColor();
    }
}
