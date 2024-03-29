using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JuiceMinigame : MonoBehaviour
{
    
    public AudioEvent correctFeedback;
    public AudioEvent negativeFeedback;
    
    private GameManager _gameManager;
    private OrderObject _currentOrder;

    public Button _button;

    public TextMeshProUGUI counter;

    public void CreateCorrectAnswer(OrderObject order, GameManager gm)
    {
        _gameManager = gm;
        _button.onClick.RemoveAllListeners();

        if (order.recipe == OrderObject.Recipe.Juice)
        {
            _button.onClick.AddListener(PlayCorrect);
        }
        else
        {
            _button.onClick.AddListener(PlayNegative);
        }
        
        _button.onClick.AddListener(gm.Begin);
    }

    private void PlayCorrect()
    {
        AudioManager.Instance.PlayEvent(correctFeedback);
        counter.text = $"Pontuação: {++_gameManager.score}";
    }
    
    private void PlayNegative()
    {
        AudioManager.Instance.PlayEvent(negativeFeedback);
        counter.text = $"Pontuação: {--_gameManager.score}";

    }

}
