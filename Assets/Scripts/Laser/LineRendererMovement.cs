using UnityEngine;

public class LineRendererMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _position;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector2 _direction;

    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Vector3 _frontPoint;
    [SerializeField] private Vector3 _rearPoint;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        _frontPoint = _lineRenderer.GetPosition(0);
        _rearPoint = _lineRenderer.GetPosition(1);        

        _direction = new Vector2(0, 1);
    }
    private void FixedUpdate()
    {
        MoveLineRendererPoints();
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
    private void MoveLineRendererPoints()
    {
        _frontPoint += (Vector3)_direction * _moveSpeed * Time.deltaTime;
        _rearPoint += (Vector3)_direction * _moveSpeed * Time.deltaTime;

        _lineRenderer.SetPosition(0, _frontPoint);
        _lineRenderer.SetPosition(1, _rearPoint);
    }
}
