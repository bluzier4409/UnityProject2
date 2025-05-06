using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjHealth : MonoBehaviour
{

    [SerializeField]private int health = 10;

    private GameObject deadCheck;
        public SpriteRenderer spriteRend;



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
        Debug.Log("damage: " +  health.ToString());
        if(health < 1){
            die();
        }
        else{{StartCoroutine(colorWhenHit());}
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

  
    }

    IEnumerator colorWhenHit(){
        Debug.Log("set color red");
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRend.color = Color.white;

    }

}
