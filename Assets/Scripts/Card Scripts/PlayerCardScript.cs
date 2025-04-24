using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCardScript : MonoBehaviour
{

public Text numCardsText;

 private List<Card> _deck = new List<Card>();
 private List<Card> _discard = new List<Card>();

  private List<Card> _tempList = new List<Card>();


 //max hand size 3
 private List<Card> _hand = new List<Card>();
 public GameObject[] cardPrefabs; // 1.Deck 2.Discard 3.Type1

 public GameObject[] cardAbilitiesPrefabs;

public RectTransform handPlace;
public RectTransform deckPlace;
public RectTransform discardPlace;
public Camera cam;

public playerAttack atk;

[SerializeField] public GameObject player;
[SerializeField] public GameObject ricochetBullet;
[SerializeField] public Camera camera;
    public void Awake()
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
        Card G = new Card("G", "Ranged", false, false, cardPrefabs[1]);
        Card E = new Card("E", "Ranged", false, false, cardPrefabs[4]);
        _deck.Add(E);
        Card F = new Card("F", "Ranged", false, false, cardPrefabs[5]);
        _deck.Add(F);
        _deck.Add(G);
        Card RicochetBullet = new Card("Ricochet Bullet", "Bullet Replacer", false, false, cardPrefabs[6], ricochetBullet, 5f);
        _deck.Add(RicochetBullet);
        Card teleportCard = new Card("Teleport", "Teleport", false, false, cardPrefabs[7]);
        _deck.Add(teleportCard);

        _deck.Add(G);

       

        


        Draw();
        
        


        
    }

public void Draw()
{
    // Draw until hand has 3 cards or deck is empty
    if (_hand.Count == 0)
    {
        if (_deck.Count < 3)
        {
            deckEmpty();  // If deck is empty, reshuffle the discard pile back into the deck
        }

        // Draw 3 cards from the deck to the hand
        for (int i = 0; i < 3; i++)
        {
            if (_deck.Count > 0)
            {
                Card drawnCard = _deck[0];
                _deck.RemoveAt(0);  // Remove the card from the deck
                _hand.Add(drawnCard);  // Add the card to the hand
            }
        }

        Debug.Log("Hand after drawing cards:");
        foreach (Card card in _hand)
        {
            Debug.Log(card.getName());
        }

        updateCardsShown();  // Update the UI (or internal tracking) of cards
    }
}


public void discardCard(int whereInHandNum)
{
    /*if (!_hand.Contains(card))
    {
        Debug.LogWarning("Card not found in hand!");
        return;
    }

    Debug.Log("Discarding card: " + card.getName());
        
    Card K = new Card("K", "Ranged", false, false, cardPrefabs[5]);

//find index next class
    bool removed = _hand.Remove(card);
    _tempList.Add(card);

    if (removed){
        Debug.Log("Card removed from hand successfully.");
    }
    else{
        Debug.LogError("Failed to remove card from hand.");
    }
    

    _discard.Add(card);*/


Debug.Log("Discarding card: " + _hand[whereInHandNum].getName());

_hand[whereInHandNum].SetActiveStatus(false);

_discard.Add(_hand[whereInHandNum]);
_hand.RemoveAt(whereInHandNum);



    if (_hand.Count == 0)
    {
        Debug.Log("Hand is empty, drawing new cards...");
        Draw(); 
    }

    Debug.Log("Updated Hand: ");
    foreach (Card handCard in _hand)
    {
        Debug.Log(handCard.getName());
    }

    Debug.Log("Updated Discard Pile: ");
    foreach (Card discardCard in _discard)
    {
        Debug.Log(discardCard.getName());
    }
    

    updateCardsShown();
    
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

 public void playCard(int placeInHandNum)
 {

    Card card = _hand[placeInHandNum];
  Debug.Log("Playing card: "+ card.ToString());

  discardCard(placeInHandNum);
  

  if (card.getType().Equals("Bullet Replacer"))
  {
      playBulletReplacer(card);
  } 
  
  if (card.getType().Equals("Teleport"))
  {
      playTeleport(card);
  } 
  
      //Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
      //Instantiate(card.GetAbilityObject(),mousePos,Quaternion.identity);
  
 }

 public void playBulletReplacer(Card card)
 {
     if (card.GetAbilityObject() != null)
     {
         playerAttack attack = player.GetComponent<playerAttack>();
         GameObject ogBullet = attack.getBulletType();
         StartCoroutine(ReplaceBullet(attack, ogBullet, card.GetAbilityObject(), card.getLifespan()));
     }
 }

 public void playTeleport(Card card)
 {
     Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
     player.transform.position = mousePos;
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

 public void deckEmpty()
{
    // Move all cards from discard pile to deck
    foreach (Card card in _discard.ToArray())
    {
        _deck.Add(card);
        _discard.Remove(card);
    }

    // Shuffle the deck
    reshuffle(_deck);

    // Log the deck and discard pile
    Debug.Log("Deck after emptying:");
    foreach (Card card in _deck)
    {
        Debug.Log(card.getName());
    }

    Debug.Log("Discard Pile after moving cards to deck:");
    foreach (Card card in _discard)
    {
        Debug.Log(card.getName());
    }

    updateCardsShown();  // Update the UI or internal tracking
}

void reshuffle(List<Card> deck)
{
    for (int i = 0; i < deck.Count; i++)
    {
        Card tmp = deck[i];
        int r = UnityEngine.Random.Range(i, deck.Count);
        deck[i] = deck[r];
        deck[r] = tmp;
    }
}


 public void updateCardsShown(){
    //instantiate in hand and discard
    //for each card in hand, instantiate
    foreach(Transform child in handPlace.transform)
    {
        Destroy(child.gameObject);
    }
    foreach(Transform child in discardPlace.transform)
    {
        Destroy(child.gameObject);
    }
    
    foreach(Card card in _hand)
    {
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
            discardCard(1);
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

  if (whatIsActive() == 0 && Input.GetKeyDown(KeyCode.Mouse0)) { playCard(0); }
  else if (whatIsActive() == 1 && Input.GetKeyDown(KeyCode.Mouse0)) { playCard(1); }
  else if (whatIsActive() == 2 && Input.GetKeyDown(KeyCode.Mouse0)) { playCard(2); }
  
 }

 private IEnumerator<WaitForSeconds> ReplaceBullet(playerAttack attack, GameObject originalbullet, GameObject newbullet, float duration)
 {
     attack.setBulletType(newbullet);
     
     yield return new WaitForSeconds(duration);
     
     attack.setBulletType(originalbullet);
 }
}


