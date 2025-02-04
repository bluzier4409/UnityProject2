using System.Collections.Generic;
using UnityEngine;

public class PlayerCardScript : Card
{
 private List<Card> _deck = new List<Card>();
 private List<Card> _discard = new List<Card>();

 //max hand size 3
 private List<Card> _hand = new List<Card>(3);


 public void Draw()
 {
  if (_deck.Count > _hand.Count)
  {
   for (int i = 0; i < _hand.Count; i++)
   {
    Card instanceCard = _deck[i];
    _deck.Remove(instanceCard);
    _hand.Add(instanceCard);
    instanceCard.SetHandStatus(true);
   }
  }
 }

 public void discardCard(Card card)
 {
  _hand.Remove(card);
  _discard.Add(card);
 }
 
 

 public bool checkHandEmpty()
 {
  return false;
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
 

 public void Update()
 {
  if (checkHandEmpty()) { Draw(); }

  if (checkActive() == 1 && Input.GetKeyDown(KeyCode.Mouse0)) { playCard(); }
  if (checkActive() == 2 && Input.GetKeyDown(KeyCode.Mouse0)) { playCard(); }
  if (checkActive() == 3 && Input.GetKeyDown(KeyCode.Mouse0)) { playCard(); }
  
 }
}


