using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private CardObject cardData;
    
    private GameObject cardGO;

    [SerializeField] private int health;

    private void Start()
    {
        cardGO = this.gameObject;
        health = cardData.MaxHealth;
    }

    private void Update()
    {
        
    }

    private void DragCard()
    {

    }

    private void MoveCardInHand()
    {

    }
}
