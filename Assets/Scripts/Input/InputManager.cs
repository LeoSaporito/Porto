using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputManager : MonoBehaviour
{
    [SerializeField] private LaserManager _laserManager;
    [SerializeField] private PlayerManager _playerManager;

    [SerializeField] private bool _isTutorial;
    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            if (_isTutorial)
            {
                Tutorial();
            }
            
            _playerManager.LeftClicked();
        }
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            if (_isTutorial)
            {
                Tutorial();
            }

            _laserManager.FireLaser();
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _playerManager._directionalInput = context.ReadValue<Vector2>();
    }
    public void Tutorial()
    {
        TutorialManager _tutorialManager = FindFirstObjectByType<TutorialManager>();

        _tutorialManager.NextStep();
    }
}
