using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class LineRendererManager : MonoBehaviour
{
    [SerializeField] private GameObject _lineRendererPrefab;
    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField] public Vector3 _spawnPosition;
    [SerializeField] public float _topPoint;
    [SerializeField] public float _bottomPoint;

    [SerializeField] private Transform _pointsPrefab;
    [SerializeField] public List<Transform> _pointsList = new List<Transform>();
    [SerializeField] private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void SpawnLaser()
    {
        _pointsList.Add(_pointsPrefab);
    }
    private void PointsSpawnPosition(Vector3 _playerPosition, LineRenderer _lineRenderer)
    {
        _spawnPosition = _playerPosition;
        _lineRenderer.positionCount = 2;

        _lineRenderer.SetPosition(0, new Vector3(_spawnPosition.x, _spawnPosition.y + _topPoint, _spawnPosition.z));
        _lineRenderer.SetPosition(1, new Vector3(_spawnPosition.x, _spawnPosition.y + _bottomPoint, _spawnPosition.z));
    }
    private void Update()
    {
        _lineRenderer.positionCount = _pointsList.Count;

        for (int i = 0; i < _pointsList.Count; i++)
        {
            _lineRenderer.SetPosition(i, _pointsList[i].position);
        }
    }
}
