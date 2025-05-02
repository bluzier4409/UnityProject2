using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBullet : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] private float speed = 75f;

    [Range(1, 10)]
    [SerializeField] private float lifeTime = 3f;

    private Rigidbody2D rb;
    

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
        rb.velocity = transform.up * speed;
    }

    
}
