using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ElectricWall : MonoBehaviour
{
    [SerializeField] public List<GameObject> _activeMirrors = new List<GameObject>();
    public void TurnOnWall()
    {
        gameObject.SetActive(true);
    }
    public void TurnOffWall()
    {
        gameObject.SetActive(false);
    }
    public void DeactivateWallCheck()
    {

    }
}
