using UnityEngine;
using UnityEngine.UI;

public class PageController : MonoBehaviour
{

    public Button rightScreen;
    public Button leftScreen;

    public ScreenSlider[] screens;

    private int _currentScreen = 0;
    
    private void Start()
    {
        rightScreen.onClick.AddListener(MoveRight);
        leftScreen.onClick.AddListener(MoveLeft);

        UpdateButtons();       
    }

    private void UpdateButtons()
    {
        leftScreen.interactable = _currentScreen > 0;
        rightScreen.interactable = _currentScreen < screens.Length - 1;
    }
    
    private void MoveRight()
    {
        if (_currentScreen >= screens.Length - 1)
        {
            return;
        }
        
        screens[_currentScreen].SlideOutLeft();
        _currentScreen++;
        screens[_currentScreen].SlideIn();

        UpdateButtons();

    }

    private void MoveLeft()
    {
        if (_currentScreen <= 0)
        {
            return;
        }
        
        screens[_currentScreen].SlideOutRight();
        _currentScreen--;
        screens[_currentScreen].SlideIn();
        UpdateButtons();

    }
}
