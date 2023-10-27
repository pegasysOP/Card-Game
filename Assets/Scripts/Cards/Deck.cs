using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    [SerializeField] private List<Card> cardSet;

    private Queue<Card> drawQueue;

    public Deck(List<Card> cards)
    {
        Init(cards);
    }

    /// <summary>
    /// Initialise the deck with the set of cards provided - adds all cards to the draw queue
    /// </summary>
    /// <param name="cards"></param>
    public void Init(List<Card> cards)
    {
        cardSet = cards;
        ShuffleSet();

        if (drawQueue == null)
            drawQueue = new Queue<Card>();

        drawQueue.Clear();

        foreach (Card card in cardSet)
            drawQueue.Enqueue(card);
    }
    
    // this probably wants to be shuffling the queue instead of the card set - Sam
    public void ShuffleSet()
    {
        for(int i = 0; i < cardSet.Count; i++)
        {
            int toReplace = Random.Range(0, cardSet.Count);
            (cardSet[toReplace], cardSet[i]) = (cardSet[i], cardSet[toReplace]);
        }
    }

    public void Add(Card card)
    {
        // not sure what this should do just yet - Sam

        //For now we will have a finite deck so there is no need to add extra cards to the deck. However this could change in future and then we would want to use this method - Lewis
    }

    /// <summary>
    /// Places <paramref name="quantity"/> cards from the draw queue into <paramref name="drawnCards"/>
    /// </summary>
    /// <param name="drawnCards">Location for drawn cards to be placed - any previous contents will be erased</param>
    /// <param name="quantity">Number of cards to draw - willl draw until queue is empty, or quantity is met</param>
    /// <returns>false if there weren't enough cards to draw</returns>
    public bool Draw(out List<Card> drawnCards, int quantity = 1)
    {
        drawnCards = new List<Card>();

        for (int i = 0; i < quantity; i++)
        {
            if (drawQueue.Count == 0)
                return false;

            drawnCards.Add(drawQueue.Dequeue());
        }

        return true;
    }

    /// <summary>
    /// Discards <paramref name="quantity"/> cards from the draw queue
    /// </summary>
    /// <param name="quantity">Number of cards to draw - will discard until queue is empty, or quantity is met</param>
    /// <returns>false if there weren't enough cards to discard</returns>
    public bool Discard(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        { 
            if (drawQueue.Count == 0)
                return false;

            drawQueue.Dequeue(); // Maybe this should put the cards into a discard pile, to be used in future mechanics? - Sam
        }

        return true;
    }


}
