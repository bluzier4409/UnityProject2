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
    
    private float timer;
    private float timeToAttack = 0.2f;

    private float exitTimer;
    private float exitTime = 3f;
    private float distanceToCountExit = 3f;

    public float bulletSpeed = 10f;
    public AttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
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
       // base.AnimationTrigger();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        
        enemy.Move(Vector2.zero);

        if (timer > timeToAttack)
        {
            timer = 0f;
            
            Vector2 direction = (transform.position - enemy.transform.position).normalized;
            
            Rigidbody2D bullet = GameObject.Instantiate(enemy.bullet, enemy.transform.position, Quaternion.identity);
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
    }
}
