using UnityEngine;

public class GridSquare : MonoBehaviour
{
    [SerializeField] private GhostItem _ghostItem;

    public void ItemSelected(string _itemName)
    {
        _ghostItem.TurnOnItem(_itemName);
    }
    public void ItemDeselected(string _itemName)
    {
        _ghostItem.TurnOffItem();
    }
}
