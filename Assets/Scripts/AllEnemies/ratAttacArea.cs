using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratAttacArea : MonoBehaviour
{
        private int damage = 2;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        
        if(collider.GetComponent<playerHealth>() != null)
        {
            Debug.Log("player hit");

            playerHealth health = collider.GetComponent<playerHealth>();
            health.Damage(damage);
        }
    }

}