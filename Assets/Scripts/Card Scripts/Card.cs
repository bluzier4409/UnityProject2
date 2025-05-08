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

    protected float Lifespan;
    
    private bool InHand {get; set;}
     bool Active {get; set;}
     private GameObject physicalCard;
     private GameObject abilityPrefab;

     private bool indicated = false;

//defult constructor
   public Card()
   {
       Name = string.Empty;
       Type = string.Empty;
       InHand = false;
       Active = false;
   }

//set constructor
    public Card(string name, string type, bool inHand, bool active)
    {
        Name = name;
        Type = type;
        InHand = inHand;
        Active = active;
    }
    public Card(string name, string type, bool inHand, bool active ,GameObject physical)
    {
        Name = name;
        Type = type;
        InHand = inHand;
        Active = active;
        physicalCard = physical;
    }

    public Card(string name, string type, bool inHand, bool active ,GameObject physical, GameObject placedObj)
    {
        Name = name;
        Type = type;
        InHand = inHand;
        Active = active;
        physicalCard = physical;
        abilityPrefab = placedObj;
    }
    
    public Card(string name, string type, bool inHand, bool active ,GameObject physical, GameObject bulletObj, float lifespan)
    {
        Name = name;
        Type = type;
        InHand = inHand;
        Active = active;
        physicalCard = physical;
        abilityPrefab = bulletObj;
        Lifespan = lifespan;
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

    public String getType()
    {
        return Type;
    }

    void Awake()
    {
        
    }

    public float getLifespan()
    {
        return Lifespan;
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

  public GameObject GetAbilityObject(){
    return this.abilityPrefab;
  }

  public bool getIndicated(){
    return indicated;
  }

  public void setIndicated(bool toBe){
    indicated = toBe;
  }

}











