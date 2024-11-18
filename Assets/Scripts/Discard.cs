using System.Collections.Generic;
using UnityEngine;

public class Discard : MonoBehaviour
{
    private List<Card> _discardedCards;

    public Discard()
    {
        _discardedCards = new List<Card>();
    }

    public void DiscardCard(Card card)
    {
        _discardedCards.Add(card);
    }
}
