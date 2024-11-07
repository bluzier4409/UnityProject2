
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int normalHeartNum = 5; //maximum number of normal hearts
    private int healthPerHeart = 2; //amount of health per heart (ex heart is halves there are 2)
    public int health; //current health
    

    public Image heartBar;
    public Image[] hearts; //heart images stored here
    public Sprite[] sprites; //heart sprites
    //set this to the amount of normal hearts the player will have
    void Start()
    {
        Debug.unityLogger.Log("HealthScript");
        health = normalHeartNum*healthPerHeart;
        
        createHearts(5);
        setHealth(9);
    }

    void createHearts(int num) { //create the number of heart images desired
        hearts = new Image[num];
        for (int i=0;i<hearts.Length;i++)
        {
            Debug.unityLogger.Log("new heart number " + i);
            hearts[i] = new GameObject("Heart " + i).AddComponent<Image>();
            hearts[i].sprite = sprites[0];
            hearts[i].transform.SetParent(heartBar.transform, false); 
            hearts[i].GetComponent<RectTransform>().sizeDelta = new Vector2(37, 37);
            hearts[i].preserveAspect = true;
            hearts[i].enabled = true;
        }
    }

    void setHealth(int num) { //hearts are automatically created for health value; each value = half heart
        if (hearts.Length != (int)(num / 2) + 1) {
            createHearts((num/2)+1);
        } ; //check if correct amount of hearts available
        if (num % 2 != 0) {
            hearts[num/2].sprite = sprites[1];
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
