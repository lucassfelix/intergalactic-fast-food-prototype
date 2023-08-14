using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class SoupMinigame : MonoBehaviour
{
    public IngredientList possibleIngredients;
    public GameObject ingredientPrefab;

    public AudioEvent correctFeedback;
    public AudioEvent sploshFeedback;
    public AudioEvent negativeFeedback;

    
    [SerializeField]
    private List<Transform> spawnPoints;

    private List<IngredientObject.Ingredient> _answer;
    private List<GameObject> _activeIngredients;
    
    private GameManager _gameManager;
    private OrderObject _currentOrder;


    private void Start()
    {
        _activeIngredients = new List<GameObject>();
    }

    public void CreateCorrectAnswer(OrderObject order, GameManager gm)
    {
        _gameManager = gm;
        _currentOrder = order;
        
        if (_activeIngredients.Count > 0)
        {
            _activeIngredients.ForEach(Destroy);
        }
        _activeIngredients = new List<GameObject>();
        
        _answer = new List<IngredientObject.Ingredient>();
        if (order.spice == OrderObject.Spice.Spicy)
        {
            _answer.Add(IngredientObject.Ingredient.KlektonEgg);
            if (order.restriction == OrderObject.Restriction.None)
            {
                _answer.Add(IngredientObject.Ingredient.GelidMeteor);
            }
            _answer.Add(IngredientObject.Ingredient.SpaceDust);
            _answer.Add(IngredientObject.Ingredient.CrawlingZimbro);       
            if (order.restriction == OrderObject.Restriction.None)
            {
                _answer.Add(IngredientObject.Ingredient.GreenMilk);
            }
            _answer.Add(IngredientObject.Ingredient.PlutonizedFlour);
            if (order.restriction == OrderObject.Restriction.None)
            {
                _answer.Add(IngredientObject.Ingredient.CrispyTardigrade);
            }
        }
        else
        {
            if (order.restriction == OrderObject.Restriction.None)
            {
                _answer.Add(IngredientObject.Ingredient.GreenMilk);
            }
            _answer.Add(IngredientObject.Ingredient.PlutonizedFlour);
            if (order.restriction == OrderObject.Restriction.None)
            {
                _answer.Add(IngredientObject.Ingredient.CrispyTardigrade);
            }
            _answer.Add(IngredientObject.Ingredient.KlektonEgg);
            if (order.restriction == OrderObject.Restriction.None)
            {
                _answer.Add(IngredientObject.Ingredient.GelidMeteor);
            }
            _answer.Add(IngredientObject.Ingredient.SpaceDust);
            _answer.Add(IngredientObject.Ingredient.CrawlingZimbro);
        }

        //MOVE!!
        RandomizeIngredients();
    }
    
    public void RandomizeIngredients()
    {
        possibleIngredients.list = possibleIngredients.list.OrderBy(i => Guid.NewGuid()).ToList();

        if (spawnPoints.Count < 4)
        {
            throw new WarningException("Not enough spawn points.");
        }
        
        for (var i = 0; i < 4; i++)
        {
            var newIngredient = Instantiate(ingredientPrefab, spawnPoints[i].position, Quaternion.identity, transform);
            newIngredient.GetComponent<IngredientBehaviour>().Initiate(possibleIngredients.list[i],this);
            _activeIngredients.Add(newIngredient);
        }

        for (var i = 4; i < possibleIngredients.list.Count; i++)
        {
            _answer.Remove(possibleIngredients.list[i].ingredient);
        }
    }

    public void OnIngredientAdded(IngredientObject.Ingredient ingredient)
    {
        if (_answer[0] == ingredient)
        {
            Debug.Log("Correto!");
            _answer.RemoveAt(0);
            AudioManager.Instance.PlayEvent(sploshFeedback);
        }
        else
        {
            AudioManager.Instance.PlayEvent(negativeFeedback);

            _gameManager.Begin();
        }

        if (_answer.Count == 0)
        {
            if (_currentOrder.recipe == OrderObject.Recipe.Soup)
            {
                AudioManager.Instance.PlayEvent(correctFeedback);
            }
            else
            {
                AudioManager.Instance.PlayEvent(negativeFeedback);
            }
            _gameManager.Begin();
        }
        
    }
    
}
