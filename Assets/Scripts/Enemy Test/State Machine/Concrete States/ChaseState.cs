using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChaseState : EnemyState
{
    private Transform transform;
    private float speed = 5f;
    public ChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        transform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Enter()
    {
        base.Enter();
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
        
        Vector2 direction = (transform.position - enemy.transform.position).normalized;
        Debug.Log(direction);
        
        enemy.GetComponent<Rigidbody2D>().velocity = direction * speed;

        if (enemy.Attackable)
        {
            enemy.StateMachine.ChageState(enemy.AttackState);
        }
    }
}
