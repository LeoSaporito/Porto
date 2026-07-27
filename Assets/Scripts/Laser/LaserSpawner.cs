using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _laserPrefab;
    public void ShootLaser()
    {
        GameObject _laserObj = Instantiate(_laserPrefab, transform.position, Quaternion.identity, transform.parent);
    }
}
