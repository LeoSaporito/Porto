using System.Collections.Generic;
using UnityEngine;

public class MirrorCollision : MonoBehaviour
{
    [SerializeField] private CollisionManager _collisionManager;
    public void MirrorCollider(GameObject _hitObj)
    {
        MirrorData _mirrorData = _hitObj.GetComponent<MirrorData>();

        _collisionManager.GetPointsDirection().ChangeDirection(_mirrorData.GetAngleType());

        if (_collisionManager.GetPointsData()._pointIndex == "front")
        {
            _collisionManager.GetPointsSpawner().SpawnNewPoint(this.transform.position);
        }
        else if (_collisionManager.GetPointsData()._pointIndex == "rear")
        {
            _collisionManager.GetPointsSpawner().DestroyVertex();
        }
    }
}
