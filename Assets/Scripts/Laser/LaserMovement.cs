using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _position;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector2 _direction;

    private void Start()
    {
        _direction = new Vector2(0, 1);
    }
    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        _position = transform.position;

        _position += _direction * _moveSpeed * Time.deltaTime;

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
    public void SetPositionToMirror(GameObject _obj)
    {
        transform.position = _obj.transform.position;
    }
    public Vector2 GetDirection()
    {
        return _direction;
    }
}
