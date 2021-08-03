using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tutubarao : Entity, IDamageable
{
    public Tutubarao_MoveState FullHPMoveState { get; private set; }
    public Tutubarao_MoveState HalfHPMoveState { get; private set; }
    public Tutubarao_IdleState IdleState { get; private set; }
    public Tutubarao_PlayerDetectedState PlayerDetectState { get; private set; }
    public Tutubarao_RechargingState FullHPRechargingState { get; private set; }
    public Tutubarao_RechargingState HalfHPRechargingState { get; private set; }
    public Tutubarao_MeeleAttackState MeeleAttackState { get; private set; }
    public Tutubarao_DeadState DeadState { get; private set; }
    public Tutubarao_ChargeState ChargeState { get; private set; }

    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetectState playerDetectStateData;
    [SerializeField]
    private D_RechargingState rechargingStateData;
    [SerializeField]
    private D_MeeleAttack meeleAttackStateData;
    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    private D_ChargeState chargeStateData;

    [SerializeField]
    private Transform attackPosition;
    [SerializeField]
    public Transform idleLocation;
    public GameObject brilho;
    public override void Awake()
    {
        base.Awake();
        FullHPMoveState = new Tutubarao_MoveState(this, stateMachine, "moveFullHP", moveStateData, this);
        HalfHPMoveState = new Tutubarao_MoveState(this, stateMachine, "moveHalfHP", moveStateData, this);
        IdleState = new Tutubarao_IdleState(this, stateMachine, "idle", idleStateData, this);
        PlayerDetectState = new Tutubarao_PlayerDetectedState(this, stateMachine, "playerDectect", playerDetectStateData, this);
        FullHPRechargingState = new Tutubarao_RechargingState(this, stateMachine, "rechargingFullHP", rechargingStateData, this);
        HalfHPRechargingState = new Tutubarao_RechargingState(this, stateMachine, "rechargingHalfHP", rechargingStateData, this);
        MeeleAttackState = new Tutubarao_MeeleAttackState(this, stateMachine, "meeleAttack", attackPosition, meeleAttackStateData, this);
        DeadState = new Tutubarao_DeadState(this, stateMachine, "dead", deadStateData, this);
        ChargeState = new Tutubarao_ChargeState(this, stateMachine, "charge", chargeStateData, this);

        stateMachine.Initialize(FullHPMoveState);
    }

    public override void TakeDamage(int amount, bool empty)
    {
        base.TakeDamage(amount,empty);
        if (isDead)
        {
            brilho.SetActive(true);
            NewAudioManager.instance.Pause("danger");
            NewAudioManager.instance.Play("bubbles");
            stateMachine.ChangeState(DeadState);
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(attackPosition.position, meeleAttackStateData.attackRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (collision.tag == "Player")
        {
            if (damageable != null)
            {
                damageable.TakeDamage(entityData.damage, true);
            }
        }
    }


}
