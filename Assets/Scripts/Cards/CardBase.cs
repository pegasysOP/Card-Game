using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card", order  = 0)]
public class CardBase : ScriptableObject
{
    [Header("Information")]
    public string cardName;
    [TextArea(3, 6)]
    public string cardDescription;

    [Header("Attributes")]
    public int MaxHp;
    public int Damage;

    [Header("Visuals")]
    public Sprite CardImageSprite;
    public Sprite CardBackgroundSprite;
    public Sprite CardBorderSprite;
}
