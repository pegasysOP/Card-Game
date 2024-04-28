using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    // TODO: this should be changed to be a neater, non direct way of referencing the button
    [SerializeField] private Button endTurnButton;

    private BattleState battleState = BattleState.None;
    public BattleState BattleState { get { return battleState; } }

    private bool playerTurn = true; // true if player, false if opponent
    public bool PlayerTurn { get { return playerTurn; } }

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

        battleState = BattleState.Selection;
        yield return null;
    }

    private void OnEndTurnButtonClicked()
    {
        if (!playerTurn || battleState != BattleState.Selection)
            return;

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

}
