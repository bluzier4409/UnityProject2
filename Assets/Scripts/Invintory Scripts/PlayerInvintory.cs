using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInvintory : MonoBehaviour
{

    private int numKeysHeld = 0;
    public Text keyText;

    private int numCoinsHeld = 0;
    public Text coinsText;

    void Start(){
        keyText.text = numKeysHeld.ToString();
        coinsText.text = numCoinsHeld.ToString();
    }

    void Update(){
        keyText.text = numKeysHeld.ToString();
        coinsText.text = numCoinsHeld.ToString();

    }

    public void giveKey(){
        numKeysHeld++;
        Debug.Log("You now have "+ numKeysHeld+" keys.");
    }
    public int GetNumKeysHeld(){
        return numKeysHeld;
    }
    public void giveCoin(int amount){
        numCoinsHeld += amount;
        Debug.Log("You now have "+ numCoinsHeld+" keys.");
    }
    public int getnumCoinsHeld(){
        return numCoinsHeld;
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
