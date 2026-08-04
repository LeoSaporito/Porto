using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    [SerializeField] private GhostItem _ghostItem;
    [SerializeField] public string _item;
    public void OnHoverEnterEffect(GameObject _gridObj)
    {
        _ghostItem.TurnOnItem(_item);
        print(_item);
    }
    public void OnHoverExitEffect(GameObject _gridObj)
    {
        _ghostItem.TurnOffItem();
        print(_item);
    }
}