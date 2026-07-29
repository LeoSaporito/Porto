using Unity.VisualScripting;
using UnityEngine;

public class LineRendererMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _position;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector2 _direction;

    [SerializeField] private bool _isMoving;    

    private void Start()
    {
        _isMoving = false;
        _direction = new Vector2(0, 1);
    }
    private void FixedUpdate()
    {
        if (!_isMoving) { return; }
        else
        {
            MoveLineRendererPoints();
        }
    }
    private void MoveLineRendererPoints()
    {
        Vector3 _position = transform.position;
        _position += (Vector3)_direction * _moveSpeed * Time.deltaTime;
        transform.position = _position;
    }
    public void MoveUp()
    {
        _direction = new Vector2(0, 1);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
    public void MoveDown()
    {
        _direction = new Vector2(0, -1);
        transform.eulerAngles = new Vector3(0, 0, 180);
    }
    public void MoveLeft()
    {
        _direction = new Vector2(-1, 0);
        transform.eulerAngles = new Vector3(0, 0, 90);
    }
    public void MoveRight()
    {
        _direction = new Vector2(1, 0);
        transform.eulerAngles = new Vector3(0, 0, 270);
    }
    public Vector2 GetDirection()
    {
        return _direction;
    }
    public void DelayPoint(float _delay)
    {
        Invoke("MovePoint", _delay);
    }
    public void MovePoint()
    {
        _isMoving = true;
    }
    public void StopPoint()
    {
        _isMoving = false;
    }
}
