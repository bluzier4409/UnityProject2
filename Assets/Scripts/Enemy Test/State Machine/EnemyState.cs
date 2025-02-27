using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
   protected Enemy enemy;
   protected EnemyStateMachine enemyStateMachine;

   public EnemyState(Enemy enemy, EnemyStateMachine enemyStateMachine)
   {
      this.enemy = enemy;
      this.enemyStateMachine = enemyStateMachine;
   }
   

   // virtual = optionally overridable in another state later on
   
   public virtual void Enter(){}
   public virtual void Exit(){}
   public virtual void AnimationTrigger(Enemy.AnimationTrigger trigger){}
   public virtual void PhysicsUpdate(){}
   public virtual void FrameUpdate(){}
   
}
