using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCardScript : MonoBehaviour
{
 private List<Card> _deck = new List<Card>();
 private List<Card> _discard = new List<Card>();

 //max hand size 3
 private List<Card> _hand = new List<Card>(3);
 public Image[] cardimage; // 1.Deck 2.Discard 3.Type1
 public Sprite[] cardsprite;


    public void Start()
    {
        Card sword = new Card("Sword", "Melee", false, false);
        _deck.Add(sword);
        Card bow = new Card("Bow", "Ranged", false, false);
        _deck.Add(bow);
        Card potion = new Card("Potion", "Consumable", false, false);
        _deck.Add(potion);
        Card axe = new Card("Axe", "Melee", false, false);
        _deck.Add(axe);

        int deckNum = _deck.Count;
        for (int x = _deck.Count; x > 0; x--){  
        Debug.Log(_deck[x-1].getName()+ " in deck");
        }

        Debug.Log(_hand.Count + " hand count");

        Draw();

        Debug.Log(_hand.Count + " hand count");

        for (int y = _hand.Count; y > 0; y--){  
        Debug.Log(_hand[y-1].getName()+ " in hand");
        }
    }

    public void Draw()
 {
    //draws unitll 3 cards in hand
  if (_deck.Count > _hand.Count)
  {
   List<Card> _tempList = new List<Card>();

   for (int i = 0; i < (3-_hand.Count); i++)
   {
    Card instanceCard = _deck[i];

    Debug.Log(instanceCard.getName());
//NEED TO CHANGE, removing cards ends up skiping others due to the for loop! Try adding to temp list, then remove all at once based on name?
    _tempList.Add(instanceCard);
   // _deck.Remove(instanceCard);
    _hand.Add(instanceCard);
    instanceCard.SetHandStatus(true);

     for (int x = _tempList.Count; x > 0; x--){ }
   }
  }
 }

 public void discardCard(Card card)
 {
  _hand.Remove(card);
  _discard.Add(card);
 }

 public void addCard(Card card)
 {
  _deck.Add(card);
 }

 public void setSprite(int spriteIndex, int imageIndex) {
  cardimage[imageIndex].sprite = cardsprite[spriteIndex];
 }

 public bool checkHandEmpty()
 {
  if (_hand.Count == 0)
  {
   return true;
  }
  else
  {
   return false;
  }
 }

 public void resetActivity()
 {
  foreach (Card card in _hand)
  {
   card.SetActiveStatus(false);
  }
 }

 public int checkActive()
 {
  if (Input.GetKeyDown(KeyCode.Alpha1))
  {
   resetActivity();
   _hand[0].SetActiveStatus(true);
   return 0;
  }
  if (Input.GetKeyDown(KeyCode.Alpha2))
  {
   resetActivity();
   _hand[1].SetActiveStatus(true);
   return 1;
  }
  if (Input.GetKeyDown(KeyCode.Alpha3))
  {
   resetActivity();
   _hand[2].SetActiveStatus(true);
   return 2;
  }
  else
  {
   return -1;
  }
 }

 public void playCard(Card card)
 {
  
 }
 

 public void Update()
 {
  Console.WriteLine("Player card");
  String line = Console.ReadLine();
  
  if (checkHandEmpty()) { Draw(); }

  if (checkActive() == 1 && Input.GetKeyDown(KeyCode.Mouse0)) { playCard(_hand[0]); }
  if (checkActive() == 2 && Input.GetKeyDown(KeyCode.Mouse0)) { playCard(_hand[1]); }
  if (checkActive() == 3 && Input.GetKeyDown(KeyCode.Mouse0)) { playCard(_hand[2]); }
  
 }
}


