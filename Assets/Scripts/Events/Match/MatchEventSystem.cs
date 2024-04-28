using System.Collections.Generic;

public enum MatchEventType
{
    PlayerTurnStart,
    PlayerTurnEnd,
    EnemyTurnStart,
    EnemyTurnEnd
}

public delegate void MatchEventListener(MatchEventArgs eventArgs);

public class MatchEventSystem : EventSystem
{
    private Dictionary<MatchEventListener, EventListener> listeners;

    public MatchEventSystem()
    {
        listeners = new Dictionary<MatchEventListener, EventListener>();
    }

    public void InvokeEvent(MatchEventArgs eventArgs)
    {
        base.InvokeEvent(eventArgs);
    }

    public void AddListener(MatchEventListener matchEventListener)
    {
        // We can assume the cast can work because the onl way to invoke is with the above method
        EventListener eventListener = (eventArgs) => matchEventListener((MatchEventArgs)eventArgs);
        listeners.Add(matchEventListener, eventListener);
        base.AddListener(eventListener);
    }

    public void RemoveListener(MatchEventListener matchEventListener)
    {
        EventListener eventListener;

        if (listeners.TryGetValue(matchEventListener, out eventListener))
            base.RemoveListener(eventListener);
    }
}