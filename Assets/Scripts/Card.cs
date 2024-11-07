using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private string Name { get; set; }
    private string Type { get; set; }
    
    private GameObject CardObj {get; set;}
    private Sprite Sprite { get; set; }
    private static Animator Animator { get; set; }

    public Card(string name, string type, GameObject cardObj, Sprite sprite)
    {
        Name = name;
        Type = type;
        CardObj = cardObj;
        Sprite = sprite;
        Animator = cardObj.GetComponent<Animator>();
    }

    public override string ToString()
    {
        return "This " + Type + " " + Name + "'s sprite is " + Sprite;
    }
}

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

    public void AddCard(Card card)
    {
        _cards.Add(card);
    }
}

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

public class Hand : MonoBehaviour
{
    private List<Card> _hand;
    private int _handSize;

    public Hand(int handSize)
    {
        _handSize = handSize;
        _hand = new List<Card>(_handSize);
    }

    void Draw(Deck deck)
    {
        Card instanceCard = deck[0];
        _hand.Add(instanceCard);
    }

    void useCard(Card card)
    {
        
    }
}







