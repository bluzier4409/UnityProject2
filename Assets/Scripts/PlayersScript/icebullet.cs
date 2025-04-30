using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class icebullet : MonoBehaviour
{
   [Range(1, 100)]
   [SerializeField] private float speed = 75f;

   [Range(1, 10)]
   [SerializeField] private float lifeTime = 3f;
   [SerializeField] private float freezeTime = 3f;

   private Rigidbody2D rb;

   [SerializeField] private int bulletDammage = 1;

   private void Start() {
    rb = GetComponent<Rigidbody2D>();
   }

   private void FixedUpdate(){
    rb.velocity = transform.up * speed;
   }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.GetComponent<ObjHealth>() != null)
        {
            rb.velocity = Vector2.zero;
            Rigidbody2D frozenRb = collider.GetComponent<Rigidbody2D>();
            Debug.Log("hit");
         
            ObjHealth health = collider.GetComponent<ObjHealth>();
            health.Damage(bulletDammage);
        }
        else Destroy(gameObject); 

        if (collider.IsTouchingLayers(LayerMask.GetMask("walls")))
        {
            Debug.Log("hit");
            Destroy(gameObject);
        }
        
      
    }

   
}
