using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject _hitObj = collision.gameObject;

        if (_hitObj.CompareTag("Laser"))
        {
            //_hitObj._pointSpawner.
        }
    }
}
