using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//use this script it works
public class playerHealth : MonoBehaviour
{
    [SerializeField]private int health = 10;

    private HealthScript healthScript;
    public GameManagerScript gameManager;
    private bool isDead = false;
    private bool invulnerable = false;

    void Start()
    {
        healthScript = GetComponent<HealthScript>();
        if(!healthScript) Debug.LogError("HealthScript does not exist");
        if(!healthScript.setHealth(health)) Debug.LogError("Health could not be set");

        invulnerable = false;
    }

    void Update()
    {
        
       

    }

    public void Damage(int amount){
        if(invulnerable){
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
        
        if (!isDead) {
            isDead = true;
            Debug.Log("you died");
            gameManager.gameOver();
            Camera playerCamera = GetComponentInChildren<Camera>();
            if (playerCamera != null)
            {
                playerCamera.transform.parent = null; // Detach the camera
            }
            Destroy(this.gameObject);
        }

    }

    public void setInvulnerable(bool mode){
        invulnerable = mode;
    }
    
}
