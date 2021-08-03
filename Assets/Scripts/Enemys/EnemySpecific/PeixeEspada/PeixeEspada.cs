using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeixeEspada : Entity, IDamageable
{
    public PeixeEspada_MoveState FullHPMoveState { get; private set; }
    public PeixeEspada_MoveState HalfHPMoveState { get; private set; }
    public PeixeEspada_MeeleAttackState FullHPMeeleAttackState { get; private set; }
    public PeixeEspada_MeeleAttackState HalfHPMeeleAttackState { get; private set; }
    public PeixeEspada_DeadState DeadState { get; private set; }
    public PeixeEspada_ChargeState ChargeState { get; private set; }

    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_MeeleAttack meeleAttackStateData;
    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    private D_ChargeState chargeStateData;

    [SerializeField]
    private Transform attackPosition;

    public override void Awake()
    {
        base.Awake();
        FullHPMoveState = new PeixeEspada_MoveState(this, stateMachine, "moveFullHP", moveStateData, this);
        HalfHPMoveState = new PeixeEspada_MoveState(this, stateMachine, "moveHalfHP", moveStateData, this);
        FullHPMeeleAttackState = new PeixeEspada_MeeleAttackState(this, stateMachine, "fullHPmeeleAttack", attackPosition, meeleAttackStateData, this);
        HalfHPMeeleAttackState = new PeixeEspada_MeeleAttackState(this, stateMachine, "halfHPmeeleAttack", attackPosition, meeleAttackStateData, this);
        DeadState = new PeixeEspada_DeadState(this, stateMachine, "dead", deadStateData, this);
        ChargeState = new PeixeEspada_ChargeState(this, stateMachine, "charge", chargeStateData, this);

        stateMachine.Initialize(FullHPMoveState);
    }

    public override void TakeDamage(int amount, bool empty)
    {
        base.TakeDamage(amount, empty);
        if (isDead)
        {
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
                damageable.TakeDamage(5, false);
            }
        }
    }
}
