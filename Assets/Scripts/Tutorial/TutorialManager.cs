using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialManager : MonoBehaviour
{
    //[SerializeField]
    [SerializeField] public GameObject[] _popUps;
    [SerializeField] public int _popUpIndex;


    [SerializeField] public bool _stepOne;
    [SerializeField] public bool _stepTwo;
    [SerializeField] public bool _stepThree;
    [SerializeField] public bool _stepFour;
    [SerializeField] public bool _stepFive;

    private void Update()
    {
        for (int i = 0; i < _popUps.Length; i++)
        {
            if (i == _popUpIndex)
            {
                _popUps[i].SetActive(true);
            }
            else
            {
                _popUps[i].SetActive(false);
            }
        }

        if (_popUpIndex == 0)
        {
            if (_stepOne == true)
            {
                _popUpIndex++;
            }
        }
        else if (_popUpIndex == 1)
        {
            if (_stepTwo == true)
            {
                _popUpIndex++;
            }
        }
        else if (_popUpIndex == 2)
        {
            if (_stepThree == true)
            {
                _popUpIndex++;
            }
        }
        else if (_popUpIndex == 3)
        {
            if (_stepFour == true)
            {
                _popUpIndex++;
            }
        }
        else if (_popUpIndex == 4)
        {
            if (_stepFive == true)
            {
                _popUpIndex++;
            }
        }
    }
    public void NextStep()
    {
        if (_popUpIndex == 0)
        {
            _stepOne = true;
        }
        else if (_popUpIndex == 1)
        {
            _stepTwo = true;
        }
        else if (_popUpIndex == 2)
        {
            _stepThree = true;
        }
        else if (_popUpIndex == 3)
        {
            _stepFour = true;
        }
        else if (_popUpIndex == 4)
        {
            _stepFive = true;
        }
    }
}
