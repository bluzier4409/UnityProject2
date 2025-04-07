using UnityEngine;

public class CollideShop : MonoBehaviour {
    private ShowHidePressE pressEScript;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collided With Shop");

        Transform pressETransform = other.transform.Find("PressE");
        if (pressETransform != null) {
            pressEScript = pressETransform.GetComponent<ShowHidePressE>();
            if (pressEScript != null) {
                pressEScript.ShowPressE();
                pressEScript.SetPlayerInRange(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (pressEScript != null) {
            pressEScript.SetPlayerInRange(false);
        }
    }
}
