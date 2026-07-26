using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System;

public class PlayerManager : MonoBehaviour
{
    public List<GameObject> _clickedObjects = new List<GameObject>();
    public void Clicked()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        GameObject hitObj = hit.collider.gameObject;

        AddObjectToList(hitObj);

        MoveObjectsCheck();

        print(hitObj);
    }
    private void AddObjectToList(GameObject hitObj)
    {
        if (_clickedObjects[0] == null)
        {
            _clickedObjects.Add(hitObj);
        }
        else if (_clickedObjects[1] == null)
        {
            _clickedObjects.Add(hitObj);
        }
    }
    private void MoveObjectsCheck()
    {
        if (_clickedObjects.Count == 2)
        {
            GameObject objOne = _clickedObjects[0];
            GameObject objTwo = _clickedObjects[2];


        }
    }
}
