using System;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;



public class topdowncontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public ParticleSystem ps;
   
    public List<Sprite> nSprites;
    public List<Sprite> neSprites;
    public List<Sprite> eSprites;
    public List<Sprite> seSprites;
    public List<Sprite> sSprites;
    
    
    public float walkSpeed;
    public float frameRate;
    float idleTime;
    public float dashCD = 2f;
    
    Vector2 direction;
    private Vector2 tempDirection;

    public LayerMask wall;
    
    
    void Update()
    {
        flip();
        
        teleport();
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.velocity = (direction * walkSpeed);
        if (rb.velocity.magnitude > 0)
        { 
            tempDirection = direction;
            setSprite();
            if (dashCD >= 2f)
            {
                dodgeroll();
                
            }
        }
        else
        {
            List<Sprite> idleSprite = GetSpriteDirection();
            sr.sprite = idleSprite[0];
        }
        dashCD += Time.deltaTime;
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

    public void flip()
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
        
        if (tempDirection.y > 0)
        {
            if (Mathf.Abs(tempDirection.x) > 0)
            {
                selectedSprites = neSprites;
                
            }
            else
            {
                selectedSprites = nSprites;
            }
        } else if (tempDirection.y < 0)
        {
            if (Mathf.Abs(tempDirection.x) > 0)
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
        Vector3 dodgerollDist = new Vector2(3f * Math.Sign(tempDirection.x), 3f * Math.Sign(tempDirection.y));
        if (Input.GetMouseButtonDown(1))
        {
            bool raycast = Physics2D.Raycast(transform.position, dodgerollDist, dodgerollDist.magnitude, wall);
            if (!raycast)
            {
                transform.position += dodgerollDist;
                ps.Play();
                dashCD = 0f;
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
