using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    private GameObject AttackArea = default;
    private bool Attacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;


    void Start()
    {
        AttackArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Attack();
        }

        if(Attacking){
            timer += Time.deltaTime;

            if(timer >= timeToAttack){
                timer = 0;
                Attacking = false;
                AttackArea.SetActive(Attacking);
            }
        }
        
    }
   
   private void Attack(){
        Attacking = true;
        AttackArea.SetActive(Attacking);
   }
    
}
