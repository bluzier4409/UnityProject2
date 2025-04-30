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
            Rigidbody2D frozenRb = collider.GetComponent<Rigidbody2D>();
            Debug.Log("hit");
            StartCoroutine(FreezeForSeconds(frozenRb, freezeTime));
            
            ObjHealth health = collider.GetComponent<ObjHealth>();
            health.Damage(bulletDammage);
            
        }

        if (collider.IsTouchingLayers(LayerMask.GetMask("walls")))
        {
            Debug.Log("hit");
        }
    
      
      
    }

    private IEnumerator<WaitForSeconds> FreezeForSeconds(Rigidbody2D frozenRb, float freezeTime)
    {
        frozenRb.constraints = RigidbodyConstraints2D.FreezePosition;
        Debug.Log("frozenRb");
        yield return new WaitForSeconds(freezeTime);
        frozenRb.constraints = RigidbodyConstraints2D.None;
        frozenRb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
