using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseSO : ScriptableObject
{
    protected Enemy enemy;
    protected Transform transform;
    protected GameObject gameObject;  
   
    protected Transform playerTransform;

    public virtual void Initialize(GameObject gameObject, Enemy enemy)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;
        this.enemy = enemy;
         
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
   
    public virtual void EnterLogic() {}
    public virtual void ExitLogic() {ResetValues();}

    public virtual void FrameUpdateLogic()
    {
        if (enemy.Attackable)
        {
            enemy.StateMachine.ChageState(enemy.AttackState);
        }
    }
    public virtual void PhysicsLogic() {}

    public virtual void AnimationTriggerLogic(Enemy.AnimationTrigger trigger) {}
   
    public virtual void ResetValues() {}
}
