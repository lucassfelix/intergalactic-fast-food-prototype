using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IngredientBehaviour : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private IngredientObject.Ingredient _ingredient;
    private BoxCollider2D _boxCollider2D;
    private SoupMinigame _soupMinigame;
    private Image _image;

    private bool _initiated = false;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _image = GetComponent<Image>();
        _initiated = true;
    }

    public void Initiate(IngredientObject ingredientObject, SoupMinigame soupMinigame)
    {
        if (!_initiated)
        {
            Awake();
        }
        _ingredient = ingredientObject.ingredient;
        _image.sprite = ingredientObject.sprite;
        _soupMinigame = soupMinigame;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var contacts = new List<Collider2D>();

        if (_boxCollider2D.GetContacts(contacts) <= 0) return;

        foreach (var col in contacts)
        {
            if (col.gameObject.CompareTag("Bowl"))
            {
                _soupMinigame.OnIngredientAdded(_ingredient);   
                Destroy(gameObject);
            }
        }
    }
}
