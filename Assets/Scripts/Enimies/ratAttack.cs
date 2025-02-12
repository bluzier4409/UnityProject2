using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ratAttack : MonoBehaviour
{
    
    private GameObject ratAttacArea = default;
    private bool Attacking = false;
    private float timeToAttack = 0.8f;
    private float timer = 0f;

    public GameObject player;
    private float distance;
    private float attackDistance = 3.8f;


    void Start()
    {
        
        ratAttacArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance <= attackDistance){
            Attack();
        }
        if(Attacking){
            timer += Time.deltaTime;

            if(timer >= timeToAttack){
                timer = 0;
                Attacking = false;
                ratAttacArea.SetActive(Attacking);
            }
        }
        
    }
   
   private void Attack(){
        Attacking = true;
        ratAttacArea.SetActive(Attacking);
   }
    
}
