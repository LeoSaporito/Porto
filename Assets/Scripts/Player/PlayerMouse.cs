using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class PlayerMouse : MonoBehaviour
{
    [SerializeField] public string _item;
    [SerializeField] public bool _itemSelected;
    [SerializeField] private Vector2 _mousePosition;

    [SerializeField] private GameObject _ghostItemPrefab;
    [SerializeField] private GhostItem _ghostItem;
    private void Start()
    {
        _ghostItemPrefab.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (!_itemSelected) { return; }
        else
        {
            MousePosition();
        }
    }
    public void MousePosition()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        RaycastHit2D _hit = Physics2D.Raycast(_mousePosition, Vector2.zero);

        if (_hit.collider != null)
        {
            GameObject _hitObj = _hit.collider.gameObject;

            if (_hitObj.CompareTag("Grid Square"))
            {
                _ghostItemPrefab.SetActive(true);
                _ghostItemPrefab.transform.position = _hitObj.transform.position;

                _ghostItem.TurnOnItem(_item);
            }
        }
        else
        {
            _ghostItemPrefab.SetActive(false);
            _ghostItem.TurnOffItem();
        }
    }
}
