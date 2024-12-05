using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<Card> _cards;

    public Deck()
    {
        _cards = new List<Card>();
    }

    public Card this[int i]
    {
        get { return _cards[i]; }
    }

    public int DeckSize()
    {
        return _cards.Count;
    }

    public void AddCard(Card card)
    {
        _cards.Add(card);
    }
}
