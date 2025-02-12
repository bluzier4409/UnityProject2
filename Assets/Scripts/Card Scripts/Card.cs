using System;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    protected string Name { get; set; }
    protected string Type { get; set; }
    
    public bool InHand {get; set;}
     bool Active {get; set;}

   public Card()
   {
       Name = string.Empty;
       Type = string.Empty;
       InHand = false;
       Active = false;
   }

    public Card(string name, string type, bool inHand, bool active)
    {
        Name = name;
        Type = type;
        InHand = inHand;
        Active = active;
    }

    public void SetHandStatus(bool activity)
    {
        InHand = activity;
    }

    public Card GetCard()
    {
        return this;
    }

    public bool GetActiveStatus()
    {
        return Active;
    }
    
    void Awake()
    {
        Card sword = new Card("Sword", "Melee", false, false);
        Card bow = new Card("Bow", "Ranged", false, false);
        Card potion = new Card("Potion", "Consumable", false, false);
        Card axe = new Card("Axe", "Melee", false, false);
    }

    

    public void SetActiveStatus(bool activity)
    {
        Active = activity;
    }

    public void playCard()
    {
        Debug.Log("Playing Card");
    }
    
    
    public override string ToString()
    {
        return "This " + Type + " " + Name + "'s sprite is "/* + Sprite*/;
    }

  
}











