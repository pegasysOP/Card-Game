using System.Collections.Generic;

public enum CardEventType
{
    /// <summary>
    /// When a card or cards moves from the draw pile to the hand
    /// </summary>
    CardDrawn,
    /// <summary>
    /// When a card or cards are moved from the hand to the discard pile
    /// </summary>
    CardDiscarded,
    /// <summary>
    /// When a card is played
    /// </summary>
    CardPlayed,
    /// <summary>
    /// When a card or cards are added to the deck
    /// </summary>
    CardAdded,
    /// <summary>
    /// When a players hand is shuffled
    /// </summary>
    HandShuffled
}

public delegate void CardEventListener(CardEventArgs eventArgs);

public class CardEventSystem : EventSystem
{
    private Dictionary<CardEventListener, EventListener> listeners;

    public CardEventSystem()
    {
        listeners = new Dictionary<CardEventListener, EventListener>();
    }

    public void InvokeEvent(CardEventArgs eventArgs)
    {
        base.InvokeEvent(eventArgs);
    }

    public void AddListener(CardEventListener cardEventListener)
    {
        // We can assume the cast can work because the onl way to invoke is with the above method
        EventListener eventListener = (eventArgs) => cardEventListener((CardEventArgs)eventArgs);
        listeners.Add(cardEventListener, eventListener);
        base.AddListener(eventListener);
    }

    public void RemoveListener(CardEventListener cardEventListener)
    {
        EventListener eventListener;

        if (listeners.TryGetValue(cardEventListener, out eventListener))
            base.RemoveListener(eventListener);
    }
}