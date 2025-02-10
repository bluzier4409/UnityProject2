using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Slider : MonoBehaviour
{   
    [SerializeField] private TextMeshProUGUI sliderText;

    [SerializeField] private float maxSliderValue = 100.0f;
    // Start is called before the first frame update

    public void SliderChange(float value) {
        float localValue = value * maxSliderValue;
        sliderText.text = localValue.ToString("0.00");

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
