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
            rb.AddForce(rb.transform.up * 500, ForceMode2D.Impulse);
        }
    }
}
