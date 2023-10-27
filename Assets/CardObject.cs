using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "CreateCardObject", order  = 1)]
public class CardObject : ScriptableObject
{
    [Header("Information")]
    [SerializeField] private string CardName;
    [SerializeField] private string CardDescription;

    [Header("Attributes")]
    [SerializeField] private int CardHealth;
    [SerializeField] private int CardDamage;

    [Header("Visuals")]
    [SerializeField] private Sprite CardImageSprite;
    [SerializeField] private Sprite CardBackgroundSprite;
    [SerializeField] private Sprite CardBorderSprite;

}
