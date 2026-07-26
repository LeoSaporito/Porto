using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] public float xPosition;
    [SerializeField] public float yPosition;

    public void SetXPosition(float x)
    {
        xPosition = x;
    }
    public void SetYPosition(float y)
    {
        yPosition = y;
    }
}
