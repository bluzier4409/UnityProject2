
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph.Internal;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class playerMovenew : MonoBehaviour
{
    [SerializeField] private float startingMoveSpeed = 8f;

    private Rigidbody2D rb;

    private float dodgeDelay = 0.1f;
    private float timer = 0f;
    [SerializeField] private float dodgeSpeed = 30f;
    private bool dodgeOnCooldown;

    private playerHealth pHealth;
    
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



    bool facingRight = false;
    

    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.velocity = (direction * walkSpeed);
        
        flip();

        if(dodgeOnCooldown){
            timer += Time.deltaTime;

            if(timer >= dodgeDelay){
                timer = 0;
                walkSpeed = 8;
                dodgeOnCooldown = false;
                pHealth.setInvulnerable(false);

            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && dodgeOnCooldown == false){
            Dodge();
        }
        
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

    void Dodge(){
        Debug.Log("Left Shift key was released");
        
        walkSpeed = dodgeSpeed;
        pHealth.setInvulnerable(true);
        dodgeOnCooldown = true;
        
    }
}