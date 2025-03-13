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

        if(Input.GetKeyDown(KeyCode.Alpha1)){
            indicate(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)){
            indicate(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3)){
            indicate(2);
        }
    }

    private void indicate(int keyNum){
        if (.getHand()[keyNum].GetActiveStatus == true){}
        cardToMove = layout.gameObject.transform.GetChild(keyNum);
        cardToMove.Translate(0, (float)0.5, 0);
        goBackDown(keyNum);
    }
    private void goBackDown(int keyNum){
        cardToMove = layout.gameObject.transform.GetChild(keyNum);
        cardToMove.Translate(0, (float)-0.5, 0);
    }

    //for each card in hand, if card is active, goBackDown(that Card)
    //indicate(Key Pressed), and set it active
}
