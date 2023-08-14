using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewIngredient",menuName = "Create Ingredient")]
public class IngredientObject : ScriptableObject
{
    public enum Ingredient
    {
        KlektonEgg,
        PlutonizedFlour,
        GelidMeteor,
        CrispyTardigrade,
        CrawlingZimbro,
        SpaceDust,
        GreenMilk
    }
    
    public Ingredient ingredient;
    public Sprite sprite;
}
