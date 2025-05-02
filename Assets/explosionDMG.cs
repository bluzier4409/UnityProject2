using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionDMG : MonoBehaviour
{

    private Vector3 whereIAm;

    [SerializeField]private float maxRadius;
    private float radius;
    [SerializeField]private int maxExplosionDmg_oneGreater = 11;

    //chnage radius as it goes?

    // Start is called before the first frame update
    void Start()
    {
        
        whereIAm = this.transform.position;
        radius = GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void changeRadius(float newRad){
        Debug.Log("changeRad is called");
        radius = newRad;
        GetComponent<CircleCollider2D>().radius = newRad;
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        ObjHealth enemy = collision.GetComponent<ObjHealth>();
        if (enemy != null)
        {
            int proximity = (int)(whereIAm - enemy.transform.position).magnitude;
            Debug.Log("prox =  " + proximity);
            int dmgAmount = (int)(maxExplosionDmg_oneGreater - (proximity/maxRadius));
            enemy.Damage(dmgAmount);
            Debug.Log("did " + dmgAmount + "damage prox");
        }
        enabled = false;
    }

}
