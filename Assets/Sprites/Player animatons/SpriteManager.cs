using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;
   
    public List<Sprite> nSprites;
    public List<Sprite> neSprites;
    public List<Sprite> eSprites;
    public List<Sprite> seSprites;
    public List<Sprite> sSprites;
    
    public float walkSpeed;
    public float frameRate;
    float idleTime;
    
    Vector2 direction;

    void Update()
    {
        flip();
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
}
