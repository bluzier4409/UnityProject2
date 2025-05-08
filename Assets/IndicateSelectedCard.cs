using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.Mathematics;
using UnityEngine;

public class indicateSelectedCard : MonoBehaviour
{
   public GameObject layout;
   public GameObject manager;
   private Transform cardToMove;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*private void indicate(int keyNum){
        PlayerCardScript allCards = this.GetComponent<PlayerCardScript>();
        List<Card> tempHand = allCards.getHand();
        foreach(Card card in tempHand){
            if (card.GetActiveStatus() == true){
                
                }
                else{
                    card
                }
            }
            
        
        //goBackDown(keyNum);
    }*/

    public void indicate(int keyNum, Card card){
        if (card.getIndicated() == false){
            card.setIndicated(true);
            cardToMove = layout.gameObject.transform.GetChild(keyNum);
            cardToMove.Translate(0, (float)0.5, 0);
        }
        else return;
        
    }
    public void goBackDown(int keyNum, Card card){
        if (card.getIndicated() == true){
            card.setIndicated(false);
            cardToMove = layout.gameObject.transform.GetChild(keyNum);
            cardToMove.Translate(0, (float)-0.5, 0);
        }
        else return;
        
    }

    //for each card in hand, if card is active, goBackDown(that Card)
    //indicate(Key Pressed), and set it active
}
