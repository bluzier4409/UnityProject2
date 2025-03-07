using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSO : ScriptableObject
{
    protected Enemy enemy;
    protected Transform transform;
    protected GameObject gameObject;  
    protected GameObject target;
   
    protected Transform playerTransform;

    public virtual void Initialize(GameObject gameObject, Enemy enemy)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;
        this.enemy = enemy;
         
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        target = GameObject.FindGameObjectWithTag("Player");
    }
   
    public virtual void EnterLogic() {}
    public virtual void ExitLogic() {ResetValues();}

    public virtual void FrameUpdateLogic() {}
    public virtual void PhysicsLogic() {}

    public virtual void AnimationTriggerLogic(Enemy.AnimationTrigger trigger) {}
   
    public virtual void ResetValues() {}
}
