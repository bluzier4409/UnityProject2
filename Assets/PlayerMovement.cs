using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

private float horizontalInput = 0;
private float verticalInput = 0;
public int movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
    }
    
    private void GetPlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = verticalInput.GetAxisRaw("Vertical");
    }

    private void MovePlayer(){
        Vector3 directionVector = new Vector3(horizontalInput, verticalInput, 0;)
        transform.translate(directionVector.normalized * Time.deltaTime * movementSpeed);
    }
}
