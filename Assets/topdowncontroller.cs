using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;
using DebugLog = UnityEngine.Debug;


public class topdowncontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
   
    public List<Sprite> nSprites;
    public List<Sprite> neSprites;
    public List<Sprite> eSprites;
    public List<Sprite> seSprites;
    public List<Sprite> sSprites;
    
    public float walkSpeed;
    public float frameRate;
    float idleTime;
    
    Vector2 direction;

    public LayerMask wall;
    
    
    void Update()
    {
        flip();
        dodgeroll();
        teleport();
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.velocity = (direction * walkSpeed);
        if (rb.velocity.magnitude > 0)
        { 
            setSprite();
        }
        else
        {
            List<Sprite> idleSprite = GetSpriteDirection();
            sr.sprite = idleSprite[0];
        }
       
    }
    
    void setSprite() 
    {
        List<Sprite> directionSprites = GetSpriteDirection();
        if (directionSprites != null)
        {
            float playTime = Time.time - idleTime;
            int totalFrames = (int) (playTime * frameRate);
            int frame = totalFrames % directionSprites.Count;
            sr.sprite = directionSprites[frame];
        }
        else
        {
            idleTime = Time.time;
        }
    }

    void flip()
    {
        if (!sr.flipX && direction.x < 0)
        {
            sr.flipX = true;
        } else if (sr.flipX && direction.x > 0)
        {
            sr.flipX = false;
        }
    }

    [ItemCanBeNull]
    List<Sprite> GetSpriteDirection()
    {
        List<Sprite> selectedSprites = null;
        
        if (direction.y > 0)
        {
            if (Mathf.Abs(direction.x) > 0)
            {
                selectedSprites = neSprites;
            }
            else
            {
                selectedSprites = nSprites;
            }
        } else if (direction.y < 0)
        {
            if (Mathf.Abs(direction.x) > 0)
            {
                selectedSprites = seSprites;
            }
            else
            {
                selectedSprites = sSprites;
            }
        }
        else
        {
            selectedSprites = eSprites;
        }
        return selectedSprites;
    }

    void dodgeroll()
    {
        print(direction.x);
        print(direction.y);
        Vector2 dodgerollDist = new Vector2(2f * Math.Sign(direction.x), 2f * Math.Sign(direction.y));
        Debug.DrawRay(transform.position, dodgerollDist, Color.red);
        if (Input.GetMouseButtonDown(1))
        {
            bool raycast = Physics2D.Raycast(transform.position, dodgerollDist, dodgerollDist.magnitude, wall);
            if (!raycast)
            {
                transform.position = dodgerollDist.normalized;
            }
        }
    }

    void teleport()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Vector2 pos = Input.mousePosition;
            transform.position = pos;
        }
    }
}
