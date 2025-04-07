using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberController : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public TextMeshProUGUI moneyText;
    
    private PlayerInvintory Inventory;
    

    private void Start(){
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null){
            Inventory = player.GetComponent<PlayerInvintory>();
        }
    }

    public void IncreaseNumber(int itemNum) {
        int maxNum = 0;
        int itemPrice = 0;
        if(itemNum==2) maxNum = Inventory.itemOneLeft;
        if(itemNum==1) maxNum = Inventory.itemTwoLeft;

        if(itemNum==1) itemPrice = 80;
        if(itemNum==2) itemPrice = 50;


        if (Inventory == null) return; 

        int currentBalance = Inventory.getnumCoinsHeld(); 
        int currentNumber = int.Parse(numberText.text);
        currentNumber++;

        if (currentNumber != 5){
            UpdateNumberText(currentNumber);
            int money = currentBalance - itemPrice; 
            moneyText.text = "$" + money;
            Inventory.setCoin(money);
            if (money < 0)
                moneyText.color = Color.red;
            else
                moneyText.color = Color.green;
        }
        else 
            currentNumber = 2;
            


    }

    public void DecreaseNumber(int itemPrice) {
        


        if (Inventory == null) return; 

        int currentBalance = Inventory.getnumCoinsHeld(); 
        int currentNumber = int.Parse(numberText.text);
        currentNumber--;

        if (currentNumber != -1){
            UpdateNumberText(currentNumber);
            int money = currentBalance + itemPrice; 
            moneyText.text = "$" + money;
            Inventory.setCoin(money);
            if (money < 0)
                moneyText.color = Color.red;
            else
                moneyText.color = Color.green;
            }
        else 
            currentNumber = 0;


    }

    private void UpdateNumberText(int num) {
        numberText.text = num.ToString();
    }
}
