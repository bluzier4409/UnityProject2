using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideScript : MonoBehaviour
{
    [SerializeField] private int bulletDammage = 1;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(GetComponentInParent<HomeBullet>().gameObject);
        if(collider.GetComponent<ObjHealth>() != null)
        {
            ObjHealth health = collider.GetComponent<ObjHealth>();
            health.Damage(bulletDammage);
        }
    }
}
