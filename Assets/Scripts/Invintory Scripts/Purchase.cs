using TMPro;
using UnityEngine;

public class Purchase : MonoBehaviour
{
    public TextMeshProUGUI itemOneCountText; // Reference to Item 1 count text
    public TextMeshProUGUI itemTwoCountText; // Reference to Item 2 count text
    public TextMeshProUGUI priceText;        // Reference to price display text (to check color)
    public GameObject purchaseUI;            // Reference to the UI that disappears on purchase
    private PlayerInvintory Inventory;

    private playerHealth Health;


    private int previousItemOneCount = 0; // Stores previous count before purchase
    private int previousItemTwoCount = 0;

    private void Start(){
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null){
            Inventory = player.GetComponent<PlayerInvintory>();
            Health = player.GetComponent<playerHealth>();
        }
    }
    public void ProcessPurchase()
    {
        // Check if priceText is NOT red (i.e., player has enough money)
        if (priceText.color != Color.red)
        {
            // Store previous item counts
            previousItemOneCount = int.Parse(itemOneCountText.text);
            previousItemTwoCount = int.Parse(itemTwoCountText.text);


            //ITEM 1 = HEARTS ITEM 2 = KEYS
            Health.Heal(previousItemTwoCount*2);

            Inventory.giveKey(previousItemOneCount);



            // Calculate how many items should remain after purchase
            /*int remainingItemOne = previousItemOneCount;
            int remainingItemTwo = previousItemTwoCount;

            Inventory.itemOneLeft = Inventory.itemOneLeft - remainingItemOne;
            Inventory.itemTwoLeft = Inventory.itemTwoLeft - remainingItemTwo;

            Debug.Log(Inventory.itemOneLeft + "is left 1");
            Debug.Log(Inventory.itemTwoLeft + "is left 2");
            // Reset item counts to 0()*/
            SetItemCountToZero(itemOneCountText);
            SetItemCountToZero(itemTwoCountText);

            // Hide the UI after purchase
            if (purchaseUI != null)
                purchaseUI.SetActive(false);

        }
        else
        {
            Debug.LogWarning("Purchase failed! Not enough money.");
        }
    }

    // Helper function to reset item counts
    private void SetItemCountToZero(TextMeshProUGUI itemText)
    {
        if (itemText != null)
        {
            itemText.text = "0";
        }
    }
}
