using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamage, IMove, ITrigger
{
    [field: SerializeField] public float MaxHealth { get; set; } = 100f;

    [SerializeField] private GameObject target;
    
    public float CurrentHealth { get; set; }
    public Rigidbody2D rb { get; set; }
    public bool isFacingRight { get; set; } = true;
    
    public bool Aggro { get; set; }
    public bool Attackable { get; set; }

    private CircleCollider2D circleCollider2D;

    

    public SpriteRenderer sr;
    
    // Idle Variable
  
    
    //State Machine Vars

    [SerializeField] private EnemyIdleSO IdleBase;
    [SerializeField] private EnemyChaseSO ChaseBase;
    [SerializeField] private EnemyAttackSO AttackBase;
    
    public EnemyIdleSO IdleBaseInstance { get; set; }
    public EnemyChaseSO ChaseBaseInstance { get; set; }
    public EnemyAttackSO AttackBaseInstance { get; set; }
    
    public EnemyStateMachine StateMachine { get; set; }
    public IdleState IdleState { get; set; }
    public ChaseState ChaseState { get; set; }
    public AttackState AttackState { get; set; }
    

    void Awake()
    {
        IdleBaseInstance = Instantiate(IdleBase);
        ChaseBaseInstance = Instantiate(ChaseBase);
        AttackBaseInstance = Instantiate(AttackBase);
        
        StateMachine = new EnemyStateMachine();
        IdleState = new IdleState(this, StateMachine);
        ChaseState = new ChaseState(this, StateMachine);
        AttackState = new AttackState(this, StateMachine);
        
    }

    void Start()
    {
        CurrentHealth = MaxHealth;
        
        rb = GetComponent<Rigidbody2D>();

        IdleBaseInstance.Initialize(gameObject, this);
        ChaseBaseInstance.Initialize(gameObject, this);
        AttackBaseInstance.Initialize(gameObject, this);
        
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

    public void ExplodeAttack()
    {
        Debug.Log("this is happening");
        if (Attackable)
        {
            if (target.GetComponent<playerHealth>() != null)
            {
                Debug.Log("this is occuring");
                playerHealth health;
                health = target.GetComponent<playerHealth>();
                health.Damage(5);
            }
        }
    }
    
    public void RangeAttack()
    {
            if (target.GetComponent<playerHealth>() != null)
            {
                Debug.Log("this is occuring");
                playerHealth health;
                health = target.GetComponent<playerHealth>();
                health.Damage(1);
            }
    }
    
    
    
    

    public void Flip(Vector2 velocity)
    {
        if (isFacingRight && velocity.x > 0f)
        {
            sr.flipX = false;
            isFacingRight = !isFacingRight;
        }
        else if (!isFacingRight && velocity.x < 0f)

        {
            sr.flipX = true;
           // Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            //transform.rotation = Quaternion.Euler(rotator);
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
