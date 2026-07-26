using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _gridPrefab;
    [SerializeField] private GridManager _gridManager;

    [SerializeField] public int _yGridSize;

    [SerializeField] private float xSpacing;
    [SerializeField] private float ySpacing;

    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    public void CreateGrid()
    {
        for (int x = 0; x < _gridManager._xGridSize; x++)
        {
            for (int y = 1; y < _yGridSize; y++)
            {
                GameObject _gridPiece = Instantiate(_gridPrefab, new Vector2(x, y), Quaternion.identity, transform);
                GridSquare _gridSquare = _gridPiece.GetComponent<GridSquare>();

                _gridSquare.SetXPosition(x);
                _gridSquare.SetYPosition(y);

                _gridSquare.SetSpacing(xSpacing, ySpacing, xOffset, yOffset);
            }
        }
    }
    //public void CreatePlayerGridPositions(int y)
    //{
    //    for (int x = 0; x < _gridManager._xGridSize; x++)
    //    {
    //        GameObject _gridPiece = Instantiate(_gridPrefab, new Vector2(x, y), Quaternion.identity, transform);

    //        GridSquare _gridSquare = _gridPiece.GetComponent<GridSquare>();

    //        _gridSquare.SetXPosition(x);
    //        _gridSquare.SetYPosition(y);

    //        _gridSquare.SetSpacing(xSpacing, 1f, xOffset, 0f);
    //    }
    //}
}
