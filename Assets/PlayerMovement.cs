using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

private float horizontalInput = 0;
private float verticalInput = 0;
public int movementSpeed;

Rigidbody2D rb;

bool touchesWall;
public Transform groundChecker;
public LayerMask groundMask;
public float radius;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    
        GetPlayerInput();
        MovePlayer();
        
        touchesWall = Physics2D.OverlapCircle(groundChecker.position, radius, groundMask);
    }
    
    private void GetPlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        Vector3 directionVector = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(directionVector.normalized * Time.deltaTime * movementSpeed);
        
    }
}
