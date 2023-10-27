using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private CardBase cardBase;
    [SerializeField] private int hp;

    public string Name { get { return cardBase.cardName; } }
    public string Description { get { return cardBase.cardDescription; } }
    public int MaxHp { get { return cardBase.MaxHp; } }
    public int Damage { get { return cardBase.Damage; } }

    private void Start()
    {
        hp = cardBase.MaxHp;
    }
}