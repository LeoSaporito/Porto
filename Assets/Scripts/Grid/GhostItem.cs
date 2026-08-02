using UnityEngine;

public class GhostItem : MonoBehaviour
{
    [SerializeField] private Sprite _topLeftToBottomRightMirror, _topRightToBottomLeftMirror;

    public void TurnOnItem(string _itemName)
    {
        switch (_itemName)
        {
            case "TopLeftToBottomRightMirror": GetComponent<SpriteRenderer>().sprite = _topLeftToBottomRightMirror; break;
            case "TopRightToBottomLeftMirror": GetComponent<SpriteRenderer>().sprite = _topRightToBottomLeftMirror; break;
        }
    }
    public void TurnOffItem()
    {
        GetComponent<SpriteRenderer>().sprite = null;
    }
}
