using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
[CreateAssetMenu(fileName = "Attack - Ranged", menuName = "Enemy Logic/Attack Logic/Ranged Attack")]
public class EnemyAttackRangedAttack : EnemyAttackSO
{
    [SerializeField] public Rigidbody2D bullet;
    [SerializeField] private float timer;
    [SerializeField] private float timeToAttack = 0.2f;
    [SerializeField] private float exitTimer;
    [SerializeField] private float exitTime = 0.2f;
    [SerializeField] private float distanceToCountExit = 3f;
    [SerializeField] public float bulletSpeed = 10f;
    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void EnterLogic()
    {
        base.EnterLogic();
        
        
        enemy.AttackBaseInstance.EnterLogic();
    }

    public override void ExitLogic()
    {
        base.ExitLogic();
        
        enemy.AttackBaseInstance.ExitLogic();
    }

    public override void FrameUpdateLogic()
    {
        base.FrameUpdateLogic();
        
         enemy.Move(Vector2.zero);

        if (timer > timeToAttack) 
        {
            timer = 0f;
            
             Vector2 direction = (transform.position - enemy.transform.position).normalized;
            
             bullet = GameObject.Instantiate(bullet, enemy.transform.position, Quaternion.identity);
             bullet.velocity = direction * bulletSpeed;
         }

         if (Vector2.Distance(transform.position, enemy.transform.position) > distanceToCountExit)
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
         
         enemy.AttackBaseInstance.FrameUpdateLogic();
    }

    public override void PhysicsLogic()
    {
        base.PhysicsLogic();
        
        enemy.ChaseBaseInstance.PhysicsLogic();
    }

    public override void AnimationTriggerLogic(Enemy.AnimationTrigger trigger)
    {
        base.AnimationTriggerLogic(trigger);
        
        enemy.AttackBaseInstance.AnimationTriggerLogic(trigger);
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
