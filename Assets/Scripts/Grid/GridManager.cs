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

    public void TurnOffGrid()
    {
        for (int i = 0; i < _gridSpawner._gridCells.Count; i++)
        {
            GameObject _gridCellObj = _gridSpawner._gridCells[i];
            CanBeClicked _canBeClicked = _gridCellObj.GetComponent<CanBeClicked>();

            _canBeClicked.TurnOffIsClickable();
        }
        for (int i = 0; i < _gridPlayerPositions._playerGridCells.Count; i++)
        {
            GameObject _gridCellObj = _gridPlayerPositions._playerGridCells[i];
            CanBeClicked _canBeClicked = _gridCellObj.GetComponent<CanBeClicked>();

            _canBeClicked.TurnOffIsClickable();
        }
    }
    public void TurnOnGrid()
    {
        for (int i = 0; i < _gridSpawner._gridCells.Count; i++)
        {
            GameObject _gridCellObj = _gridSpawner._gridCells[i];
            CanBeClicked _canBeClicked = _gridCellObj.GetComponent<CanBeClicked>();

            _canBeClicked.TurnOnIsClickable();
        }

        for (int i = 0; i < _gridPlayerPositions._playerGridCells.Count; i++)
        {
            GameObject _gridCellObj = _gridPlayerPositions._playerGridCells[i];
            CanBeClicked _canBeClicked = _gridCellObj.GetComponent<CanBeClicked>();

            _canBeClicked.TurnOnIsClickable();
        }
    }
}
