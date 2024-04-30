using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlaceholderCard : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI hpText;

    public UnityEvent<Card> OnSelected;
    
    public void Init(Card card, int index)
    {
        button.onClick.AddListener(() => OnButtonClick(card));

        nameText.text = card.Name;
        descriptionText.text = card.Description;
        attackText.text = card.Damage.ToString();
        hpText.text = string.Format("{0}/{1}", card.Hp, card.MaxHp);
    }

    private void OnButtonClick(Card card)
    {
        button.interactable = false;
        button.onClick.RemoveAllListeners();

        OnSelected.Invoke(card);
    }
}
