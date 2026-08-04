using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class LineRendererManager : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private PointsSpawner _pointsSpawner;
    [SerializeField] public List<GameObject> _pointsList = new List<GameObject>();


    [SerializeField] private float _frontDelay;
    [SerializeField] private float _rearDelay;

    private void Start()
    {
        Activate();
    }
    private void Activate()
    {
        _pointsSpawner.SpawnPoint(_frontDelay, "front", transform.position);
        _pointsSpawner.SpawnPoint(_rearDelay, "rear", transform.position);
    }
    private void Update()
    {
        _lineRenderer.positionCount = _pointsList.Count;

        for (int i = 0; i < _pointsList.Count; i++)
        {
            _lineRenderer.SetPosition(i, _pointsList[i].transform.position);
        }
    }
    public void DestroyLineRenderer()
    {
        Destroy(gameObject);        
    }
}
