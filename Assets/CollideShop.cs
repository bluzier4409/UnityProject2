using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideShop : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collided With Shop");
        GameObject collidedObject = other.gameObject;
        Transform pressETransform = collidedObject.transform.Find("PressE");
    
        if (pressETransform != null) {
            // Get the ShowHidePressE script attached to the PressE object
            ShowHidePressE pressEScript = pressETransform.GetComponent<ShowHidePressE>();

            if (pressEScript != null) {
                // Call a function from the ShowHidePressE script
                pressEScript.Show();
                Debug.Log("Found");
                // or you can call any other function you need from ShowHidePressE
            } else {
                Debug.LogWarning("ShowHidePressE script not found on PressE object.");
            }
        } else {
            Debug.LogWarning("PressE object not found on collided object.");
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        GameObject collidedObject = other.gameObject;

        // Find the PressE object within the collided object (which should be the player prefab)
        Transform pressETransform = collidedObject.transform.Find("PressE");

        if (pressETransform != null) {
            // Get the ShowHidePressE script attached to PressE
            ShowHidePressE pressEScript = pressETransform.GetComponent<ShowHidePressE>();

            if (pressEScript != null) {
                // Hide the "PressE" when leaving the shop area
                pressEScript.Hide();
            }
        }
    }
}
