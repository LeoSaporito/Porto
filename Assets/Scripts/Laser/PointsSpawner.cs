using System.Collections.Generic;
using UnityEngine;

public class PointsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pointsPrefab;    
    [SerializeField] private LineRendererManager _lineRendererManager;

    [SerializeField] private LaserManager _laserManager;

    public void InitalizeLaserManager(LaserManager _laserManagerScript)
    {
        _laserManager = _laserManagerScript;
    }
    public void SpawnPoint(float _delay, string _pointIndex, Vector3 _spawnPoint)
    {
        GameObject _pointSpawned = Instantiate(_pointsPrefab, _spawnPoint, Quaternion.identity, transform);

        GetPointsList().Add(_pointSpawned);

        PointsMovement _pointMovement = _pointSpawned.GetComponent<PointsMovement>();
        _pointMovement.DelayPoint(_delay);

        PointsData _pointData = _pointSpawned.GetComponent<PointsData>();
        _pointData._pointIndex = _pointIndex;

        CollisionManager _collisionManager = _pointSpawned.GetComponent<CollisionManager>();
        _collisionManager.InitalizePointsSpawner(this);
    }
    public void SpawnNewPoint(Vector3 _spawnPoint)
    {
        GameObject _pointSpawned = Instantiate(_pointsPrefab, _spawnPoint, Quaternion.identity, transform);

        GetPointsList().Insert(1, _pointSpawned);

        PointsMovement _pointMovement = _pointSpawned.GetComponent<PointsMovement>();
        _pointMovement.StopPoint();

        PointsData _pointData = _pointSpawned.GetComponent<PointsData>();
        _pointData._pointIndex = "middle";
    }
    public void DestroyPoint(GameObject _obj)
    {
        GetPointsList().Remove(_obj);
        Destroy(_obj);
    }
    public void DestroyVertex()
    {
        GameObject _vertex = GetPointsList()[GetPointsList().Count - 2];
        DestroyPoint(_vertex);
    }
    public void DestroyAllPoints()
    {
        for (int i = GetPointsList().Count - 1; i >= 0; i--)
        {
            DestroyPoint(GetPointsList()[i]);
        }
    }
    public void DestroyLineRenderer()
    {
        _lineRendererManager.DestroyLineRenderer();
    }
    public void ResetMirrors()
    {
        _laserManager.ResetMirrors();
    }
    private List<GameObject> GetPointsList()
    {
        return _lineRendererManager._pointsList;
    }
}
