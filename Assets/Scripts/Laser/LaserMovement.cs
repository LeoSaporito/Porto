using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _position;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector2 _direction;

    private void Update()
    {
        MoveUp();
    }

    private void MoveUp()
    {
        _position = transform.position;

        _position += Vector2.up * _moveSpeed * Time.deltaTime;

        transform.position = _position; 
    }
}
