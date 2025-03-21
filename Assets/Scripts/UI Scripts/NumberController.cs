using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberController : MonoBehaviour
{
    // Reference to the TextMeshPro text that displays the number
    public TextMeshProUGUI numberText;
    public TextMeshProUGUI moneyText;
    private int itemPrice = 15;

    private int balance = 144; 
    // Start number value

    // Method to increase the number
    public void IncreaseNumber() {
        int currentNumber = int.Parse(numberText.text);
        currentNumber++;

        if (!currentNumber.Equals(3)) UpdateNumberText(currentNumber);
        else currentNumber = 2;

        int money = balance - itemPrice * currentNumber;
        moneyText.text = "$" + money;
        Debug.Log(money);
    }

    // Method to decrease the number
    public void DecreaseNumber() {
        int currentNumber = int.Parse(numberText.text);
        currentNumber--;
        
        if(!currentNumber.Equals(-1)) UpdateNumberText(currentNumber);
        else currentNumber = 0;

        int money = balance - itemPrice * currentNumber;
        moneyText.text = "$" + money;
        Debug.Log(money);
    }

    // Method to update the TextMeshPro text
    private void UpdateNumberText(int num)
    {
        numberText.text = num.ToString();
    }
}