using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] public int _numOfTopLeftToBottomRight;
    [SerializeField] public int _numOfTopRightToBottomLeft;
    
    [SerializeField] public int _value;

    public void Subtract(string _name)
    {
        if (_name == "TopLeftToBottomRightMirror")
        {
            _numOfTopLeftToBottomRight--;
        }
        else if (_name == "TopRightToBottomLeftMirror")
        {
            _numOfTopRightToBottomLeft--;
        }
    }
    public void Add(string _name)
    {
        if (_name == "TopLeftToBottomRightMirror")
        {
            _numOfTopLeftToBottomRight++;
        }
        else if (_name == "TopRightToBottomLeftMirror")
        {
            _numOfTopRightToBottomLeft++;
        }
    }
    public int GetValue(string _name)
    {
        if (_name == "TopLeftToBottomRightMirror")
        {
            _value = _numOfTopLeftToBottomRight;
        }
        else if (_name == "TopRightToBottomLeftMirror")
        {
            _value = _numOfTopRightToBottomLeft;
        }
        return _value;
    }
}
