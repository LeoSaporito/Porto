using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class LineRendererManager : MonoBehaviour
{
    [SerializeField] private PointsSpawner _pointsSpawner;
    private void Start()
    {
        _pointsSpawner = GetComponent<PointsSpawner>();
    }
    public void FireLaser()
    {
        _pointsSpawner.SpawnLaser();
    }
}
