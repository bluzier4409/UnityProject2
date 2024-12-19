using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class detonate : MonoBehaviour
{
    public GameObject gameObject;
    
    public Animator animator;

    public void explode()
    {
        animator.SetTrigger("boom");
        //Destroy(this.gameObject);
        print("detonated");
    }
}
 