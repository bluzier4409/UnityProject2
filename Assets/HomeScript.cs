using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HomeScript : MonoBehaviour
{
    [SerializeField] public HomeBullet homingScript;

    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<ObjHealth>() != null)
        {
            rb = homingScript.GetComponent<Rigidbody2D>();
            Debug.Log(rb);
            Vector2 direction = other.transform.position - rb.transform.position;
            rb.velocity = Vector2.zero;
            float angle = MathF.Atan2(direction.y - transform.position.y, direction.x - transform.position.x) * Mathf.Rad2Deg - 90f;
            rb.transform.rotation = Quaternion.Euler(0,0, angle);
            rb.AddForce(direction * 3, ForceMode2D.Impulse);
        }
    }
    
    
}
