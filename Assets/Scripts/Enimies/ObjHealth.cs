using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjHealth : MonoBehaviour
{

    [SerializeField]private int health = 10;

    private GameObject deadCheck;


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
        Debug.Log("object died");
        Destroy(this.gameObject);
        SceneManager.LoadScene (sceneName:"DEMO 2");

        LVLswap swap = GameObject.Find("swaper").GetComponent<LVLswap>();
        swap.addToDead();
    }
}
