using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class openChest : MonoBehaviour
{
    public Sprite OpenChest;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name.Equals("mainChar"))
        {
            Debug.Log("chest touch");
            PlayerInvintory invintory = collider.GetComponentInChildren<PlayerInvintory>();
            int checkNum = invintory.GetNumKeysHeld();
            
            if (checkNum >= 1){
                Debug.Log("Using 1 key");
                invintory.useKey();
                this.gameObject.GetComponent<SpriteRenderer>().sprite = OpenChest;
                giveReward(collider);
                
            }
            else if (checkNum < 1){
                Debug.Log("Go find a key to use!");
                
                
            }
        }
        
    }

    private void giveReward(Collider2D collider){
        //impliment giving stuff here, coins just for now
        PlayerInvintory invintory = collider.GetComponentInChildren<PlayerInvintory>();
        invintory.giveCoin(35);
    }

}
