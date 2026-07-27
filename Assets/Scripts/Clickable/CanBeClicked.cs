using UnityEngine;

public class CanBeClicked : MonoBehaviour
{
    [SerializeField] public bool _isClickable;

    public void TurnOffIsClickable()
    {
        _isClickable = false;
    }
    public void TurnOnIsClickable()
    {
        _isClickable = true;
    }
}
