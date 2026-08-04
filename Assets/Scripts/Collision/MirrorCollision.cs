using System.Collections.Generic;
using UnityEngine;

public class MirrorCollision : MonoBehaviour
{
    [SerializeField] private CollisionManager _collisionManager;
    [SerializeField] private bool _isGreen;
    public void InitalizeCollisionManager(CollisionManager _collisionManagerScript)
    {
        _collisionManager = _collisionManagerScript;
    }
    public void MirrorHit(CollisionManager _collisionManagerScript)
    {
        InitalizeCollisionManager(_collisionManagerScript);
        MirrorRicochet();
    }
    public void MirrorRicochet()
    {
        MirrorData _mirrorData = GetComponent<MirrorData>();

        _collisionManager.GetPointsDirection().ChangeDirection(_mirrorData.GetAngleType());

        if (_collisionManager.GetPointsData()._pointIndex == "front")
        {
            FlipColor();
            _collisionManager.GetPointsSpawner().SpawnNewPoint(_collisionManager.transform.position);
        }
        else if (_collisionManager.GetPointsData()._pointIndex == "rear")
        {
            _collisionManager.GetPointsSpawner().DestroyVertex();
        }
    }
    public void ResetColor()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
    }
    private void FlipColor()
    {
        _isGreen = !_isGreen;

        if (_isGreen == true)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (_isGreen == false)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
