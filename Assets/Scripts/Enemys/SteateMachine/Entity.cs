using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Entity : MonoBehaviour, IDamageable
{
    public FiniteStateMachine stateMachine;

    public D_Entity entityData;
    public Animator anim { get; private set; }
    public AnimationToStateMachine atsm { get; private set; }
    public int lastDamageDirection { get; private set; }
    public Core Core { get; private set; }
    public float currentHealth { get; private set; }
    
    public bool timeToFlee;

    public int randomN;

    [SerializeField] private Transform playerCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform spawnLocation;

    private Vector2 velocityWorkspace;

    private float currentStunResistence;
    private float lastDamageTime;

    protected bool isDead;
    protected bool isStunned; 
    public virtual void Awake()
    {
        currentHealth = entityData.maxHealth;
        currentStunResistence = entityData.stunResistence;
        timeToFlee = false;

        Core = GetComponentInChildren<Core>();

        anim = GetComponent<Animator>();
        atsm = GetComponent<AnimationToStateMachine>();

        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
        if(Time.time >= lastDamageTime + entityData.stunRecoveryTime)
        {
            ResetStunResistence();
        }
        randomN = Random.Range(0, 20);
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    
    public virtual bool CheckPlayerInAggroRange()
    {
        return Physics2D.OverlapCircle(transform.position, 2f, entityData.whatIsPlayer);
    }
    public virtual bool CheckPlayerInMinAggroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.minAggroRangeDist, entityData.whatIsPlayer);
    }
    public virtual bool CheckPlayerInMaxAggroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.up * -1, entityData.maxAggroRangeDist, entityData.whatIsPlayer);
    }
    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }
    public virtual bool CheckPlayerInLongRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.maxRangeActionDistance, entityData.whatIsPlayer);
    }
    public virtual void DamageHop(float velocity)
    {
        velocityWorkspace.Set(Core.Movements.RB2D.velocity.x, velocity);
        Core.Movements.RB2D.velocity = velocityWorkspace;
    }

    public virtual void Teleport()
    {
        transform.position = spawnLocation.transform.position;
    }
    public virtual void ResetStunResistence()
    {
        isStunned = false;
        currentStunResistence = entityData.stunResistence;
    }
    public virtual void TakeDamage(int amount, bool empty)
    {
        
        FindObjectOfType<NewAudioManager>().Play("bubbleHit");
        lastDamageTime = Time.time;
        
        currentHealth -= amount;

        //DamageHop(entityData.damageHopSpeed);

        Instantiate(entityData.hitParticle, transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));

        if(currentStunResistence <= 0)
        {
            isStunned = true;
        }

        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }

    public void CleanUP()
    {
        Destroy(gameObject);
    }
    public virtual void OnDrawGizmos()
    {
        //if(Core != null)
        //{
            //Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.down * entityData.wallCheckDistance));
            //Gizmos.DrawLine(playerCheck.position, playerCheck.position + (Vector3)(Vector2.down * entityData.wallCheckDistance));

            //Gizmos.DrawWireSphere(playerCheck.transform.position, 2f);
            //Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * Core.Movements.FacingDirection * entityData.closeRangeActionDistance), 0.2f);
            //Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * Core.Movements.FacingDirection * entityData.minAggroRangeDist), 0.2f);
            //Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * Core.Movements.FacingDirection * entityData.maxAggroRangeDist), 0.2f);
        //}
        
    }
}
