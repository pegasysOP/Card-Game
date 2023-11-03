using UnityEngine;

/// <summary>
/// An instance of a card, created from a CardBase
/// </summary>
[System.Serializable]
public class Card
{
    [SerializeField] private CardBase cardBase;
    private int hp;    

    #region Attributes
    public string Name { get { return cardBase.cardName; } }
    public string Description { get { return cardBase.cardDescription; } }
    public int Hp { get { return hp; } }
    public int MaxHp { get { return cardBase.MaxHp; } }
    public int Damage { get { return cardBase.Damage; } }
    #endregion

    private void Init(CardBase cardBase)
    {
        this.cardBase = cardBase;
        hp = cardBase.MaxHp;

        // set sprite and other features of the card base
    }
}