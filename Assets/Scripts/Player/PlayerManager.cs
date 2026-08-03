using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public bool _deleteItem;

    [Header("PlayerMovement")]
    [SerializeField] public PlayerMovement _playerMovement;
    [SerializeField] public Vector2 _directionalInput;

    [Header("PlayerMouse")]
    [SerializeField] public PlayerMouse _playerMouse;

    [Header("PlaceAndDeleteItems")]
    [SerializeField] public PlaceAndDeleteItems _placeAndDeleteItems;

    [Header("PlayerItems")]
    [SerializeField] public PlayerItems _playerItems;
    public void ButtonSelected(string _item, GameObject _objPrefab)
    {
        if(_playerItems.GetValue(_item) <= 0) { return; }
        else
        {
            _playerMouse.InitializeItems(_item);
            _playerMouse._itemSelected = true;

            _placeAndDeleteItems._itemToPlace = _objPrefab;
            _placeAndDeleteItems._itemName = _item;
        }
    }
    public void LeftClicked()
    {
        RaycastHit2D _hit = Physics2D.Raycast(_playerMouse.MousePosition(), Vector2.zero);

        if (_deleteItem == true)
        {
            _placeAndDeleteItems.DeleteItem(_hit);

            _placeAndDeleteItems.ResetSelectedItem();
            _playerMouse.ResetItem();

            _deleteItem = false;
        }
        else
        {
            _placeAndDeleteItems.PlaceItem(_hit);

            _placeAndDeleteItems.ResetSelectedItem();
            _playerMouse.ResetItem();
        }
    }
    public PlayerMouse GetPlayerMouse()
    {
        return _playerMouse;
    }
    public PlaceAndDeleteItems GetPlaceAndDeleteItems()
    {
        return _placeAndDeleteItems;
    }
    public PlayerItems GetPlayerItems()
    {
        return _playerItems;
    }
}
