using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class LineRendererManager : MonoBehaviour
{
    [SerializeField] private GameObject _lineRendererPrefab;
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
        AddPoint(_frontDelay);
        AddPoint(_rearDelay);
    }
    private void AddPoint(float _delay)
    {
        _spawnPosition = _playerMovement.transform.position;

        GameObject _pointSpawned = Instantiate(_pointsPrefab, new Vector2(_spawnPosition.x, _spawnPosition.y), Quaternion.identity, transform);

        _pointsList.Add(_pointSpawned);
        
        LineRendererMovement _lineRendererMovement = _pointSpawned.GetComponent<LineRendererMovement>();

        _lineRendererMovement.DelayPoint(_delay);        
    }
    private void Update()
    {
        _lineRenderer.positionCount = _pointsList.Count;

        for (int i = 0; i < _pointsList.Count; i++)
        {
            _lineRenderer.SetPosition(i, _pointsList[i].transform.position);
        }
    }
}
