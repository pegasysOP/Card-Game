using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Deck deck;

    // for testing
    [SerializeField] private List<Card> cardList;

    private void Start()
    {
        deck = new Deck(cardList);
    }
}
