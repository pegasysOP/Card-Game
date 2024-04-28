using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    private CardEventSystem cardEventSystem;
    private MatchEventSystem matchEventSystem;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        StartEventSystems();
    }

    private void StartEventSystems()
    {
        cardEventSystem = new CardEventSystem();
        matchEventSystem = new MatchEventSystem();
    }

    #region Cards Events

    public static void InvokeCardEvent(CardEventArgs eventArgs)
    {
        Instance.cardEventSystem.InvokeEvent(eventArgs);
    }

    public static void AddCardEventListener(CardEventListener eventListener)
    {
        Instance.cardEventSystem.AddListener(eventListener);
    }

    public static void RemoveCardEventListener(CardEventListener eventListener)
    {
        Instance.cardEventSystem.RemoveListener(eventListener);
    }

    #endregion

    #region Match Events

    public static void InvokeMatchEvent(MatchEventArgs eventArgs)
    {
        Instance.matchEventSystem.InvokeEvent(eventArgs);
    }

    public static void AddMatchEventListener(MatchEventListener eventListener)
    {
        Instance.matchEventSystem.AddListener(eventListener);
    }

    public static void RemoveMatchEventListener(MatchEventListener eventListener)
    {
        Instance.matchEventSystem.RemoveListener(eventListener);
    }

    #endregion
}
