using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewIngredientList",menuName = "Create Ingredient List")]
public class IngredientList : ScriptableObject
{
    public List<IngredientObject> list;
}
