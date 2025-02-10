using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
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

    

    public void SetActiveStatus(bool activity)
    {
        Active = activity;
    }

    public void playCard()
    {
        print("play card");
    }
    
    
    public override string ToString()
    {
        return "This " + Type + " " + Name + "'s sprite is "/* + Sprite*/;
    }
}











