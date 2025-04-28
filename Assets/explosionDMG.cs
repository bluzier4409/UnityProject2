using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionDMG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

void AreaDamageEnemies(Vector3 location, float radius, float damage)
{
    Collider[] objectsInRange = Physics.OverlapSphere(location, radius);
    foreach (Collider col in objectsInRange)
    {
        ObjHealth enemy = col.GetComponent<ObjHealth>();
        if (enemy != null)
        {
            // linear falloff of effect
            float proximity = (location - enemy.transform.position).magnitude;
            float effect = 1 - (proximity / radius);

            //enemy.Damage(damage * effect);
        }
    }
}

}
