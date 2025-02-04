using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name.Equals("mainChar"))
        {
            Debug.Log("key touch");
            PlayerInvintory invintory = collider.GetComponentInChildren<PlayerInvintory>();
            invintory.giveKey();

            Destroy(this.gameObject);
        }
        
    }


}
