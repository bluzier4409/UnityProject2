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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(this.gameObject);
        Debug.Log("OAIOJDAIOFSDIOFOIJSDFIJ");
      if(collider.GetComponent<ObjHealth>() != null)
        {
            
            Debug.Log("hit");
            StartCoroutine(FreezeForSeconds(collider, freezeTime));
            ObjHealth health = collider.GetComponent<ObjHealth>();
            health.Damage(bulletDammage);
            
        }

        if (collider.IsTouchingLayers(LayerMask.GetMask("walls")))
        {
            Debug.Log("hit");
        }
    
      
      
    }

    private IEnumerator<WaitForSeconds> FreezeForSeconds(Collider2D collidedObj, float freezeTime)
    {
        Rigidbody2D frozenRb = collidedObj.GetComponent<Rigidbody2D>();

        frozenRb.constraints = RigidbodyConstraints2D.FreezePosition;
        
        yield return new WaitForSeconds(freezeTime);
        
        frozenRb.constraints = ~RigidbodyConstraints2D.FreezePosition;
    }
}
