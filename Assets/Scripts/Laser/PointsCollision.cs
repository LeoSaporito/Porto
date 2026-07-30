using UnityEngine;

public class PointsCollision : MonoBehaviour
{
    [SerializeField] private PointsSpawner _pointsSpawner;
    [SerializeField] private Vector2 _frontPointOfContact;
    public void InitalizePointsSpawner(PointsSpawner _pointsSpawnerVar)
    {
        _pointsSpawner = _pointsSpawnerVar;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mirror"))
        {
            GameObject _hitObj = collision.gameObject;
            MirrorCollision _mirrorCollision = _hitObj.GetComponent<MirrorCollision>();

            PointsDirection _pointsDirection = GetComponent<PointsDirection>();
            _pointsDirection.ChangeDirection(_mirrorCollision.GetAngleType());

            PointsData _pointsData = GetComponent<PointsData>();
            if (_pointsData._pointIndex == "front")
            {
                _pointsSpawner.SpawnNewPoint(this.transform.position);
            }
            else if (_pointsData._pointIndex == "rear")
            {
                _pointsSpawner.DestroyVertex();
            }
        }
    }
}