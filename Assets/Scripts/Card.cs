using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private string Name { get; set; }
    private string Type { get; set; }
    private Sprite Sprite { get; set; }

    public Card(string name, string type, Sprite sprite)
    {
        Name = name;
        Type = type;
        Sprite = sprite;
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
        get { throw new System.NotImplementedException(); }
    }
}

public class Discard : MonoBehaviour
{
    private List<Card> _discardedCards;

    public Discard()
    {
        _discardedCards = new List<Card>();
    }
}

public class Hand : MonoBehaviour
{
    private List<Card> _hand;

    public Hand()
    {
        _hand = new List<Card>();
    }

    void Draw(Deck deck)
    {
        Card instanceCard = deck[0];
        _hand.Add(instanceCard);
    }
}







