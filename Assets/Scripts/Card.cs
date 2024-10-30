using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using Random = System.Random;

class CardDeck : MonoBehaviour
{
    private readonly List<Card> _cardDeck;
    private List<Card> _discardPile;
    private Random _random;

    public CardDeck()
    {
        _cardDeck = new List<Card>();
        _discardPile = new List<Card>();
        _random = new Random();
    }

    public void AddCardToDeck(Card card)
    {
        _cardDeck.Add(card);
    }

    public void RemoveCardFromDeck(Card card)
    {
        _cardDeck.Remove(card);
    }

    public void DiscardFromDeck(Card card)
    {
        RemoveCardFromDeck(card);
        _discardPile.Add(card);
    }

    // public void Reset(List<Card> cards, List<Card> discardPile)
    //{
      //  for (int i = 0; i < cards.Count; i++)
   //     {
    //        
    //    }
   // }

    public void ShuffleDeck()
    {
        for (int i = _cardDeck.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);
            (_cardDeck[i], _cardDeck[j]) = (_cardDeck[j], _cardDeck[i]);
        }
    }
}


public class Card : MonoBehaviour
{
    private bool _consumable;
    private bool _utility;

    public Card() {}
    public Card(bool consumable, bool utility)
    {
        _consumable = consumable;
        _utility = utility;
    }

    void UseCard()
    {
        
    }

    void ConsumeCard()
    {
        
    }
    
    
}
