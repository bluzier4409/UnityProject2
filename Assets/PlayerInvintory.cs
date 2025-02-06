using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInvintory : MonoBehaviour
{

    private int numKeysHeld = 0;
    public Text keyText;

    void Start(){
        keyText.text = numKeysHeld.ToString();
    }

    public void giveKey(){
        numKeysHeld++;
        Debug.Log("You now have "+ numKeysHeld+" keys.");
        keyText.text = numKeysHeld.ToString();

    }
    public int GetNumKeysHeld(){
        return numKeysHeld;
    }

    public void useKey(){
        if (numKeysHeld > 0){
            numKeysHeld--;
            Debug.Log("You now have " + numKeysHeld+ " keys.");
        }
        else{
            Debug.Log("You have no keys to use");
        }
    }
}
