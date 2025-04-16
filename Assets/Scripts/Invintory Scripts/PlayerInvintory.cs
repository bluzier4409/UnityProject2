using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInvintory : MonoBehaviour
{

    private int numKeysHeld = 0;
    public Text keyText;

    private int numCoinsHeld = 200;
    public Text coinsText;

    public int itemOneLeft = 2;
    public int itemTwoLeft = 2;

    void Start(){
        keyText.text = numKeysHeld.ToString();
        coinsText.text = numCoinsHeld.ToString();
    }

    void Update(){
       // keyText.text = numKeysHeld.ToString();
        //coinsText.text = numCoinsHeld.ToString();

    }

    public void giveKey(){
        numKeysHeld++;
        Debug.Log("You now have "+ numKeysHeld+" keys.");
        UpdateUI();
    }

    public void giveKey(int num){
        numKeysHeld += num;
        UpdateUI();
        Debug.Log("You now have " + numKeysHeld + " keys.");
        UpdateUI();

    }
    public int GetNumKeysHeld(){
        return numKeysHeld;
    }

    private void UpdateUI()
    {
        keyText.text = numKeysHeld.ToString();
        coinsText.text = numCoinsHeld.ToString();
    }

    public void giveCoin(int amount){
        numCoinsHeld += amount;
        Debug.Log("You now have "+ numCoinsHeld+" coin.");
                UpdateUI();

    }
    public int getnumCoinsHeld(){
        return numCoinsHeld;
    }

    public void setCoin(int num){
        numCoinsHeld = num;
        keyText.text = numKeysHeld.ToString();
        coinsText.text = num.ToString();
        Debug.Log("Setcoin" + num);
                UpdateUI();

    }

    public void useKey(){
        if (numKeysHeld > 0){
            numKeysHeld--;
            Debug.Log("You now have " + numKeysHeld+ " keys.");
        }
        else{
            Debug.Log("You have no keys to use");
        }
                UpdateUI();

    }
}
