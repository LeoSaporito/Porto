using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _gridPrefab;
    [SerializeField] private GridManager _gridManager;

    [SerializeField] private float xSpacing;
    [SerializeField] private float ySpacing;

    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;

    public List<GameObject> _gridCells = new List<GameObject>();
    public void CreateGrid()
    {
        int _yGridSize = _gridManager._yGridSize;

        for (int x = 0; x < _gridManager._xGridSize; x++)
        {
            for (int y = 1; y < _yGridSize; y++)
            {
                GameObject _gridPiece = Instantiate(_gridPrefab, new Vector3(x, y, 1), Quaternion.identity, transform);
                GridSquare _gridSquare = _gridPiece.GetComponent<GridSquare>();

                _gridSquare.SetXPosition(x);
                _gridSquare.SetYPosition(y);

                _gridSquare.SetSpacing(xSpacing, ySpacing, xOffset, yOffset);

                _gridCells.Add(_gridPiece);
            }
        }
    }
}
