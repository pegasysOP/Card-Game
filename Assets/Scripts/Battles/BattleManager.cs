using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private BattleState battleState = BattleState.None;
    public BattleState BattleState { get { return battleState; } }

    private bool playerTurn = true; // true if player, false if opponent
    public bool PlayerTurn { get { return playerTurn; } }

    private Deck playerDeck;
    private Deck opponentDeck;

    private List<Card> playerHand;
    private List<Card> opponentHand;

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
        battleState = BattleState.Selection;

        EventManager.InvokeMatchEvent(new MatchEventArgs(MatchEventType.PlayerTurnStart));

        yield return null;
    }
}
