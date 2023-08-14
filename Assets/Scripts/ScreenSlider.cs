using UnityEngine;
using DG.Tweening;

public class ScreenSlider : MonoBehaviour
{

    public void SlideOutLeft()
    {
        transform.DOLocalMoveX(-2000, 1f);
    }
    
    public void SlideOutRight()
    {
        transform.DOLocalMoveX(2000, 1f);
    }
    
    public void SlideIn()
    {
        transform.DOLocalMoveX(0, 1f);
    }
    
}
