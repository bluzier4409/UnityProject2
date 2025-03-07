using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OneNumberController : MonoBehaviour
{
    // Reference to the TextMeshPro text that displays the number
    public TextMeshProUGUI numberText;

    // Start number value

    // Method to increase the number
    public void IncreaseNumber() {
        int currentNumber = int.Parse(numberText.text);
        currentNumber++;
        if(!currentNumber.Equals(3)) UpdateNumberText(currentNumber);
    }

    // Method to decrease the number
    public void DecreaseNumber() {
        int currentNumber = int.Parse(numberText.text);
        currentNumber--;
        
        if(!currentNumber.Equals(-1)) UpdateNumberText(currentNumber);
    }

    // Method to update the TextMeshPro text
    private void UpdateNumberText(int num)
    {
        numberText.text = num.ToString();
    }
}