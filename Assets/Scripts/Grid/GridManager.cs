using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GridSpawner _gridSpawner;
    [SerializeField] public int _xGridSize;
    [SerializeField] public int _yGridSize;

    private void Start()
    {
        _gridSpawner.CreateGrid();
    }

    public void TurnOffGrid()
    {
        for (int i = 0; i < _gridSpawner._gridCells.Count; i++)
        {
            GameObject _gridCellObj = _gridSpawner._gridCells[i];
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
    }
}
