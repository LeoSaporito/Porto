using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlaceAndDeleteItems : MonoBehaviour
{
    [SerializeField] public GameObject _itemToPlace;
    [SerializeField] public string _itemName;
     
    [SerializeField] public PlayerItems _playerItems;

    [Header("UIManager")]
    [SerializeField] public UIManager _uiManager;

    [Header("MirrorManager")]
    [SerializeField] public GameObject _mirrorManagerObj;
    [SerializeField] public MirrorManager _mirrorManager;
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
                    RemoveFromMirrorsList(_gridSquare._itemPlaced);

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
        GameObject _obj = Instantiate(_itemToPlace, _hitObj.transform.position, Quaternion.identity, _mirrorManagerObj.transform);

        GridSquare _gridSquare = _hitObj.GetComponent<GridSquare>();

        _gridSquare.PlacedItem(_obj, _itemName);

        _playerItems.Subtract(_itemName);

        _uiManager.ChangeItemsValue(_itemName, _playerItems.GetValue(_itemName));

        AddToMirrorsList(_obj);
    }
    public void ResetSelectedItem()
    {
        _itemName = null;
        _itemToPlace = null;
    }
    public void AddToMirrorsList(GameObject _obj)
    {
        if (_obj.CompareTag("Mirror"))
        {
            _mirrorManager._activeMirrors.Add(_obj);
        }
    }
    public void RemoveFromMirrorsList(GameObject _obj)
    {
        if (_obj.CompareTag("Mirror"))
        {
            _mirrorManager._activeMirrors.Remove(_obj);
        }
    }
}
