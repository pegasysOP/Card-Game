using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private CardBase cardBase;
    [SerializeField] private int hp;

    #region Attributes
    public string Name { get { return cardBase.cardName; } }
    public string Description { get { return cardBase.cardDescription; } }
    public int Hp { get { return hp; } }
    public int MaxHp { get { return cardBase.MaxHp; } }
    public int Damage { get { return cardBase.Damage; } }
    #endregion

    private void Start()
    {
        hp = cardBase.MaxHp;
    }
}