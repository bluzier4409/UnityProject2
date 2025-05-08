using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] private float speed = 75f;
    [Range(1, 10)]
    [SerializeField] private float lifeTime = 3f;
    [SerializeField] private int lifeSpan= 3;
    
    [SerializeField] private float ricochetTime = 10f;
    [SerializeField] private float iceTime = 3f;
    [SerializeField] private float homingTime = 6f;

    private int bulletDammage = 1;
    
    

    private Rigidbody2D rb;

    private bool isRicochet;
    private bool isIce;
    private bool isHoming;
    

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isRicochet) Destroy(this.gameObject);
        if(collider.GetComponent<ObjHealth>() != null)
        {
            Rigidbody2D frozenRb = collider.GetComponent<Rigidbody2D>();
            ObjHealth health = collider.GetComponent<ObjHealth>();
            health.Damage(bulletDammage);
        }
    }

    public void ricochet()
    {
        
    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isRicochet)
        {
            if(collision.gameObject.tag == "Walls")
            {
                Debug.Log("hit wall");
                ContactPoint2D point = collision.contacts[0];
                Vector2 newDir = Vector2.zero;
                Vector2 curDire = this.transform.TransformDirection(Vector2.up);
                newDir = Vector2.Reflect(curDire, point.normal);
                transform.rotation = Quaternion.FromToRotation(Vector2.up, newDir);
                rb.velocity *= speed;
                lifeSpan -= 1;
            }
        }
    }

    //private IEnumerator<WaitForSeconds> RicochetTimer(float time)
   // {
        
   // }

   // private IEnumerator<WaitForSeconds> IceTimer(Rigidbody2D enemyRb, float time)
   //{
        
   // }

   // private IEnumerator<WaitForSeconds> HomingTimer(float time)
    //{
        
   // }
    
    
}
