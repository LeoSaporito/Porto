using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private TilemapRenderer _playerBox;

    [SerializeField] private Vector2 _position;
    [SerializeField] private float _moveSpeed;

    [SerializeField] private float _padding;
    
    public void MovePlayer(GameObject objOne, GameObject objTwo)
    {
        Vector2 _objOnePosition = objOne.transform.position;
        Vector2 _objTwoPosition = objTwo.transform.position;

        float _distance = Vector2.Distance(_objOnePosition, _objTwoPosition);
        Vector2 _direction = (_objTwoPosition - _objOnePosition).normalized;

        Vector2 _newPosition = _objOnePosition + (_distance * _direction);

        transform.position = new Vector3(_newPosition.x, transform.position.y, 0);

        print(_newPosition);
        print(_distance);
    }
    private void Update()
    {
        _position = transform.position;

        _position.x = Mathf.Clamp(transform.position.x, _playerBox.bounds.min.x + _padding, _playerBox.bounds.max.x - _padding);

        _position.x += _moveSpeed * _inputManager._directionalInput.x * Time.deltaTime;
        
        transform.position = _position;
    }
}
