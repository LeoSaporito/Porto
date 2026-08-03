using UnityEngine;
using static UnityEditor.Progress;

public class PlaceAndDeleteItems : MonoBehaviour
{
    [SerializeField] public GameObject _itemToPlace;
    [SerializeField] public string _itemName;
     
    [SerializeField] public PlayerItems _playerItems;

    [Header("UIManager")]
    [SerializeField] public UIManager _uiManager;
    public void PlaceItem(RaycastHit2D _hit)
    {
        if (_itemToPlace == null) { return; }
        else
        {
            if (_hit.collider != null)
            {
                GameObject _hitObj = _hit.collider.gameObject;

                if (_hitObj.CompareTag("Grid Square"))
                {
                    GridSquare _gridSquare = _hitObj.GetComponent<GridSquare>();

                    if (_gridSquare._itemPlaced != null) { return; }
                    else if (_gridSquare._itemPlaced == null) { Item(_hitObj); }
                }
            }
        }
    }
    public void DeleteItem(RaycastHit2D _hit)
    {
        if (_hit.collider == null) { return; }
        else if (_hit.collider != null)
        {
            GameObject _hitObj = _hit.collider.gameObject;

            if (_hitObj.CompareTag("Grid Square"))
            {
                GridSquare _gridSquare = _hitObj.GetComponent<GridSquare>();

                if (_gridSquare._itemPlaced != null)
                {
                    _itemName = _gridSquare._itemName;

                    _playerItems.Add(_itemName);
                    
                    _gridSquare.DeleteItem();

                    _uiManager.ChangeItemsValue(_itemName, _playerItems.GetValue(_itemName));
                }
            }
        }
    }
    private void Item(GameObject _hitObj)
    {
        GameObject _obj = Instantiate(_itemToPlace, _hitObj.transform.position, Quaternion.identity);

        GridSquare _gridSquare = _hitObj.GetComponent<GridSquare>();

        _gridSquare.PlacedItem(_obj, _itemName);

        _playerItems.Subtract(_itemName);

        _uiManager.ChangeItemsValue(_itemName, _playerItems.GetValue(_itemName));
    }
    public void ResetSelectedItem()
    {
        _itemName = null;
        _itemToPlace = null;
    }
}
