using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    protected string Name {get; set;}
    protected string Type { get; set; }
    
    private bool InHand {get; set;}
     bool Active {get; set;}
     private GameObject physicalCard;

//defult constructor
   public Card()
   {
       Name = string.Empty;
       Type = string.Empty;
       InHand = false;
       Active = false;
   }

//set constructor
    public Card(string name, string type, bool inHand, bool active ,GameObject physical)
    {
        Name = name;
        Type = type;
        InHand = inHand;
        Active = active;
        physicalCard = physical;
    }

    public void SetHandStatus(bool activity)
    {
        InHand = activity;
    }

    public bool getHandStatus(){
        return InHand;
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

  public String getName(){
        return Name;
  }
  
  public GameObject GetGameObject(){
    return this.physicalCard;
  }

}











