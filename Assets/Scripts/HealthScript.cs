
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int normalHeartNum = 5; //maximum number of normal hearts
    public int health; //current health
    private int healthPerHeart = 2; //amount of health per heart (ex heart is halves there are 2)
    
    public Image[] hearts; //heart images stored here
    public Sprite[] sprites; //heart sprites
    //set this to the amount of normal hearts the player will have
    void Start() {
        health = normalHeartNum*healthPerHeart;
        hearts = new Image[normalHeartNum];
        checkHealthAmount();
    }

    void checkHealthAmount() {
        for (int i=0;i<hearts.Length;i++)
        {
            hearts[i] = new GameObject().AddComponent<Image>();
            hearts[i].sprite = sprites[0];
            hearts[i].enabled = true;
        }
    }

   //=void addHeart(int num) { //adds specified number of heart sprites to list
        
   //}

   /* void updateHearts() {
        foreach (Image heart in hearts)
        {
            heart.sprite = sprites[0];
        }
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
}
