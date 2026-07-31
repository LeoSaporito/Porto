using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class LaserLineRenderer : MonoBehaviour
{
    //[SerializeField] private List<Transform> _pointsTransform = new List<Transform>();

    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] public Vector3 _spawnPosition;
    [SerializeField] public float _topPoint;
    [SerializeField] public float _bottomPoint;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        _lineRenderer.positionCount = 2;

        _lineRenderer.SetPosition(0, new Vector3(_spawnPosition.x, _spawnPosition.y + _topPoint, _spawnPosition.z));
        _lineRenderer.SetPosition(1, new Vector3(_spawnPosition.x, _spawnPosition.y + _bottomPoint, _spawnPosition.z));
    }
}
