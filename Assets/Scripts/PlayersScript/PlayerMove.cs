using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.ShaderGraph.Internal;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class playerMove : MonoBehaviour
{
    private static readonly int North = Animator.StringToHash("north");
    private static readonly int Northeast = Animator.StringToHash("northeast");
    private static readonly int East = Animator.StringToHash("east");
    private static readonly int Southeast = Animator.StringToHash("southeast");
    private static readonly int South = Animator.StringToHash("south");
    private static readonly int Southwest = Animator.StringToHash("southwest");
    private static readonly int West = Animator.StringToHash("west");
    private static readonly int Northwest = Animator.StringToHash("northwest");
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
        
        Vector2 basevec = new Vector2(0, 1);
        
        
        if (rb.velocity.magnitude > 0f)
        {
            isMoving = true;
            print("im moving");
            float moveAngle = Vector2.SignedAngle(basevec, movementDirection);
            
            

            if (moveAngle == 0f)
            {
                animator.ResetTrigger(-45);
                animator.ResetTrigger("-90");
                animator.ResetTrigger("-135");
                animator.ResetTrigger("180");
                animator.ResetTrigger("135");
                animator.ResetTrigger("90");
                animator.ResetTrigger("45");
                
                
            }
            
            float temp = moveAngle;
        }
        else
        {
            isMoving = false;
            print("im not moving");
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
