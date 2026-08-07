using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private PickUpsManager _pickUpsManager;
    public void PickedUp()
    {
        gameObject.SetActive(false);

        _pickUpsManager.AddToPickedUp();
    }
}
