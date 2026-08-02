using UnityEngine;

public class ItemSelectedButton : MonoBehaviour
{
    [SerializeField] private PlayerMouse _playerMouse;
    [SerializeField] private PlayerManager _playerManager;

    [SerializeField] private GameObject _topLeftToBottomRightPrefab;
    [SerializeField] private GameObject _topRightToBottomLeftPrefab;
    public void TopLeftToBottomRightMirror()
    {
        _playerManager._itemToPlace = _topLeftToBottomRightPrefab;
        _playerMouse._item = "TopLeftToBottomRightMirror";
        _playerMouse._itemSelected = true;
    }
    public void TopRightToBottomLeftMirror()
    {
        _playerManager._itemToPlace = _topRightToBottomLeftPrefab;
        _playerMouse._item = "TopRightToBottomLeftMirror";
        _playerMouse._itemSelected = true;
    }
}
