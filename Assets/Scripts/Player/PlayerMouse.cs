using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class PlayerMouse : MonoBehaviour
{
    [SerializeField] public string _itemName;
    [SerializeField] public bool _itemSelected;
    [SerializeField] private Vector2 _mousePosition;

    [Header("GhostItem")]
    [SerializeField] private GameObject _ghostItemPrefab;
    [SerializeField] private GhostItem _ghostItem;
    public void InitializeItems(string _item)
    {
        _itemName = _item;
    }
    public Vector2 MousePosition()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        return _mousePosition;
    }
    private void ShowGhostItem()
    {
        MousePosition();

        RaycastHit2D _hit = Physics2D.Raycast(MousePosition(), Vector2.zero);

        if (_hit.collider != null)
        {
            GameObject _hitObj = _hit.collider.gameObject;

            if (_hitObj.CompareTag("Grid Square"))
            {
                GridSquare _gridSquare = _hitObj.GetComponent<GridSquare>();

                if (_gridSquare._itemPlaced != null)
                {
                    _ghostItemPrefab.SetActive(false);
                    return;
                }
                else if (_gridSquare._itemPlaced == null)
                {
                    _ghostItemPrefab.SetActive(true);
                    _ghostItemPrefab.transform.position = _hitObj.transform.position;

                    _ghostItem.TurnOnItem(_itemName);
                }
            }
        }
        else
        {
            _ghostItemPrefab.SetActive(false);
            _ghostItem.TurnOffItem();
        }
    }
    private void FixedUpdate()
    {
        if (!_itemSelected) { return; }
        else
        {
            ShowGhostItem();
        }
    }
    public void ResetItem()
    {
        _ghostItemPrefab.SetActive(false);
        _itemName = null;
        _itemSelected = false;
    }
}
