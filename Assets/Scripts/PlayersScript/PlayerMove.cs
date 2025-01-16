
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph.Internal;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private float CurrentMoveSpeed;
    [SerializeField] private float startingMoveSpeed = 8f;

    private Rigidbody2D rb;
    private Vector2 movementDirection;

    private float dodgeDelay = 0.1f;
    private float timer = 0f;
    [SerializeField] private float dodgeSpeed = 30f;
    private bool dodgeOnCooldown;

    private playerHealth pHealth;



    bool facingRight = false;

    void Start()
    {
        CurrentMoveSpeed = startingMoveSpeed;

        rb = GetComponent<Rigidbody2D>();
        pHealth = GetComponent<playerHealth>();
    }

    void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = movementDirection * CurrentMoveSpeed;

        if(dodgeOnCooldown){
            timer += Time.deltaTime;

            if(timer >= dodgeDelay){
                timer = 0;
                CurrentMoveSpeed = 8;
                dodgeOnCooldown = false;
                pHealth.setInvulnerable(false);

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
        
        CurrentMoveSpeed = dodgeSpeed;
        pHealth.setInvulnerable(true);
        dodgeOnCooldown = true;
        
    }
}