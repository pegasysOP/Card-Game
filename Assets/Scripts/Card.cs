using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    [Header("Card Details")]
    [SerializeField] private string name;
    [SerializeField] private string description;

    [Header("Card Attributes")]
    [SerializeField] private int cost;
    [SerializeField] private int damage;
    [SerializeField] private int healing;

    [Header("Card Styling")]
    [SerializeField] private Sprite cardImageSprite;
    [SerializeField] private Sprite cardBackgroundSprite; 

    public Card(string name, string desc, int cost, int dmg, int healing, Sprite imgSprite, Sprite backgroundSprite)
    {
        this.name = name;
        this.description = desc;
        this.cost = cost;
        this.damage = dmg;
        this.healing = healing;
        this.cardImageSprite = imgSprite;
        this.cardBackgroundSprite = backgroundSprite;
    }
}
