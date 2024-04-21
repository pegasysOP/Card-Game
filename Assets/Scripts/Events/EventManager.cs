using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    private CardEventSystem cardEventSystem;

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
    }

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
}
