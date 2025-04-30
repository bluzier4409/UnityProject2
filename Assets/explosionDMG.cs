using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionDMG : MonoBehaviour
{

    private Vector3 whereIAm;

    private double radius;
    [SerializeField]private int maxExplosionDmg_oneGreater = 11;

    //chnage radius as it goes?

    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
        whereIAm = this.transform.position;
        radius = GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void enableCollider(){
        enabled = true;
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        ObjHealth enemy = collision.GetComponent<ObjHealth>();
        if (enemy != null)
        {
            int proximity = (int)(whereIAm - enemy.transform.position).magnitude;
            Debug.Log("prox =  " + proximity);
            int dmgAmount = (int)(maxExplosionDmg_oneGreater - (proximity/radius));
            enemy.Damage(dmgAmount);
            Debug.Log("did " + dmgAmount + "damage prox");
        }
        enabled = false;
    }

}
