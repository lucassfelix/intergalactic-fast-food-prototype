using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrderCreator : MonoBehaviour
{
    public enum Prefix
    {
        Plá,
        Pló
    }

    public enum MainWord
    {
        Tork,
        Hork
    }

    public enum Suffix
    {
        Bix,
        Tix
    }

    public struct Order
    {
        public Prefix Prefix;
        public MainWord Main;
        public Suffix Sufffix;

        public Order(Prefix prefix, MainWord main, Suffix suffix)
        {
            Prefix = prefix;
            Main = main;
            Sufffix = suffix;
        }
        
    }

    public TextMeshProUGUI prefixText;
    public TextMeshProUGUI mainWordText;
    public TextMeshProUGUI suffixText;

    [ContextMenu("GenerateOrder")]
    public Order GetRandomOrder()
    {
        var newPrefix = (Prefix) Random.Range(0, (int)Enum.GetValues(typeof(Prefix)).Cast<Prefix>().Max() + 1);
        var newMainWord = (MainWord) Random.Range(0, (int)Enum.GetValues(typeof(MainWord)).Cast<MainWord>().Max() + 1);
        var newSuffix = (Suffix) Random.Range(0, (int)Enum.GetValues(typeof(Suffix)).Cast<Suffix>().Max() + 1);

        var newOrder = new Order(newPrefix, newMainWord, newSuffix);

        prefixText.text = newPrefix.ToString();
        mainWordText.text = newMainWord.ToString();
        suffixText.text = newSuffix.ToString();

        return newOrder;
    }

}
