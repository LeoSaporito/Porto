using UnityEngine;
using static UnityEditor.Progress;

public class ItemSelectedButton : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;

    [SerializeField] private GameObject _topLeftToBottomRightPrefab;
    [SerializeField] private GameObject _topRightToBottomLeftPrefab;
    public void TopLeftToBottomRightMirror()
    {
        _playerManager.ButtonSelected("TopLeftToBottomRightMirror", _topLeftToBottomRightPrefab);
    }
    public void TopRightToBottomLeftMirror()
    {
        _playerManager.ButtonSelected("TopRightToBottomLeftMirror", _topRightToBottomLeftPrefab);
    }
    public void Delete()
    {
        _playerManager.ButtonSelected(null, null);
        _playerManager._deleteItem = true;
    }
}
