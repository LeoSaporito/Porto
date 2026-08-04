using System.Collections.Generic;
using UnityEngine;

public class MirrorManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> _activeMirrors = new List<GameObject>();

    [Header("ElectricWall")]
    [SerializeField] public ElectricWall[] _electricWall;

    public void Update()
    {
        for (int i = 0; i < _activeMirrors.Count; i++)
        {
            MirrorCollision _mirrorcollision = _activeMirrors[i].GetComponent<MirrorCollision>();

            if (_activeMirrors[i].GetComponent<SpriteRenderer>().color == Color.red)
            {
                for (int j = 0; j < _electricWall.Length; j++)
                {
                    _electricWall[j].TurnOnWall();
                }
                return;
            }
            else
            {
                for (int j = 0; j < _electricWall.Length; j++)
                {
                    _electricWall[j].TurnOffWall();
                }
            }
        }
    }
    public void ResetMirrorColor()
    {
        for (int i = 0; i < _activeMirrors.Count; i++)
        {
            _activeMirrors[i].GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
