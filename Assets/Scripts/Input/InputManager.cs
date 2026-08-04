using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputManager : MonoBehaviour
{
    [SerializeField] private LaserManager _laserManager;
    [SerializeField] private PlayerManager _playerManager;  
    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            _playerManager.LeftClicked();
        }
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            _laserManager.FireLaser();
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _playerManager._directionalInput = context.ReadValue<Vector2>();
    }
}
