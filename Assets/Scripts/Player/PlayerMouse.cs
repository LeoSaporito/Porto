using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouse : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;
    public void OnLeftClick(InputAction.CallbackContext context)
    {
        //if (context.started)
        //{
        //    print(context);        
        //}
        //if (context.performed)
        //{
        //    print(context);        
        //}
        if (context.canceled)
        {
            _playerManager.Clicked();
        }
    }
}
