using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
   [Range(1, 100)]
   [SerializeField] private float speed = 75f;

   [Range(1, 10)]
   [SerializeField] private float lifeTime = 3f;

   private Rigidbody2D rb;

   [SerializeField] private int bulletDammage = 1;

   private void Start() {
    rb = GetComponent<Rigidbody2D>();
    Destroy(gameObject, lifeTime);
   }

   private void FixedUpdate(){
    rb.velocity = transform.up * speed;
   }

    private void OnTriggerEnter2D(Collider2D collider){
        
        Destroy(this.gameObject);
      
      if(collider.GetComponent<ObjHealth>() != null)
        {
            Debug.Log("hit");

            ObjHealth health = collider.GetComponent<ObjHealth>();
            health.Damage(bulletDammage);
            
        }
    //  else if(collider.GetComponent<playerHealth>() != null)
     // {
     //       Debug.Log("playerHit");

    //        playerHealth pHealth = collider.GetComponent<playerHealth>();
   //         pHealth.Damage(bulletDammage);
   //   }
      
      
    }
}
