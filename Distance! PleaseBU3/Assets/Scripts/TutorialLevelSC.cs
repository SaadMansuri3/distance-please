using UnityEngine;
using UnityEngine.UI;

public class TutorialLevelSC : MonoBehaviour
{

    public Button forwardButton;
    public Button backwardButton;
    private int _currentPanel;


    private void Start()
    {
    }

    private void Awake()
    {
        SelectPanel(0);
    }
    private void SelectPanel(int _index)
    {
        backwardButton.interactable = (_index != 0);
        forwardButton.interactable = (_index != transform.childCount - 1);

        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }

    public void ChangePanel(int _change)
    {
        _currentPanel += _change;
        SelectPanel(_currentPanel);
    }
}
