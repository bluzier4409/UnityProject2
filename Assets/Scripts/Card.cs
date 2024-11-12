using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string Name { get; set; }
    public string Type { get; set; }
    
    private bool InHand {get; set;}
    private bool Active {get; set;}
   // public GameObject CardObj {get; set;}
   // public Sprite Sprite { get; set; }
   // public static Animator Animator { get; set; }

    public Card(string name, string type, bool inHand, bool active/*, GameObject cardObj, Sprite sprite*/)
    {
        Name = name;
        Type = type;
        InHand = inHand;
        Active = active;
     //   CardObj = cardObj;
      //  Sprite = sprite;
      //  Animator = cardObj.GetComponent<Animator>();
    }

    public void setHandStatus(bool activity)
    {
        InHand = activity;
    }

    public override string ToString()
    {
        return "This " + Type + " " + Name + "'s sprite is "/* + Sprite*/;
    }
}











