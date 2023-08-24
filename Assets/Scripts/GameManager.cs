using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AlienCreator alienCreator;
    public OrderCreator orderCreator;
    public SoupMinigame SoupMinigame;
    public JuiceMinigame juiceMinigame;

    public int score = 0;
    
    [ContextMenu("Init")]
    public void Begin()
    {

        var newAlien = alienCreator.GetRandomAlien();
        var newOrder = orderCreator.GetRandomOrder(newAlien);

        var newSoupOrder = ScriptableObject.CreateInstance<OrderObject>();
        
        if (newAlien.Color == AlienCreator.Color.Green)
        {
            newSoupOrder.recipe = newOrder.Main == OrderCreator.MainWord.Tork
                ? OrderObject.Recipe.Juice
                : OrderObject.Recipe.Soup;
        }
        else
        {
            newSoupOrder.recipe = newOrder.Main == OrderCreator.MainWord.Tork
                ? OrderObject.Recipe.Soup
                : OrderObject.Recipe.Juice;
        }
        
        if (newAlien.Horns == AlienCreator.Horns.WithHorns)
        {
            newSoupOrder.spice = newOrder.Prefix == OrderCreator.Prefix.Plá
                ? OrderObject.Spice.Spicy
                : OrderObject.Spice.Sweet;
        }
        else
        {
            newSoupOrder.spice = newOrder.Prefix == OrderCreator.Prefix.Plá
                ? OrderObject.Spice.Sweet
                : OrderObject.Spice.Spicy;
        }
        
        if (newAlien.Fur == AlienCreator.Fur.WithFur)
        {
            newSoupOrder.restriction = newOrder.Sufffix == OrderCreator.Suffix.Bix
                ? OrderObject.Restriction.NoLactose
                : OrderObject.Restriction.None;
        }
        else
        {
            newSoupOrder.restriction = newOrder.Sufffix == OrderCreator.Suffix.Bix
                ? OrderObject.Restriction.None
                : OrderObject.Restriction.NoLactose;
        }
        
        SoupMinigame.CreateCorrectAnswer(newSoupOrder,this);
        juiceMinigame.CreateCorrectAnswer(newSoupOrder,this);
    }
}