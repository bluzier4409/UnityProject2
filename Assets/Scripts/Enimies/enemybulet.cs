using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemybulet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
     Destroy(this.gameObject);
      
      if(collider.GetComponent<playerHealth>() != null)
      {
            Debug.Log("playerHit");

            playerHealth pHealth = collider.GetComponent<playerHealth>();
            pHealth.Damage(1);
      }
      
      
    }
}
