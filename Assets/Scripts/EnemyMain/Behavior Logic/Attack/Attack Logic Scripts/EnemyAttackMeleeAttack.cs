using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
[CreateAssetMenu(fileName = "Attack - Melee", menuName = "Enemy Logic/Attack Logic/Melee Attack")]
public class EnemyAttackMeleeAttack : EnemyAttackSO
{
    [SerializeField] private float timer;
    [SerializeField] private float timeToAttack = 1f;
    [SerializeField] private float exitTimer;
    [SerializeField] private float exitTime = 0.2f;
    [SerializeField] private float distanceToCountExit = 3f;
    [SerializeField] private CircleCollider2D attackTrigger;
    [SerializeField] private int damage;
   
    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void EnterLogic()
    {
        base.EnterLogic();
        
       
        
        
      
        // circleColliders = GetComponentsInChildren<CircleCollider2D>();
       // foreach(CircleCollider2D circleCollider in circleColliders)
       //    attackTrigger.Equals(circleCollider);
        
        
    }

    public override void ExitLogic()
    {
        base.ExitLogic();
        
    }

    public override void FrameUpdateLogic()
    {
        base.FrameUpdateLogic();

        enemy.Move(Vector2.zero);
        

        if (timer > timeToAttack)
        {
            timer = 0f;

            playerHealth health = target.GetComponent<playerHealth>();
            health.Damage(damage);
        }
        
        if (Vector2.Distance(transform.position, playerTransform.position) > distanceToCountExit)
        {
                
            exitTimer += Time.deltaTime;
            if (exitTimer > exitTime)
            {
                enemy.StateMachine.ChageState(enemy.ChaseState);
            }
        }
        else
        {
            exitTimer = 0f;
        }
        
        timer += Time.deltaTime;
        
    }

    public override void PhysicsLogic()
    {
        
        base.PhysicsLogic();
    }

    public override void AnimationTriggerLogic(Enemy.AnimationTrigger trigger)
    {
        base.AnimationTriggerLogic(trigger);
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.GetComponent<playerHealth>() != null)
        {
            playerHealth health = collide.GetComponent<playerHealth>();
            health.Damage(damage);
        }
    }
}
