using System;

public class MatchEventArgs : EventArgs
{
    public readonly MatchEventType EventType;

    public MatchEventArgs(MatchEventType eventType)
    {
        this.EventType = eventType;
    }
}
