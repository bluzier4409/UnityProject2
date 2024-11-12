using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjHealth : MonoBehaviour
{

    [SerializeField]private int health = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       

    }

    public void Damage(int amount){
        if(amount < 0){
            throw new System.ArgumentOutOfRangeException("Cannont have negative damage");
        }

        this.health -= amount;

        if(health < 1){
            die();
        }
    }

    public void Heal(int amount){
        if(amount < 0){
            throw new System.ArgumentOutOfRangeException("Cannont have negative healing");
        }

        this.health += amount;
    }

    private void die(){
        Debug.Log("you died");
        Destroy(this.gameObject);
    }
}
