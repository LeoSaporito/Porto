using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public GameObject _itemToPlace;
    [SerializeField] public PlayerMouse _playerMouse;

    [SerializeField] private GhostItem _ghostItem;
    public void PlaceItem()
    {
        if (_itemToPlace == null) { return; }
        else
        {
            Vector2 _mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            RaycastHit2D _hit = Physics2D.Raycast(_mousePosition, Vector2.zero);

            if (_hit.collider != null)
            {
                GameObject _hitObj = _hit.collider.gameObject;

                if (_hitObj.CompareTag("Grid Square"))
                {
                    GameObject _obj = Instantiate(_itemToPlace, _hitObj.transform.position, Quaternion.identity);

                    _playerMouse._itemSelected = false;

                    _itemToPlace = null;
                    
                    _ghostItem.TurnOffItem();
                }
            }
        }
    }
}
