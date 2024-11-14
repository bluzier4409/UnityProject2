using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    [SerializeField]private int health = 10;


    void Start()
    {
        
    }

    void Update()
    {
        
       

    }

    public void Damage(int amount){
        if(amount < 0){
            throw new System.ArgumentOutOfRangeException("Cannont have negative damage");
        }

        this.health -= amount;

        if(health < 1){
            playerDie();
        }
    }

    public void Heal(int amount){
        if(amount < 0){
            throw new System.ArgumentOutOfRangeException("Cannont have negative healing");
        }

        this.health += amount;
    }

    private void playerDie(){
        Debug.Log("you died");
        Destroy(this.gameObject);
    }
}
