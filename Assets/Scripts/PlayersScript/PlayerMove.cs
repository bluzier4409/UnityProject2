using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph.Internal;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class testmove : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 21f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;

    bool facingRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate() {
        rb.velocity = movementDirection * movementSpeed;

        if (movementDirection.x > 0 && !facingRight){
            Flip();
        }
        else if (movementDirection.x < 0 && facingRight){
            Flip();
        }
    }

    void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}
