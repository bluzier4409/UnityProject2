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
   
    
    bool north = false;
    bool northeast = false;
    bool east = false;
    bool southeast = false;
    bool south = false;
    bool southwest = false;
    bool west = false;
    bool northwest = false;
    
    bool isMoving = false;
    
    

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
        Vector2 basevec = new Vector2(0, 1);
        float angle = Vector2.SignedAngle(basevec, movementDirection);


        if (movementDirection.x> 0 && !east){
            Flip();
        }
        else if (movementDirection.x < 0 && east){
            Flip();
        }
    }

    void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        east = !east;
    }

    void Dodge(){
        Debug.Log("Left Shift key was released");
        
        movementSpeed = 30;
        dodgeOnCooldown = true;
        
    }
}
