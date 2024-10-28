using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

private BoxCollider2D redBoxCollider;

    void Start()
    {
            redBoxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision){
           if (collision.tag == "Rat enemy"){
                Debug.Log("Hit: " + collision.transform.name);
                Destroy(collision.gameObject);
        }
    }
}
