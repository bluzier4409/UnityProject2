using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ricochetbullet : MonoBehaviour
{
   [Range(1, 100)]
   [SerializeField] private float speed = 75f;

   [Range(1, 10)]
   [SerializeField] private int lifeSpan= 3;

   private Rigidbody2D rb;

   [SerializeField] private int bulletDammage = 1;
   

   private void Start() {
    rb = GetComponent<Rigidbody2D>();
   }

   private void FixedUpdate(){
       transform.Translate(Vector2.up * Time.deltaTime * speed);
       if (lifeSpan <= 0)
       {
           Destroy(gameObject);
       }
   }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
        
      if(collider.GetComponent<ObjHealth>() != null)
        {
            Debug.Log("hit");

            ObjHealth health = collider.GetComponent<ObjHealth>();
            if (lifeSpan <= lifeSpan - 1)
            {
                health.Damage(bulletDammage * 2);
            }
            else
            {
                health.Damage(bulletDammage);
            }
            
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        if(collision.gameObject.tag == "Walls")
        {
            Debug.Log("hit wall");
            ContactPoint2D point = collision.contacts[0];
            //Vector2 pointPos = new Vector2(point.point.x, point.point.y);
            Vector2 newDir = Vector2.zero;
           // Vector2 randDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            Vector2 curDire = this.transform.TransformDirection(Vector2.up);
            
            newDir = Vector2.Reflect(curDire, point.normal);
            //Instantiate(this, newDir, Quaternion.FromToRotation(Vector2.up, randDir));
            transform.rotation = Quaternion.FromToRotation(Vector2.up, newDir);
            lifeSpan -= 1;
        }
    }
}
