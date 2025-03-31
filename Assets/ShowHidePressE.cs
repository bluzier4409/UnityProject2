using UnityEngine;

public class ShowHidePressE : MonoBehaviour {
    public GameObject pressEObject;  // Reference to the PressE object
    public GameObject purchaseUI;  // Reference to the PressE object
    private bool isPlayerInRange = false; // Whether the player is in range to press E
    private void Start() {
        // Initially hide the object when the game starts
        Hide();
    }

    // Function to show the PressE object above the player
    public void Show() {
        if (pressEObject != null) {
            pressEObject.SetActive(true);  // Make the object visible

            // Set its position above the player
            //Vector3 newPosition = transform.position + new Vector3(0, 2, 0);  // Adjust height as needed
            //pressEObject.transform.position = newPosition;
        }
    }

    // Function to hide the PressE object
    public void Hide() {
        if (pressEObject != null) {
            pressEObject.SetActive(false);  // Make the object invisible
           //purchaseUI.SetActive(false);
        }
    }
    
    public void HidePurchase() {
        if (pressEObject != null) {
            //pressEObject.SetActive(false);  // Make the object invisible
            purchaseUI.SetActive(false);
        }
    }
    
    private void Update() {
        // Check if the player is in range and presses the "E" key
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E)) {
            // Do something when "E" is pressed while in range (e.g., interact with the shop)
            Debug.Log("E key pressed! Interacting with the shop...");
            purchaseUI.SetActive(true);
            // You can add whatever logic you want here, like triggering a shop interaction
        }
        //if (!isPlayerInRange) purchaseUI.SetActive(false);
    }
    
    public void SetPlayerInRange(bool inRange) {
        isPlayerInRange = inRange;
        Debug.Log("Player In Range: " + isPlayerInRange);
        if (inRange == false) {
            pressEObject.SetActive(false);
            purchaseUI.SetActive(false);
            Debug.Log("Setting False From PressE");
        }

        
        
        
    }
}