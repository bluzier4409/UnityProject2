using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamage, IMove, ITrigger
{
    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    
    public float CurrentHealth { get; set; }
    public Rigidbody2D rb { get; set; }
    public bool isFacingRight { get; set; } = true;
    
    public bool Aggro { get; set; }
    public bool Attackable { get; set; }

    public Rigidbody2D bullet;
    
    // Idle Variable
    public float RandomMovementRange = 5f;
    public float RandomMovementSpeed = 1f;
    
    //State Machine Vars
    
    public EnemyStateMachine StateMachine { get; set; }
    public IdleState IdleState { get; set; }
    public ChaseState ChaseState { get; set; }
    public AttackState AttackState { get; set; }

    void Awake()
    {
        StateMachine = new EnemyStateMachine();
        IdleState = new IdleState(this, StateMachine);
        ChaseState = new ChaseState(this, StateMachine);
        AttackState = new AttackState(this, StateMachine);
        
    }

    void Start()
    {
        CurrentHealth = MaxHealth;
        
        rb = GetComponent<Rigidbody2D>();
        
        StateMachine.StartState(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.FrameUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Move(Vector2 velocity)
    {
        rb.velocity = velocity;
        Flip(velocity);
    }

    public void Flip(Vector2 velocity)
    {
        if (isFacingRight && velocity.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 100f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;
        }
        else if (!isFacingRight && velocity.x > 0f)

        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;
        }
    }

    public enum AnimationTrigger
    {
        Damaged,
        Attacking,
        Walking
    }

    private void AnimationTriggerEvent(AnimationTrigger animationTrigger)
    {
        StateMachine.CurrentState.AnimationTrigger(animationTrigger);
    }

    
    public void SetAggro(bool aggro)
    {
        Aggro = aggro;
    }

    public void SetAttackable(bool attackable)
    {
       Attackable = attackable;
    }
}
