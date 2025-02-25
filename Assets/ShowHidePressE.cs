using UnityEngine;

public class ShowHidePressE : MonoBehaviour {
    public GameObject pressEObject;  // Reference to the PressE object

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
        }
    }
}