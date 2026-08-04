using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ElectricWall : MonoBehaviour
{
    public void TurnOnWall()
    {
        gameObject.SetActive(true);
    }
    public void TurnOffWall()
    {
        gameObject.SetActive(false);
    }
}
