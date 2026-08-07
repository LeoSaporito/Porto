using UnityEngine;

public class PickUpsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _numOfPickUps;

    [SerializeField] private int _numPickedUp;
    
    public void AddToPickedUp()
    {
        _numPickedUp++;
    }
}
