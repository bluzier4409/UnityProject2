using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AiChase : MonoBehaviour
{
    public GameObject player;

    public float speed;
    public float touchingDistance;
    private Rigidbody2D rb;

    private float distance;
    bool facingRight = true;
    void Start()
    {

    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

       

        if(distance > touchingDistance){
                    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                     //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        if (direction.x > 0 && !facingRight){
            Flip();
        }
        else if (direction.x < 0 && facingRight){
            Flip();
        }

    }

    public bool getTouching(){
        return distance <= touchingDistance;
    }

    void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }


}
