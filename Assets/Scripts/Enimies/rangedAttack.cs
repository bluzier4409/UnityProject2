using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private Transform firingPoint;

    [SerializeField] private float fireRate = 0.5f;

    private float fireTimer;
    public GameObject player;
    public float touchingDistance;
    private float distance;



    void Start()
    {
        
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance <= touchingDistance && fireTimer <= 0f){
            Instantiate(projectilePrefab,firingPoint.position, firingPoint.rotation);
            fireTimer = fireRate;
        }
        else{
            fireTimer -= Time.deltaTime;
        }


    }
}
