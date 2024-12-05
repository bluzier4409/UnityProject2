using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 2;
    private UnityEngine.Vector2 mousePos;


    void Update(){

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - 
        transform.position.x) * Mathf.Rad2Deg - 90f;

        transform.localRotation = UnityEngine.Quaternion.Euler(0,0, angle);

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        
        if(collider.GetComponent<ObjHealth>() != null)
        {
            Debug.Log("hit");

            ObjHealth health = collider.GetComponent<ObjHealth>();
            health.Damage(damage);
        }
    }

}
