using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "Attack - Explode", menuName = "Enemy Logic/Attack Logic/Explode Attack")]
public class EnemyAttackExplodeAttack : EnemyAttackSO
{
    [SerializeField] CircleCollider2D attackRange;
    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void EnterLogic()
    {
        base.EnterLogic();
        enemy.ExplodeAttack();
    }

    public override void ExitLogic()
    {
        base.ExitLogic();
    }

    public override void FrameUpdateLogic()
    {
        base.FrameUpdateLogic();
        
        enemy.Move(Vector2.zero);
        
        Destroy(this.gameObject);
        
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

    //IEnumerator explodeAnimation()
    //{
        
    //}
}
