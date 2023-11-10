using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] BattleManager battleManager;

    [SerializeField] List<CardBase> testPlayerCards; // only for testing, don't use lists of cards
    [SerializeField] List<CardBase> testOpponentCards;

    private void Update()
    {
        // for testing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            battleManager.StartBattle(new Deck(GenCards(testOpponentCards)), new Deck(GenCards(testOpponentCards)));
        }
    }

    // once again I am asking you to understand this is only for testing
    private List<Card> GenCards(List<CardBase> cardBases)
    {
        List<Card> cards = new List<Card>();

        foreach (CardBase cardBase in cardBases)
        {
            cards.Add(new Card(cardBase));
        }

        return cards;
    }
}
