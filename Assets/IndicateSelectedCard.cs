using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicateSelectedCard : MonoBehaviour
{
   public GameObject layout;
   private Transform cardToMove;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            StartCoroutine(indicate(0));
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)){
            StartCoroutine(indicate(1));
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3)){
            StartCoroutine(indicate(2));
        }
    }

    IEnumerator indicate(int keyNum){
        cardToMove = layout.gameObject.transform.GetChild(keyNum);
        cardToMove.Translate(0, (float)0.5, 0);
        yield return new WaitForSeconds(2);
        goBackDown(keyNum);
    }
    private void goBackDown(int keyNum){
        cardToMove = layout.gameObject.transform.GetChild(keyNum);
        cardToMove.Translate(0, (float)-0.5, 0);
    }
}
