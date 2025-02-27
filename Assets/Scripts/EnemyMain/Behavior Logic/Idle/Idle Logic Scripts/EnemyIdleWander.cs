using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle - Wander", menuName = "Enemy Logic/Idle Logic/Wander")]
public class EnemyIdleWander : EnemyIdleSO
{
    [SerializeField] public float RandomMovementRange = 5f;
    [SerializeField] public float RandomMovementSpeed = 1f;
    
    private Vector3 targetPos;
    private Vector3 direction;
    
    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void EnterLogic()
    {
        base.EnterLogic();
        
        targetPos = GetRandomPoint();
    }

    public override void ExitLogic()
    {
        base.ExitLogic();
    }

    public override void FrameUpdateLogic()
    {
        base.FrameUpdateLogic();
        
        direction = (targetPos - enemy.transform.position).normalized;
        enemy.Move(direction * RandomMovementSpeed);

        if ((enemy.transform.position - targetPos).sqrMagnitude < 0.01f)
        {
            targetPos = GetRandomPoint();
        }
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
    
    private Vector3 GetRandomPoint()
    {
        return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * RandomMovementRange;
    }
}
