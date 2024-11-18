
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int startHeartNum; //maximum number of normal hearts
    //private int healthPerHeart = 2; //amount of health per heart (ex heart is halves there are 2)
    public int health; //current health
    

    public Image heartBar;
    public Image[] hearts; //heart images stored here
    public Sprite[] sprites; //heart sprites
    //set this to the amount of normal hearts the player will have
    void Start()
    {
        Debug.unityLogger.Log("HealthScript");

        setHealth(startHeartNum);
        


        // setHealth(2);

    }

    void createHearts(int num) { //create the number of heart images desired
        foreach(Image i in hearts) {
            Destroy(i.gameObject); // Destroy the GameObject
        }
        hearts = new Image[num];
        

        Debug.unityLogger.Log("create " + (num));
        for (int i=0;i<hearts.Length;i++)
        {
            //Debug.unityLogger.Log("new heart number " + i);
            hearts[i] = new GameObject("Heart " + i).AddComponent<Image>();
            hearts[i].sprite = sprites[0];
            hearts[i].transform.SetParent(heartBar.transform, false); 
            hearts[i].GetComponent<RectTransform>().sizeDelta = new Vector2(37, 37);
            hearts[i].preserveAspect = true;
            //set padding in script options
            hearts[i].enabled = true;
        }
    }

    public bool setHealth(int num) { //hearts are automatically created for health value; each value = half heart
        if (health < 0) return false;
        int heartNum;
        
        if (num % 2 == 0) heartNum = num/2;
        else heartNum = (num / 2) + 1;
        Debug.unityLogger.Log("heartNum " + (heartNum) + " " + num%2 + " " + num);

        
        
        
        if (hearts.Length != (num / 2) + 1) {
            createHearts(heartNum);
            
        } ; //check if correct amount of hearts available


        for (int i = 0; i < hearts.Length; i++) {
            hearts[i].sprite = sprites[0];
            Debug.unityLogger.Log("c " + i);
        }
        
        if (num % 2 != 0) {
            hearts[num/2].sprite = sprites[1];
        }

        health = num;
        return true;
    }

    public bool changeHealth(int num) { //change health by positive or negative num
        
        int newHealth = health + num;
        Debug.unityLogger.Log("new" + (newHealth));
        Debug.unityLogger.Log("curr" + (health));
        if (newHealth < 0) {
            return false;
        }
        return setHealth(newHealth);
        
        
    }
    
}
