using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[CreateAssetMenu(fileName = "Chase - Direct", menuName = "Enemy Logic/Chase Logic/Direct")]
public class EnemyChaseDirect : EnemyChaseSO
{
    private float speed = 3f;
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
        
        Vector2 direction = (playerTransform.position - enemy.transform.position).normalized;
        
        enemy.Move(direction * speed);

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
