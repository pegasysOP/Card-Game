using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    // TODO: this should be changed to be a neater, non direct way of referencing the button
    [SerializeField] private Button endTurnButton;
    [SerializeField] private Transform cardContainer;
    [SerializeField] private PlaceholderCard placeholderCardPrefab;
    private List<PlaceholderCard> placeholderCards;

    private BattleState battleState = BattleState.None;
    private bool playerTurn = true;

    private Deck playerDeck;
    private Deck opponentDeck;

    private List<Card> playerHand;
    private List<Card> opponentHand;

    private void Awake()
    {
        endTurnButton.onClick.AddListener(OnEndTurnButtonClicked);
    }

    public void StartBattle(Deck playerDeck, Deck opponentDeck)
    {
        battleState = BattleState.Starting;

        this.playerDeck = playerDeck;
        this.opponentDeck = opponentDeck;

        StartCoroutine(InitialiseBattle());
    }

    private IEnumerator InitialiseBattle()
    {
        playerDeck.ShuffleSet();
        EventManager.InvokeCardEvent(new CardEventArgs(true, CardEventType.HandShuffled));
        opponentDeck.ShuffleSet();
        EventManager.InvokeCardEvent(new CardEventArgs(false, CardEventType.HandShuffled));


        playerHand = new List<Card>();
        List<Card> drawnCards = new List<Card>();
        playerDeck.Draw(out drawnCards, /*arbitrarily chosen :)*/ 3);
        EventManager.InvokeCardEvent(new CardEventArgs(drawnCards.ToArray(), true, CardEventType.CardDrawn));
        playerHand.AddRange(drawnCards);

        opponentHand = new List<Card>();
        drawnCards = new List<Card>();
        opponentDeck.Draw(out drawnCards, /*arbitrarily chosen :)*/ 3);
        EventManager.InvokeCardEvent(new CardEventArgs(drawnCards.ToArray(), false, CardEventType.CardDrawn));
        opponentHand.AddRange(drawnCards);

        yield return BeginPlayerTurn();
    }

    private IEnumerator BeginPlayerTurn()
    {
        playerTurn = true;
        battleState = BattleState.Processing;

        EventManager.InvokeMatchEvent(new MatchEventArgs(MatchEventType.PlayerTurnStart));

        List<Card> drawnCards = new List<Card>();
        playerDeck.Draw(out drawnCards, 1);
        EventManager.InvokeCardEvent(new CardEventArgs(drawnCards.ToArray(), true, CardEventType.CardDrawn));
        playerHand.AddRange(drawnCards);

        ShowPlayerCards();

        battleState = BattleState.Selection;
        yield return null;
    }

    private void OnEndTurnButtonClicked()
    {
        if (!playerTurn || battleState != BattleState.Selection)
            return;

        ClearPlayerCards();
        endTurnButton.gameObject.SetActive(false);

        StartCoroutine(BeginOpponentTurn());
    }

    private IEnumerator BeginOpponentTurn()
    {
        playerTurn = false;
        battleState = BattleState.Processing;

        EventManager.InvokeMatchEvent(new MatchEventArgs(MatchEventType.EnemyTurnStart));

        List<Card> drawnCards = new List<Card>();
        opponentDeck.Draw(out drawnCards, 1);
        EventManager.InvokeCardEvent(new CardEventArgs(drawnCards.ToArray(), false, CardEventType.CardDrawn));
        opponentHand.AddRange(drawnCards);

        battleState = BattleState.Selection;
        yield return OpponentCardSelection();
    }

    private IEnumerator OpponentCardSelection()
    {
        // pick opponents moves


        yield return new WaitForSeconds(3f);
        yield return BeginPlayerTurn();
    }

    private void PlayCard(Card card)
    {
        // activate card
        EventManager.InvokeCardEvent(new CardEventArgs(card, true, CardEventType.CardPlayed));

        playerHand.Remove(card);

        endTurnButton.gameObject.SetActive(true);
    }

    private void ShowPlayerCards()
    {
        if (placeholderCards == null)
            placeholderCards = new List<PlaceholderCard>();

        for (int i = 0; i < playerHand.Count; i++)
        {
            PlaceholderCard card = Instantiate(placeholderCardPrefab, cardContainer);
            placeholderCards.Add(card);
            card.Init(playerHand[i], i);
            card.OnSelected.AddListener(PlayCard);
        }
    }

    private void ClearPlayerCards()
    {
        if (placeholderCards != null)
        {
            for (int i = placeholderCards.Count - 1; i >= 0; i--)
            {
                Destroy(placeholderCards[i].gameObject);
                placeholderCards.RemoveAt(i);
            }
        }

        placeholderCards = new List<PlaceholderCard>();
    }
}
