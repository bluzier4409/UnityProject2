using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvintory : MonoBehaviour
{
    private int numKeysHeld = 0;

    public void giveKey(){
        numKeysHeld++;
        Debug.Log("You now have "+ numKeysHeld+" keys.");
    }
    public int GetNumKeysHeld(){
        return numKeysHeld;
    }
}
