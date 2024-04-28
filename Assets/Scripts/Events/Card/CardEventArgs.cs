using System;

public class CardEventArgs : EventArgs
{
    public readonly CardEventType EventType;
    public readonly Card Card;
    public readonly Card[] Cards;
    public readonly bool IsPlayer;

    public CardEventArgs(Card card, bool isPlayer, CardEventType eventType)
    {
        this.Card = card;
        this.IsPlayer = isPlayer;
        this.EventType = eventType;
    }

    public CardEventArgs(Card[] cards, bool isPlayer, CardEventType eventType)
    {
        this.Cards = cards;
        this.IsPlayer = isPlayer;
        this.EventType = eventType;
    }

    public CardEventArgs(Card card, Card[] cards, bool isPlayer, CardEventType eventType)
    {
        this.Card = card;
        this.Cards = cards;
        this.IsPlayer = isPlayer;
        this.EventType = eventType;
    }

    public CardEventArgs(bool isPlayer, CardEventType eventType)
    {
        this.IsPlayer = isPlayer;
        this.EventType = eventType;
    }

    /// <summary>
    /// Gets the number of cards involved in this event
    /// </summary>
    /// <returns>Returns can return 0 if all cards are null</returns>
    public int GetCardCount()
    {
        int count = 0;

        if (Card != null)
            count++;

        if (Cards != null)
            count += Cards.Length;

        return count;
    }

    /// <summary>
    /// Checks if there is a main card of this event
    /// </summary>
    /// <returns>True if there is a main card</returns>
    public bool HasMainCard()
    {
        return Card != null;
    }

    /// <summary>
    /// Checks if there is a card list for this event
    /// </summary>
    /// <returns>True if there is a card list</returns>
    public bool HasCardList()
    {
        return Cards != null && Cards.Length > 0;
    }
}
