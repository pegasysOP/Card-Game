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
        opponentDeck.ShuffleSet();

        playerDeck.Draw(out playerHand, /*arbitrarily chosen :)*/ 3);
        opponentDeck.Draw(out opponentHand, /*arbitrarily chosen :)*/ 3);

        yield return BeginPlayerTurn();
    }

    private IEnumerator BeginPlayerTurn()
    {
        Debug.Log("Beginning player turn");

        playerTurn = true;
        battleState = BattleState.Selection;

        Debug.Log(playerDeck);
        Debug.Log(opponentDeck);

        yield return null;
    }
}
