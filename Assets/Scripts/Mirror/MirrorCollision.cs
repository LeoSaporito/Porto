using System;
using UnityEngine;

public class MirrorCollision : MonoBehaviour
{
    [SerializeField] private string _angleType;
    [SerializeField] private BoxCollider2D _boxCollider;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            GameObject _hitObj = collision.gameObject;
            LineRendererMovement _lineRendererMovement = _hitObj.GetComponent<LineRendererMovement>();

            ChangeDirection(_lineRendererMovement);
            AddPoint();
        }
    }
    private void AddPoint()
    {
        //when the front point collides against the mirror
        //spawn new point at the point of contact
    }

    private void ChangeDirection(LineRendererMovement _lineRendererMovement)
    {
        switch (this._angleType)
        {
            case "Top/Right : Bottom/Left": TopRightToBottomLeftDirectionCheck(_lineRendererMovement); break;
            case "Top/Left : Bottom/Right": TopLeftToBottomRightDirectionCheck(_lineRendererMovement); break;
        }        
    }
    private void TopRightToBottomLeftDirectionCheck(LineRendererMovement _lineRendererMovement)
    {
        Vector2 _laserDirection = _lineRendererMovement.GetDirection();

        switch (_laserDirection.x, _laserDirection.y)
        {
            case (0, 1): _lineRendererMovement.MoveRight(); break;
            case (0, -1): _lineRendererMovement.MoveLeft(); break;
            case (-1, 0): _lineRendererMovement.MoveDown(); break;
            case (1, 0): _lineRendererMovement.MoveUp(); break;
        }
    }
    private void TopLeftToBottomRightDirectionCheck(LineRendererMovement _lineRendererMovement)
    {
        Vector2 _laserDirection = _lineRendererMovement.GetDirection();

        switch (_laserDirection.x, _laserDirection.y)
        {
            case (0, 1): _lineRendererMovement.MoveLeft(); break;
            case (0, -1): _lineRendererMovement.MoveRight(); break;
            case (-1, 0): _lineRendererMovement.MoveUp(); break;
            case (1, 0): _lineRendererMovement.MoveDown(); break;
        }
    }
}

//private void OnCollisionEnter2D(Collision2D collision)
//{
//    if (collision.gameObject.CompareTag("Laser"))
//    {
//        LaserMovement _laserMovement = collision.gameObject.GetComponent<LaserMovement>();

//        Vector2 _laserDirection = _laserMovement.GetDirection();

//        switch (this._angleType)
//        {
//            case "Top/Right : Bottom/Left": TopRightToBottomLeftDirectionCheck(_laserMovement); break;
//            case "Top/Left : Bottom/Right": TopLeftToBottomRightDirectionCheck(_laserMovement); break;
//        }
//        ;

//        print("hit");
//    }
//}

//private void TopRightToBottomLeftDirectionCheck(LaserMovement _laserMovement)
//{
//    Vector2 _laserDirection = _laserMovement.GetDirection();

//    switch (_laserDirection.x, _laserDirection.y)
//    {
//        case (0, 1): _laserMovement.MoveRight(); break;
//        case (0, -1): _laserMovement.MoveLeft(); break;
//        case (-1, 0): _laserMovement.MoveDown(); break;
//        case (1, 0): _laserMovement.MoveUp(); break;
//    }

//    //_laserMovement.SetPositionToMirror(this.gameObject);
//}

//private void TopLeftToBottomRightDirectionCheck(LaserMovement _laserMovement)
//{
//    Vector2 _laserDirection = _laserMovement.GetDirection();

//    switch (_laserDirection.x, _laserDirection.y)
//    {
//        case (0, 1): _laserMovement.MoveLeft(); break;
//        case (0, -1): _laserMovement.MoveRight(); break;
//        case (-1, 0): _laserMovement.MoveUp(); break;
//        case (1, 0): _laserMovement.MoveDown(); break;
//    }

//    //_laserMovement.SetPositionToMirror(this.gameObject);
//}
//-----------------------------------------------------------------------------------------------------------------------------//
//LaserMovement _laserMovement = collision.gameObject.GetComponent<LaserMovement>();

////when laser hits the mirror:
//// --> check the direction of the laser
//// --> check the side the laser hit
//Vector2 _laserDirection = _laserMovement.GetDirection();

////change the movement of the laser depending on:
//// --> the lasers current direction
//// --> which side the laser hit


//if (collision.gameObject.CompareTag("Laser"))
//{
//    LaserMovement _laserMovement = collision.gameObject.GetComponent<LaserMovement>();
//    switch (this._angleType)
//    {
//        case "Up": _laserMovement.MoveUp(); _laserMovement.SetPositionToMirror(this.gameObject); break;
//        case "Down": _laserMovement.MoveDown(); _laserMovement.SetPositionToMirror(this.gameObject); break;
//        case "Left": _laserMovement.MoveLeft(); _laserMovement.SetPositionToMirror(this.gameObject); break;
//        case "Right": _laserMovement.MoveRight(); _laserMovement.SetPositionToMirror(this.gameObject); break;
//    }
//    ;

//    print("hit");
//}

//if (collision.gameObject.CompareTag("Laser"))
//{
//    GameObject _laserObj = collision.gameObject;
//    LaserMovement _laserMovement = _laserObj.GetComponent<LaserMovement>();

//    //when laser hits the mirror:
//    // --> check the direction of the laser
//    // --> check the side the laser hit

//    //change the movement of the laser depending on:
//    // --> the lasers current direction
//    // --> which side the laser hit

//    //when laser hits the mirror:
//    // --> check the direction of the laser
//    Vector2 _laserDirection = _laserMovement.GetDirection();

//    // --> check the side the laser hit
//    //get each side of the mirror's box collider

//    float _xMin = _boxCollider.bounds.min.x;
//    float _xMax = _boxCollider.bounds.max.x;

//    float _yMin = _boxCollider.bounds.min.y;
//    float _yMax = _boxCollider.bounds.max.y;

//    //Left edge


//    //check which side the lasers origin is closest to

//    float _xCheck = Mathf.Min(_laserObj.transform.position.x - _xMin, _laserObj.transform.position.x - _xMax);


//    print("hit");
//}
