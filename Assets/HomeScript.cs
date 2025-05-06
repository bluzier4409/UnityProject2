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
            Vector2 direction = other.transform.position - transform.position;
            rb.velocity = Vector2.zero;
            rb.AddForce(direction * 3, ForceMode2D.Impulse);
        }
    }
}
