using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _topLeftToBottomRightText;
    [SerializeField] private TextMeshProUGUI _topRightToBottomLeftText;

    [SerializeField] private PlayerItems _playerItems;

    private void Start()
    {
        _topLeftToBottomRightText.text = _playerItems._numOfTopLeftToBottomRight + ":";
        _topRightToBottomLeftText.text = _playerItems._numOfTopRightToBottomLeft + ":";        
    }
    public void ChangeItemsValue(string _itemName, int _itemValue)
    {
        if (_itemName == "TopLeftToBottomRightMirror")
        {
            _topLeftToBottomRightText.text = _itemValue + ":";
        }
        else if (_itemName == "TopRightToBottomLeftMirror")
        {
            _topRightToBottomLeftText.text = _itemValue + ":";
        }
    }
}
