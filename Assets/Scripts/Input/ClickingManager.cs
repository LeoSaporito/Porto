using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickingManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> _clickedObjects = new List<GameObject>();
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GridManager _gridManager;

    public void Clicked()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (!hit.collider)
        {
            return;
        }
        else
        {
            GameObject hitObj = hit.collider.gameObject;

            AddObjectToList(hitObj);
        }

        CheckObjectList();
    }
    private void AddObjectToList(GameObject hitObj)
    {
        if (hitObj.GetComponent<CanBeClicked>()._isClickable == false) { return; }
        else
        {
            if (_clickedObjects[0] == null)
            {
                _clickedObjects[0] = hitObj;
                hitObj.GetComponent<ObjectSelected>().Selected();
            }
            else if (_clickedObjects[1] == null)
            {
                _clickedObjects[1] = hitObj;
            }
        }
    }
    private void CheckObjectList()
    {
        if (_clickedObjects[1] != null)
        {
            MovePlayer();

            _clickedObjects[0].GetComponent<ObjectSelected>().Deselected();

            _clickedObjects[0] = null;
            _clickedObjects[1] = null;

            _gridManager.TurnOffGrid();            
        }
        else if (_clickedObjects[0] != null)
        {
            _gridManager.TurnOnGrid();
        }
        else { return; }
    }
    private void MovePlayer()
    {
        //_playerMovement.MovePlayer(_clickedObjects[0], _clickedObjects[1]);
    }
}
