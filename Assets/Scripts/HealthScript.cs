//ask mandell do not forgor!
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int normalHeartNum = 3; //maximum number of normal hearts
    public int health; //current health
    private int healthPerHeart = 2; //amount of health per heart (ex heart is halves there are 2)
    
    public Image[] hearts; //heart images stored here
    public Sprite[] sprites; //heart sprites
    //set this to the amount of normal hearts the player will have
    void Start() {
        health = normalHeartNum*healthPerHeart;
    }

    void checkHealthAmount() {
        for (int i=0;i<normalHeartNum;i++) {
            hearts[i].enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
