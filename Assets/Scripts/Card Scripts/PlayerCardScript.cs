using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCardScript : MonoBehaviour
{

public Text numCardsText;

 private List<Card> _deck = new List<Card>();
 private List<Card> _discard = new List<Card>();

 //max hand size 3
 private List<Card> _hand = new List<Card>(3);
 public GameObject[] cardPrefabs; // 1.Deck 2.Discard 3.Type1

public RectTransform handPlace;
public RectTransform deckPlace;
public RectTransform discardPlace;

    public void Start()
    {
        numCardsText.text = _deck.Count.ToString();


        Card sword = new Card("Sword", "Melee", false, false, cardPrefabs[0]);
        _deck.Add(sword);
        Card bow = new Card("Bow", "Ranged", false, false, cardPrefabs[1]);
        _deck.Add(bow);
        Card potion = new Card("Potion", "Consumable", false, false, cardPrefabs[2]);
        _deck.Add(potion);
        Card axe = new Card("Axe", "Melee", false, false, cardPrefabs[3]);
        _deck.Add(axe);
        Card gun = new Card("gun", "Ranged", false, false, cardPrefabs[4]);
        _deck.Add(gun);
        Card bomb = new Card("bomb", "Ranged", false, false, cardPrefabs[5]);
        _deck.Add(bomb);
        Card lasar = new Card("lasar", "Ranged", false, false, cardPrefabs[1]);
        _deck.Add(lasar);

        _deck.Add(axe);

       

        


        Draw();


        
    }

public void Draw(){
//draws unitll 3 cards in hand
    if(_hand.Count == 0){
        if(_deck.Count < 3){deckEmpty();}
        }
  if (_hand.Count == 0 && _deck.Count >= 3){
    resetActivity();
    for (int i = 0; i < 3; i++){
    _hand.Add(_deck[0]);
    _deck.RemoveAt(0);
    }
   foreach (Card card in _deck){    
        Debug.Log("Draw just happened, cards in DECK are " + card.getName());
    }
    foreach (Card card4 in _hand){    
        Debug.Log("Draw just happened, cards in HAND are " + card4.getName());
    }
   updateCardsShown();
   
   foreach(Card card9 in _hand){card9.SetHandStatus(true);}
  }
  foreach(Card card10 in _hand){card10.SetActiveStatus(false);}
  printWhatsActive();
}

 public void discardCard(Card card)
 {
    foreach (Card card3 in _hand){resetActivity();}
  _hand.Remove(card);
  _discard.Add(card);
  card.SetActiveStatus(false);
  
    updateCardsShown();
    printWhatsActive();
    foreach (Card card1 in _deck){    
        Debug.Log("Discard just happened, cards in DECK are " + card1.getName());
    }
    foreach (Card card2 in _discard){    
        Debug.Log("Discard just happened, cards in DISCARD are " + card2.getName());
    }
    foreach (Card card5 in _hand){    
        Debug.Log("Discard just happened, cards in HAND are " + card5.getName());
    }
    Debug.Log("END OF DISCARD");
 }

 public void addCard(Card card)
 {
  _deck.Add(card);
 }

 /*public void setSprite(int spriteIndex, int imageIndex) {
  cardimage[imageIndex].sprite = cardsprite[spriteIndex];
 }*/

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
    indicateSelectedCard indicateScript = this.GetComponent<indicateSelectedCard>();
    int x = 0;
    
  foreach (Card card in _hand)
  {
    
    if(card.GetActiveStatus() == true){
        indicateScript.goBackDown(x);
        card.SetActiveStatus(false);
    }
    x = x+1;
   card.SetActiveStatus(false);
  }
 }

 private void printWhatsActive(){
  /*  foreach(Card card in _hand){
    Debug.Log(card.getName() + " is active: " + card.GetActiveStatus());
   }    
   Debug.Log("DONE1");*/
 }

 public int checkActive()
 {
    indicateSelectedCard indicateScript = this.GetComponent<indicateSelectedCard>();

  if (Input.GetKeyDown(KeyCode.Alpha1))
  {
    if (_hand[0].GetActiveStatus() == true)
    {indicateScript.goBackDown(0);   
    _hand[0].SetActiveStatus(false);
    }
    else{
   resetActivity();
   _hand[0].SetActiveStatus(true);
   indicateScript.indicate(0);
    }
    printWhatsActive();
   return 1;
  }
  else if (Input.GetKeyDown(KeyCode.Alpha2))
  {
    if (_hand[1].GetActiveStatus() == true)
    {indicateScript.goBackDown(1);   
    _hand[1].SetActiveStatus(false);
    }
    else {
   resetActivity();
   _hand[1].SetActiveStatus(true);
    indicateScript.indicate(1);
    }
    printWhatsActive();
   return 2;
  }
  else if (Input.GetKeyDown(KeyCode.Alpha3))
  {
    if (_hand[2].GetActiveStatus() == true)
    {indicateScript.goBackDown(2);   
    _hand[2].SetActiveStatus(false);
    }
    else{
   resetActivity();
   _hand[2].SetActiveStatus(true);
    indicateScript.indicate(2);
    }
   printWhatsActive();
   return 3;
  }
  else
  {
   return -1;
  }
 }

 public void playCard(Card card)
 {
  Debug.Log("Playing card: "+ card.ToString());
 }

 public int whatIsActive(){
    if (_hand[0].GetActiveStatus() == true){
        return 0;
    }
    else if (_hand[1].GetActiveStatus() == true){
        return 1;
    }
    else if (_hand[2].GetActiveStatus() == true){
        return 2;
    }
    else return -1;
 }

 public void deckEmpty(){
    
    //add discard to deck
    foreach (Card card in _discard.ToArray()){
        _deck.Add(card);
        _discard.Remove(card);
    }
    //shuffle deck method
    reshuffle(_deck);

   
    
    
    updateCardsShown();

    foreach (Card card1 in _deck){    
        Debug.Log("DeckEmpty just happened, cards in DECK are " + card1.getName());
    }
    foreach (Card card2 in _discard){    
        Debug.Log("DeckEmpty just happened, cards in DISCARD are " + card2.getName());
    }
    foreach (Card card5 in _hand){    
        Debug.Log("DeckEmpty just happened, cards in HAND are " + card5.getName());
    }
    Debug.Log("END OF DeckEmpty");
 }

 void reshuffle(List<Card> texts)
    {
        for (int t = 0; t < texts.Count; t++ )
        {
            Card tmp = texts[t];
            int r = UnityEngine.Random.Range(t, texts.Count);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }

 public void updateCardsShown(){
    //instanciate in hand and discard
    //for each card in hand, instanciate
    foreach(Transform child in handPlace.transform)
    {
        Destroy(child.gameObject);
    }
    foreach(Transform child in discardPlace.transform)
    {
        Destroy(child.gameObject);
    }
    
    foreach(Card card in _hand){
        
        Instantiate(card.GetGameObject(), handPlace);
    }

    int discardTopNum = _discard.Count - 1;
    if (_discard.Count > 0){
        Instantiate(_discard[discardTopNum].GetGameObject(), discardPlace);
        }
 }

 public List<Card> getHand(){
    return _hand;
 }
 

 public void Update()
 {
    
    numCardsText.text = _deck.Count.ToString();

        if(Input.GetKeyDown(KeyCode.P)){
            discardCard(_hand[0]);
        }
        if(Input.GetKeyDown(KeyCode.L)){
            Draw();
        }
        if(Input.GetKeyDown(KeyCode.M)){
            //deckEmpty();
        }

  Console.WriteLine("Player card");
  String line = Console.ReadLine();
  
  //if (checkHandEmpty()) { Draw(); }

  if (checkActive() == 1 && Input.GetKeyDown(KeyCode.Mouse0)) { playCard(_hand[0]); }
  else if (checkActive() == 2 && Input.GetKeyDown(KeyCode.Mouse0)) { playCard(_hand[1]); }
  else if (checkActive() == 3 && Input.GetKeyDown(KeyCode.Mouse0)) { playCard(_hand[2]); }
  
 }
}


