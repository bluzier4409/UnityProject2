using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerHealth : MonoBehaviour
{
    [SerializeField]private int health = 10;

    private HealthScript healthScript;



    void Start()
    {
        healthScript = GetComponent<HealthScript>();
        if(!healthScript) Debug.LogError("HealthScript does not exist");
        if(!healthScript.setHealth(health)) Debug.LogError("Health could not be set");


    }

    void Update()
    {
        
       

    }

    public void Damage(int amount){
        if(amount < 0){
            throw new System.ArgumentOutOfRangeException("Cannont have negative damage");
        }

        this.health -= amount;
        healthScript.changeHealth((-1* amount));

        if(health < 1){
            playerDie();
        }
    }

    public void Heal(int amount){
        if(amount < 0){
            throw new System.ArgumentOutOfRangeException("Cannont have negative healing");
        }

        this.health += amount;
        healthScript.changeHealth(amount);
    }

    private void playerDie(){
        Debug.Log("you died");
        Destroy(this.gameObject);
    }
}
