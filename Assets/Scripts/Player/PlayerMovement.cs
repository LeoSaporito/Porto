using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
}
