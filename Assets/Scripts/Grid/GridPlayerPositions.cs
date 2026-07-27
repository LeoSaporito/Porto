using System.Collections.Generic;
using UnityEngine;

public class GridPlayerPositions : MonoBehaviour
{
    [SerializeField] private GameObject _gridPrefab;
    [SerializeField] private GridManager _gridManager;

    [SerializeField] private int _playerGridPosition;
    [SerializeField] private float xSpacing;
    [SerializeField] private float xOffset;

    public List<GameObject> _playerGridCells = new List<GameObject>();

    public void CreatePlayerGrid()
    {
        for (int x = 0; x < _gridManager._xGridSize; x++)
        {
            GameObject _gridPiece = Instantiate(_gridPrefab, new Vector3(x, _playerGridPosition, 1), Quaternion.identity, transform);

            GridSquare _gridSquare = _gridPiece.GetComponent<GridSquare>();

            _gridSquare.SetXPosition(x);
            _gridSquare.SetYPosition(0);

            _gridSquare.SetPlayerGridSpacing(xSpacing, xOffset, _playerGridPosition);

            _playerGridCells.Add(_gridPiece);
        }
    }
}
