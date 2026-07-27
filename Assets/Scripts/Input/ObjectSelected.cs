using UnityEngine;

public class ObjectSelected : MonoBehaviour
{
    [SerializeField] private bool _objectSelected;
    [SerializeField] private float _increaseScale;

    public void Selected()
    {
        transform.localScale = new Vector3(_increaseScale, _increaseScale, 1f);
    }
    public void Deselected()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
