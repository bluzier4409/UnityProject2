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

 public GameObject[] cardAbilitiesPrefabs;

public RectTransform handPlace;
public RectTransform deckPlace;
public RectTransform discardPlace;
public Camera cam;

    public void Start()
    {
        numCardsText.text = _deck.Count.ToString();


        Card A = new Card("A", "Melee", false, false, cardPrefabs[0], cardAbilitiesPrefabs[0]);
        _deck.Add(A);
        Card B = new Card("B", "Ranged", false, false, cardPrefabs[1]);
        _deck.Add(B);
        Card C = new Card("C", "Consumable", false, false, cardPrefabs[2]);
        _deck.Add(C);
        Card D = new Card("D", "Melee", false, false, cardPrefabs[3]);
        _deck.Add(D);
        Card E = new Card("E", "Ranged", false, false, cardPrefabs[4]);
        _deck.Add(E);
        Card F = new Card("F", "Ranged", false, false, cardPrefabs[5]);
        _deck.Add(F);
        Card G = new Card("G", "Ranged", false, false, cardPrefabs[1]);
        _deck.Add(G);

        _deck.Add(G);

       

        


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
  _discard.Add(card);
  _hand.Remove(card);
  
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

  discardCard(card);

   Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
   Instantiate(card.GetAbilityObject(),mousePos,Quaternion.identity);
 }

 public int whatIsActive(){
    if (_hand.Count >= 1 && _hand[0].GetActiveStatus() == true){
        return 0;
    }
    else if (_hand.Count >= 2 && _hand[1].GetActiveStatus() == true){
        return 1;
    }
    else if (_hand.Count >= 3 && _hand[2].GetActiveStatus() == true){
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
    checkActive();

        if(Input.GetKeyDown(KeyCode.P)){
            discardCard(_hand[1]);
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

  if (whatIsActive() == 0 && Input.GetKeyDown(KeyCode.Mouse0)) { playCard(_hand[0]); }
  else if (whatIsActive() == 1 && Input.GetKeyDown(KeyCode.Mouse0)) { playCard(_hand[1]); }
  else if (whatIsActive() == 2 && Input.GetKeyDown(KeyCode.Mouse0)) { playCard(_hand[2]); }
  
 }
}


