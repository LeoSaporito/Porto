using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private GameObject _player;

    [SerializeField] private LineRendererManager _lineRendererManager;
    public void ShootLaser()
    {
        //_lineRendererManager.SpawnLaser();
    }
    //public void ShootLaser()
    //{
    //    GameObject _laserObj = Instantiate(_laserPrefab, _player.transform.position, Quaternion.identity, transform.parent);
    //}
}
