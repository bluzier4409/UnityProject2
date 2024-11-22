using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver() {
        gameOverUI.SetActive(true); 
        Image panelImage = gameOverUI.GetComponent<Image>();
        animation(panelImage);
        
    }
    private void animation(Image imgf) {
    
        float fadeDuration = 5f; // Duration of the fade effect
        Color currentColor = imgf.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration); // Gradually increase alpha
            imgf.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha); // Set the new alpha
        }

        imgf.color = new Color(currentColor.r, currentColor.g, currentColor.b, 1f); // Ensure fully opaque at the end

    }
}
