using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class openChest : MonoBehaviour
{
    // Start is called before the first frame update
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
                
            }
            else if (checkNum < 1){
                Debug.Log("Go find a key to use!");
                
                
            }
        }
        
    }


}
