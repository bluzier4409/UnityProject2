using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyState
{
   
    
    public IdleState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        enemy.IdleBaseInstance.EnterLogic();
    }

    public override void Exit()
    {
        base.Exit();
        
        enemy.IdleBaseInstance.ExitLogic();
    }

    public override void AnimationTrigger(Enemy.AnimationTrigger trigger)
    {
       base.AnimationTrigger(trigger);
       
       enemy.IdleBaseInstance.AnimationTriggerLogic(trigger);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        enemy.IdleBaseInstance.PhysicsLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        enemy.IdleBaseInstance.FrameUpdateLogic();
    }

   
}
