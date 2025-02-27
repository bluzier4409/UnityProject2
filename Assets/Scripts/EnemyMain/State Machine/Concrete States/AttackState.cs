using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class AttackState : EnemyState
{
    private Transform transform;
    
 //   private float timer;
  //  private float timeToAttack = 0.2f;

  //  private float exitTimer;
  //  private float exitTime = 0.2f;
   // private float distanceToCountExit = 3f;

   // public float bulletSpeed = 10f;
    public AttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
      //  transform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.AttackBaseInstance.EnterLogic();
    }

    public override void Exit()
    {
        base.Exit();
        enemy.AttackBaseInstance.ExitLogic();
    }

    public override void AnimationTrigger(Enemy.AnimationTrigger trigger)
    {
       base.AnimationTrigger(trigger);
       
       enemy.AttackBaseInstance.AnimationTriggerLogic(trigger);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        enemy.AttackBaseInstance.PhysicsLogic();
    }

    public override void FrameUpdate()
    {
     //   base.FrameUpdate();
        
     //   enemy.Move(Vector2.zero);

    //    if (timer > timeToAttack)
    //    {
       //     timer = 0f;
            
       //     Vector2 direction = (transform.position - enemy.transform.position).normalized;
            
       //     Rigidbody2D bullet = GameObject.Instantiate(enemy.bullet, enemy.transform.position, Quaternion.identity);
       //     bullet.velocity = direction * bulletSpeed;
       // }

       // if (Vector2.Distance(transform.position, enemy.transform.position) > distanceToCountExit)
       // {
          //  exitTimer += Time.deltaTime;
          //  if (exitTimer > exitTime)
          //  {
          //      enemy.StateMachine.ChageState(enemy.ChaseState);
           // }
      //  }
      //  else
      //  {
      //      exitTimer = 0f;
     //   }
        
        
       // timer += Time.deltaTime;
       
       enemy.AttackBaseInstance.FrameUpdateLogic();
    }
}
