using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class flipToPlayer : MonoBehaviour
{
    public AIPath aIPath;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if(player.position.x <= transform.position.x){
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (player.position.x >= transform.position.x){
            transform.localScale = new Vector3(-1f, 1f, 1f);

        }
    }
}
