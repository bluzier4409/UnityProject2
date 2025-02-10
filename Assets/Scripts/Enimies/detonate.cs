using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class detonate : MonoBehaviour
{
    public GameObject gameObject;
    
    public Animator animator;

    public GameObject target;

    public float returnDistance()
    {
        float distance = Vector3.Distance(gameObject.transform.position, target.transform.position);
        return distance;
    }

    public void explode()
    {
        animator.SetTrigger("boom");
        print("detonated");
    }

    public void Update()
    {
        if (returnDistance() < 2f)
        {
            explode();
        }
    }
}
 