using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
[CreateAssetMenu(fileName = "Attack - Ranged", menuName = "Enemy Logic/Attack Logic/Ranged Attack")]
public class EnemyAttackRangedAttack : EnemyAttackSO
{
    [SerializeField] public Rigidbody2D bullets;
    [SerializeField] private float timer;
    [SerializeField] private float timeToAttack = 0.2f;
    [SerializeField] private float exitTimer;
    [SerializeField] private float exitTime = 3f;
    [SerializeField] private float distanceToCountExit = 10f;
    [SerializeField] public float bulletSpeed = 10f;
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
        
         enemy.Move(Vector2.zero);

        if (timer > timeToAttack) 
        {
            timer = 0f;
            
             Vector2 direction = -(transform.position - playerTransform.position).normalized;
             
             Rigidbody2D bullet = GameObject.Instantiate(bullets, transform.position, Quaternion.identity);
             bullet.velocity = direction * bulletSpeed;
             Debug.Log(direction);
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
}
