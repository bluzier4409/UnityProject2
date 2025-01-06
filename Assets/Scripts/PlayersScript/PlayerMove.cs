using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph.Internal;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 8f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private float dodgeDelay = 0.1f;
    private float timer = 0f;
    private bool dodgeOnCooldown;

   // [SerializeField] private float dodgeSpeed = 21f;


    bool facingRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = movementDirection * movementSpeed;

        if(dodgeOnCooldown){
            timer += Time.deltaTime;

            if(timer >= dodgeDelay){
                timer = 0;
                movementSpeed = 8;
                dodgeOnCooldown = false;
                // iFrames
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && dodgeOnCooldown == false){
            Dodge();
        }

    }

    void FixedUpdate() {


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

    void Dodge(){
        Debug.Log("Left Shift key was released");
        
        movementSpeed = 30;
        dodgeOnCooldown = true;
        
    }
}
