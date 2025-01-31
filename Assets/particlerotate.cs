using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlerotate : MonoBehaviour
{
    private Vector2 psDirection;
    
    bool isFlipped = false;
    private void Update()
    {
        psDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        flip();

        if (!isFlipped)
        {
            if (psDirection.y > 0)
            {
                if (Mathf.Abs(psDirection.x) > 0)
                {
                    //ne 
                    transform.rotation = Quaternion.Euler(45, -90, 0);
                }
                else
                {
                    //n
                    transform.rotation = Quaternion.Euler(90, -90, 0);
                }
            } else if (psDirection.y < 0)
            {
                if (Mathf.Abs(psDirection.x) > 0)
                {
                    transform.rotation = Quaternion.Euler(-45, -90, 0);
                
                }
                else
                {
                    //s
                    transform.rotation = Quaternion.Euler(-90, -90, 0);
                }
            }
            else
            {
                //e
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
        else
        {
            if (psDirection.y > 0)
            {
                if (Mathf.Abs(psDirection.x) > 0)
                {
                    //ne 
                    transform.rotation = Quaternion.Euler(45, 90, 0);
                }
                else
                {
                    //n
                    transform.rotation = Quaternion.Euler(90, 90, 0);
                }
            } else if (psDirection.y < 0)
            {
                if (Mathf.Abs(psDirection.x) > 0)
                {
                    transform.rotation = Quaternion.Euler(-45, 90, 0);
                
                }
                else
                {
                    //s
                    transform.rotation = Quaternion.Euler(-90, 90, 0);
                }
            }
            else
            {
                //e
                transform.rotation = Quaternion.Euler(0, 90, 0);
            } 
        }
        
    }
    
    public void flip()
    {
        if (!isFlipped && psDirection.x < 0)
        {
            isFlipped = true;
        } else if (isFlipped && psDirection.x > 0)
        {
           isFlipped = false;
        }
    }
}
