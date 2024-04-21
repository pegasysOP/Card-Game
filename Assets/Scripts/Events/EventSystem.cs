using System;

public delegate void EventListener(EventArgs eventArgs);

public abstract class EventSystem
{
    protected event EventListener eventListener;

    protected void InvokeEvent(EventArgs eventArgs)
    {
        eventListener?.Invoke(eventArgs);
    }

    protected void AddListener(EventListener listener)
    {
        eventListener += listener;
    }

    protected void RemoveListener(EventListener listener)
    {
        eventListener -= listener;
    }
}
