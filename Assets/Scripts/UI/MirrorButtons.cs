using UnityEngine;
using UnityEngine.InputSystem;

public class MirrorButtons : MonoBehaviour
{
    [SerializeField] private bool _mirrorSelected;
    [SerializeField] private GameObject _itemSelectedPrefab;
    [SerializeField] private Vector2 _mousePosition;
    [SerializeField] private string _item;
    public void TopLeftToBottomRightMirror()
    {
        _mirrorSelected = true;
    }
    public void TopRightToBottomLeftMirror()
    {
        _mirrorSelected = true;
    }
    private void FixedUpdate()
    {
        if (!_mirrorSelected) { return; }
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
                _hitObj.GetComponent<GridSquare>().ItemSelected(_item);
            }
        }
    }
}
