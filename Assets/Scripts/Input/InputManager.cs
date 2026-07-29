using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputManager : MonoBehaviour
{
    [SerializeField] private ClickingManager _clickingManager;
    [SerializeField] private LineRendererManager _lineRendererManager;

    [SerializeField] public Vector2 _directionalInput;
    public void OnLeftClick(InputAction.CallbackContext context)
    {
        //if (context.started) { print(context); }
        //if (context.performed) { print(context); }

        if (context.canceled)
        {
            _clickingManager.Clicked();
        }
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            _lineRendererManager.SpawnLaser();
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _directionalInput = context.ReadValue<Vector2>();
    }
}
