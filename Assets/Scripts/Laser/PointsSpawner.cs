using System.Collections.Generic;
using UnityEngine;

public class PointsSpawner : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField] public Vector3 _spawnPosition;

    [SerializeField] private GameObject _pointsPrefab;
    [SerializeField] public List<GameObject> _pointsList = new List<GameObject>();
    [SerializeField] private LineRenderer _lineRenderer;

    [SerializeField] private float _frontDelay;
    [SerializeField] private float _rearDelay;
    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    public void SpawnLaser()
    {
        SpawnPoint(_frontDelay, "front");
        SpawnPoint(_rearDelay, "rear");
    }
    public void SpawnPoint(float _delay, string _pointIndex)
    {
        Vector3 _spawnPoint = _playerMovement.transform.position;

        GameObject _pointSpawned = Instantiate(_pointsPrefab, _spawnPoint, Quaternion.identity, transform);
        
        _pointsList.Add(_pointSpawned);

        PointsMovement _pointMovement = _pointSpawned.GetComponent<PointsMovement>();
        _pointMovement.DelayPoint(_delay);

        PointsData _pointData = _pointSpawned.GetComponent<PointsData>();
        _pointData._pointIndex = _pointIndex;

        PointsCollision _pointCollision = _pointSpawned.GetComponent<PointsCollision>();
        _pointCollision.InitalizePointsSpawner(this);
    }
    private void Update()
    {
        _lineRenderer.positionCount = _pointsList.Count;

        for (int i = 0; i < _pointsList.Count; i++)
        {
            _lineRenderer.SetPosition(i, _pointsList[i].transform.position);
        }
    }
    public void SpawnNewPoint(Vector3 _spawnPoint)
    {
        GameObject _pointSpawned = Instantiate(_pointsPrefab, _spawnPoint, Quaternion.identity, transform);

        _pointsList.Insert(1, _pointSpawned);

        PointsMovement _pointMovement = _pointSpawned.GetComponent<PointsMovement>();
        _pointMovement.StopPoint();

        PointsData _pointData = _pointSpawned.GetComponent<PointsData>();
        _pointData._pointIndex = "middle";
    }
    public void DestroyPoint(GameObject _obj)
    {
        _pointsList.Remove(_obj);
        Destroy(_obj);
    }
    public void DestroyVertex()
    {
        GameObject _vertex = _pointsList[_pointsList.Count - 2];
        DestroyPoint(_vertex);
    }
}
