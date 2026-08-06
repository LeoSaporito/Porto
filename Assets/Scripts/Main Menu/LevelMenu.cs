using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] _buttons;
    public GameObject _levelButtons;

    private void Awake()
    {
        ButtonsToArray();

        int _unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = false;
        }
        for (int i = 0; i < _unlockedLevel; i++)
        {
            _buttons[i].interactable = true;
        }
    }
    public void OpenLevelSelect(int _levelID)
    {
        string _levelName = "Level " + _levelID;

        SceneManager.LoadScene(_levelName);
    }
    public void ButtonsToArray()
    {
        int _childCount = _levelButtons.transform.childCount;

        _buttons = new Button[_childCount];

        for (int i = 0; i < _childCount; i++)
        {
            _buttons[i] = _levelButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }
}
