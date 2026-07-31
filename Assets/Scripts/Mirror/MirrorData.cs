using UnityEngine;

public class MirrorData : MonoBehaviour
{
    [SerializeField] private string _angleType;
    public string GetAngleType()
    {
        return _angleType;
    }
}
