using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
[CreateAssetMenu(fileName = "Attack - Melee", menuName = "Enemy Logic/Attack Logic/Melee Attack")]
public class EnemyAttackMeleeAttack : EnemyAttackSO
{
    [SerializeField] private float timer;
    [SerializeField] private float timeToAttack = 0.5f;
    [SerializeField] private float exitTimer;
    [SerializeField] private float exitTime = 0.2f;
    [SerializeField] private float distanceToCountExit = 3f;
    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void EnterLogic()
    {
        base.EnterLogic();
        
    }

    public override void ExitLogic()
    {
        base.ExitLogic();
        
    }

    public override void FrameUpdateLogic()
    {
        base.FrameUpdateLogic();

        if (timer > timeToAttack)
        {
            timer = 0f;
            
            
        }
        
        if (Vector2.Distance(transform.position, enemy.transform.position) > distanceToCountExit)
        {
                Collider2D collide = Physics2D.OverlapCircle(transform.position, 0.3f, LayerMask.GetMask("Player"));

                if (collide.GetComponent<playerHealth>() != null)
                {
                    playerHealth health = collide.GetComponent<playerHealth>(); 
                    health.Damage(10);
                }
                
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
}
