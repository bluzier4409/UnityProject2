using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateToPlayer : MonoBehaviour
{
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    public GameObject player;

    public float touchingDistance;
    private float distance;

    void Update()
    {
            
        /*Vector3 difference = player.GetComponent<Transform>().position - transform.position;
        float rotationZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, rotationZ + 180), Time.deltaTime);*/
        
        distance = Vector2.Distance(transform.position, player.transform.position);

        //if(distance <= touchingDistance){

        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
      //  }
        

        
    }
}
