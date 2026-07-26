using UnityEngine;

public class GridSquare : MonoBehaviour
{
    [SerializeField] private float xPosition;
    [SerializeField] private float yPosition;

    public void SetSpacing(float xSpacing, float ySpacing, float xOffset, float yOffset)
    {
        float x = xPosition;
        float y = yPosition;

        x *= xSpacing;
        y *= ySpacing;

        x += xOffset;
        y += yOffset;

        transform.position = new Vector2(x, y);
    }
    public void SetPlayerGridSpacing(float xSpacing, float xOffset, float yPos)
    {
        float x = xPosition;

        x *= xSpacing;

        x += xOffset;

        transform.position = new Vector2(x, yPos);
    }

    public void SetXPosition(int x)
    {
        xPosition = x;
    }
    public void SetYPosition(int y)
    {
        yPosition = y;
    }
}
