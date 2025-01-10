using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.ShaderGraph.Internal;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class playerMove : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 8f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private float dodgeDelay = 0.1f;
    private float timer = 0f;
    private bool dodgeOnCooldown;

   // [SerializeField] private float dodgeSpeed = 21f;
   
    

    
    bool isMoving = false;
    public Animator animator;
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
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
        
        angle();
        

        
    }

    

    public void angle()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("moving", true);
            animator.SetTrigger("north");
        }
        if (Input.GetKeyDown(KeyCode.W) & Input.GetKey(KeyCode.D))
        {
            animator.SetBool("moving", true);
            animator.SetTrigger("northeast");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("moving", true);
            animator.SetTrigger("east");
        }
        if (Input.GetKeyDown(KeyCode.D) & Input.GetKey(KeyCode.S))
        {
            animator.SetBool("moving", true);
            animator.SetTrigger("southeast");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("moving", true);
            animator.SetTrigger("south");
        }
        if (Input.GetKeyDown(KeyCode.S) & Input.GetKey(KeyCode.A))
        {
            animator.SetBool("moving", true);
            animator.SetTrigger("southwest");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("moving", true);
            animator.SetTrigger("west"); 
        }
        if (Input.GetKeyDown(KeyCode.A) & Input.GetKey(KeyCode.W))
        {
            animator.SetBool("moving", true);
            animator.SetTrigger("northwest");
        }
    }
    

    void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
     //   east = !east;
    }

    void Dodge(){
        Debug.Log("Left Shift key was released");
        
        movementSpeed = 30;
        dodgeOnCooldown = true;
        
    }
}
