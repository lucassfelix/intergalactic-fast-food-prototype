using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="NewOrder",menuName = "ScriptableObjects/Create New Order")]
public class OrderObject : ScriptableObject
{
    public enum Recipe
    {
        Soup,
        Juice
    }

    public enum Spice
    {
        Sweet,
        Spicy
    }

    public enum Restriction
    {
        None,
        NoLactose
    }

    public Recipe recipe;
    public Spice spice;
    public Restriction restriction;

}
