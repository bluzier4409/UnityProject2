using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChaseState : EnemyState
{
   
    public ChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        //transform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Enter()
    {
        base.Enter();
        
        enemy.ChaseBaseInstance.EnterLogic();
    }

    public override void Exit()
    {
        base.Exit();
        
        enemy.ChaseBaseInstance.ExitLogic();
    }

    public override void AnimationTrigger(Enemy.AnimationTrigger trigger)
    {
     base.AnimationTrigger(trigger);
     
     enemy.ChaseBaseInstance.AnimationTriggerLogic(trigger);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        enemy.ChaseBaseInstance.PhysicsLogic();
    }

    public override void FrameUpdate()
    {
       enemy.ChaseBaseInstance.FrameUpdateLogic();
    }
}
