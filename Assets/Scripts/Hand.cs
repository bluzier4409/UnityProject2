using System.Collections.Generic;
using UnityEngine;

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
        if (DeckSize() >= _handSize)
            for (int i = 0; i < _handSize; i++)
            {
                Card instanceCard = deck[0];
                _hand.Add(instanceCard);
                instanceCard.setHandStatus(true);
            }
    }

    void useCard(Card card)
    {
        
    }
}
