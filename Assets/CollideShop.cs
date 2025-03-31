using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideShop : MonoBehaviour {
    Transform theTransform  = null;
    ShowHidePressE theScript = null;
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collided With Shop");
        GameObject collidedObject = other.gameObject;
        Transform pressETransform = collidedObject.transform.Find("PressE");
        theTransform=pressETransform;
        
        if (pressETransform != null) {
            // Get the ShowHidePressE script attached to the PressE object
            ShowHidePressE pressEScript = pressETransform.GetComponent<ShowHidePressE>();
            theScript =  pressEScript;
            if (pressEScript != null) {
                // Call a function from the ShowHidePressE script
                pressEScript.Show();
                pressEScript.SetPlayerInRange(true);
                Debug.Log("Setting True");
                // or you can call any other function you need from ShowHidePressE
            } else {
                Debug.LogWarning("ShowHidePressE script not found on PressE object.");
            }
        } else {
            Debug.LogWarning("PressE object not found on collided object.");
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("TriggerExit");
        GameObject collidedObject = other.gameObject;
        Transform pressETransform = collidedObject.transform.Find("PressE");

        ShowHidePressE pressEScript = theTransform.GetComponent<ShowHidePressE>();
        //theScript.HidePurchase();
        if(theScript) Debug.Log("Exists");
        //pressEScript.HidePurchase();

        // Find the PressE object within the collided object (which should be the player prefab)
        

        if (pressETransform != null) {
            // Get the ShowHidePressE script attached to PressE
            //ShowHidePressE pressEScript = pressETransform.GetComponent<ShowHidePressE>();

            if (pressEScript != null) {
                // Hide the "PressE" when leaving the shop area
                pressEScript.HidePurchase();
                Debug.Log("Setting False");
                pressEScript.SetPlayerInRange(false);
                theScript.SetPlayerInRange(false);
            }
        }
    }
}
