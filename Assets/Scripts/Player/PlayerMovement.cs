using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Scripts")]
    [SerializeField] private PlayerManager _playerManager;

    [Header ("Movement")]
    [SerializeField] private Vector2 _position;
    [SerializeField] private float _moveSpeed;

    [Header ("Bounds")]
    [SerializeField] private TilemapRenderer _playerBox;
    [SerializeField] private float _padding;
    
    private void Update()
    {
        _position = transform.position;

        _position.x = Mathf.Clamp(transform.position.x, _playerBox.bounds.min.x + _padding, _playerBox.bounds.max.x - _padding);

        _position.x += _moveSpeed * _playerManager._directionalInput.x * Time.deltaTime;
        
        transform.position = _position;
    }
}
