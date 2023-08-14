using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class AlienCreator : MonoBehaviour
{
    public enum Color
    {
        Green,
        Magenta
    }

    public enum Horns
    {
        NoHorns,
        WithHorns
    }

    public enum Fur
    {
        NoFur,
        WithFur
    }

    public struct Alien
    {
        public Color Color;
        public Horns Horns;
        public Fur Fur;

        public Alien(Color color, Fur fur, Horns horns)
        {
            Color = color;
            Horns = horns;
            Fur = fur;
        }
        
    }

    public TextMeshProUGUI colorText;
    public TextMeshProUGUI furText;
    public TextMeshProUGUI hornsText;

    [ContextMenu("GenerateAlien")]
    public Alien GetRandomAlien()
    {
        var newColor = (Color) Random.Range(0, (int)Enum.GetValues(typeof(Color)).Cast<Color>().Max() + 1);
        var newFur = (Fur) Random.Range(0, (int)Enum.GetValues(typeof(Fur)).Cast<Fur>().Max() + 1);
        var newHorn = (Horns) Random.Range(0, (int)Enum.GetValues(typeof(Horns)).Cast<Horns>().Max() + 1);

        var newAlien = new Alien(newColor, newFur, newHorn);

        colorText.text = newColor.ToString();
        furText.text = newFur.ToString();
        hornsText.text = newHorn.ToString();

        return newAlien;
    }
    
    
}
