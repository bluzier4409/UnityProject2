using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class rangedEnemyMovement : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private Transform firingPoint;

    [SerializeField] private float fireRate = 0.5f;

    private float fireTimer;


    public GameObject player;

    public float speed;
    public float touchingDistance;

    public float detectionDistance;
    private Rigidbody2D rb;

    private float distance;

    private bool seen = false;
    bool facingRight = false;
    void Start()
    {

    }

    void Update()
    {
        
//only happens if inside of detection disctance

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        if(distance < detectionDistance){
            seen = true;
        }
       

        if(distance > touchingDistance && seen == true){
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime); 
        }

        else if(distance <= touchingDistance && fireTimer <= 0f){
            Instantiate(projectilePrefab,firingPoint.position, firingPoint.rotation);
            fireTimer = fireRate;
        }
        else{
            fireTimer -= Time.deltaTime;
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
