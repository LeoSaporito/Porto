using UnityEngine;

public class MirrorButtons : MonoBehaviour
{
    [SerializeField] private bool _mirrorSelected;
    public void TopLeftToBottomRightMirror()
    {
        _mirrorSelected = true;
    }
    public void TopRightToBottomLeftMirror()
    {
        _mirrorSelected = true;
    }
    public void ChoosePosition()
    {

    }
}
