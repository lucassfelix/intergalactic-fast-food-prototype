using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngredientBehaviour : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private BoxCollider2D _boxCollider2D;

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
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
        Debug.Log("Colidindo!");

        foreach (var VARIABLE in contacts)
        {
            if (VARIABLE.gameObject.CompareTag("Bowl"))
            {
                Debug.Log("Na tijela!");
            };
        }
    }
}
