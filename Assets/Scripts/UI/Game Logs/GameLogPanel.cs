using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameLogPanel : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private Transform contentTransform;
    [SerializeField] private GameLogComponent logComponentPrefab;
    [SerializeField] private int maxLogCount;

    private List<GameLogComponent> logComponents = new List<GameLogComponent>();

    private void OnEnable()
    {
        EventManager.AddCardEventListener(OnCardEvent);
    }
    
    private void OnDisable()
    {
        EventManager.RemoveCardEventListener(OnCardEvent);
    }

    private void AddLogComponent(string message)
    {
        GameLogComponent logComponent = Instantiate(logComponentPrefab, contentTransform);
        logComponent.Init(message);
        logComponents.Add(logComponent);

        // remove oldest log component if going over the limit
        if (logComponents.Count > maxLogCount)
        {
            GameLogComponent oldestComponent = logComponents[0];
            logComponents.RemoveAt(0);
            Destroy(oldestComponent.gameObject);
        }

        // scroll to the bottom to show new message
        StartCoroutine(DelayedScrollToBottom());
    }

    private IEnumerator DelayedScrollToBottom()
    {
        yield return new WaitForEndOfFrame();

        scrollRect.verticalNormalizedPosition = 0f;
    }

    private void OnCardEvent(CardEventArgs eventArgs)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("[CARD EVENT] > ");

        switch(eventArgs.EventType)
        {
            case CardEventType.CardDrawn:
                stringBuilder.Append(eventArgs.IsPlayer ? "Player" : "Enemy").Append(" drew card(s): ").Append(GetCardsString(eventArgs));
                break;
            case CardEventType.CardDiscarded:
                stringBuilder.Append(eventArgs.IsPlayer ? "Player" : "Enemy").Append(" discarded card(s): ").Append(GetCardsString(eventArgs));
                break;
            case CardEventType.CardPlayed:
                stringBuilder.Append(eventArgs.IsPlayer ? "Player" : "Enemy").Append(" played card(s): ").Append(GetCardsString(eventArgs));
                break;
            case CardEventType.CardAdded:
                stringBuilder.Append(eventArgs.IsPlayer ? "Player" : "Enemy").Append(" added card(s) to deck: ").Append(GetCardsString(eventArgs));
                break;
            case CardEventType.HandShuffled:
                stringBuilder.Append(eventArgs.IsPlayer ? "Player" : "Enemy").Append(" shuffled their hand ");
                break;
        }

        AddLogComponent(stringBuilder.ToString());
    }

    private string GetCardsString(CardEventArgs eventArgs)
    {
        StringBuilder stringBuilder = new StringBuilder();

        if (eventArgs.HasMainCard())
            stringBuilder.Append(string.Format("<{0}> ", eventArgs.Card));

        if (eventArgs.HasCardList())
        {
            for (int i = 0; i < eventArgs.Cards.Length; i++)
            {
                stringBuilder.Append(eventArgs.Cards[i]);

                if (i < eventArgs.Cards.Length - 1)
                    stringBuilder.Append(", ");
            }
        }
        
        return stringBuilder.ToString();
    }
}
