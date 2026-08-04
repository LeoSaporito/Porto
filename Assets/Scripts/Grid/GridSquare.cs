using UnityEngine;

public class GridSquare : MonoBehaviour
{
    [SerializeField] public GameObject _itemPlaced;
    [SerializeField] public string _itemName;

    public void PlacedItem(GameObject _obj, string _name)
    {
        _itemPlaced = _obj;
        _itemName = _name;
    }
    public void DeleteItem()
    {
        Destroy(_itemPlaced);
        _itemName = null;
    }
}
