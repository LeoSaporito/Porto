using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GridSpawner _gridSpawner;
    [SerializeField] private GridPlayerPositions _gridPlayerPositions;

    [SerializeField] public int _xGridSize;

    private void Start()
    {
        _gridSpawner.CreateGrid();
        _gridPlayerPositions.CreatePlayerGrid();
    }
}
