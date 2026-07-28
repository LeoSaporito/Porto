using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class LaserLineRenderer : MonoBehaviour
{
    //[SerializeField] private List<Transform> _pointsTransform = new List<Transform>();

    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private PlayerMovement _playerMovement;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        _lineRenderer.positionCount = 2;

        Vector3 _frontOfLaser = _lineRenderer.GetPosition(0);
        Vector3 _backOfLaser = _lineRenderer.GetPosition(1);
        Vector3 _playerPosition = _playerMovement.transform.position;

        _frontOfLaser.x = _playerPosition.x;
        _frontOfLaser.y = _playerPosition.y;

        _backOfLaser.x = _playerPosition.x;
        _backOfLaser.y = _playerPosition.y;
    }
}
