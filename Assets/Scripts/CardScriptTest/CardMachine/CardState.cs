using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState
{
    protected Card2 card;
    protected CardMachine cardMachine;

    public CardState(Card2 card, CardMachine cardMachine)
    {
        this.card = card;
        this.cardMachine = cardMachine;
    }
    
    public virtual void EnterState() {}

    public virtual void LeaveState() {}
    
    public virtual void UpdateState() {}
    
  //  public virtual void CardAnimation()

}
