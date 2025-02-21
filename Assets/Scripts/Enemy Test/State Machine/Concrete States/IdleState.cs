using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyState
{
    private Vector3 targetPos;
    private Vector3 direction;
    
    public IdleState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        targetPos = GetRandomPoint();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void AnimationTrigger(Enemy.AnimationTrigger trigger)
    {
       base.AnimationTrigger(trigger);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (enemy.Aggro)
        {
            enemy.StateMachine.ChageState(enemy.ChaseState);
        }
        
        direction = (targetPos - enemy.transform.position).normalized;
        enemy.Move(direction * enemy.RandomMovementSpeed);

        if ((enemy.transform.position - targetPos).sqrMagnitude < 0.01f)
        {
            targetPos = GetRandomPoint();
        }
    }

    private Vector3 GetRandomPoint()
    {
        return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * enemy.RandomMovementRange;
    }
}
