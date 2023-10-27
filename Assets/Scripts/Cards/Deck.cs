using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    [SerializeField] private List<Card> deck;

    public Deck()
    {
        deck = new List<Card>();
    }

    public void Shuffle()
    {
        for(int i = 0; i < deck.Count; i++)
        {
            int toReplace = Random.Range(0, deck.Count);
            Card temp = deck[i];
            deck[i] = deck[toReplace];
            deck[toReplace] = temp;
        }
    }

    public void Add(Card card)
    {
        deck.Add(card);
    }

    public void Discard(Card card)
    {
        deck.Remove(card);
    }


}
