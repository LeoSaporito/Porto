using UnityEngine;

public class PointsDirection : MonoBehaviour
{
    [SerializeField] private PointsMovement _pointsMovement;
    private void Start()
    {
        _pointsMovement = GetComponent<PointsMovement>();
    }
    public void ChangeDirection(string _angleType)
    {
        switch (_angleType)
        {
            case "Top/Right : Bottom/Left": TopRightToBottomLeftDirectionCheck(_pointsMovement); break;
            case "Top/Left : Bottom/Right": TopLeftToBottomRightDirectionCheck(_pointsMovement); break;
        }
    }
    private void TopRightToBottomLeftDirectionCheck(PointsMovement _pointsMovement)
    {
        Vector2 _laserDirection = _pointsMovement.GetDirection();

        switch (_laserDirection.x, _laserDirection.y)
        {
            case (0, 1): _pointsMovement.MoveRight(); break;
            case (0, -1): _pointsMovement.MoveLeft(); break;
            case (-1, 0): _pointsMovement.MoveDown(); break;
            case (1, 0): _pointsMovement.MoveUp(); break;
        }
    }
    private void TopLeftToBottomRightDirectionCheck(PointsMovement _pointsMovement)
    {
        Vector2 _laserDirection = _pointsMovement.GetDirection();

        switch (_laserDirection.x, _laserDirection.y)
        {
            case (0, 1): _pointsMovement.MoveLeft(); break;
            case (0, -1): _pointsMovement.MoveRight(); break;
            case (-1, 0): _pointsMovement.MoveUp(); break;
            case (1, 0): _pointsMovement.MoveDown(); break;
        }
    }
}
