using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pexe : Entity, IDamageable
{
    public Pexe_MoveState MoveState { get; private set; }
    public Pexe_MoveState FleeState { get; private set; }
    public Pexe_DeadState DeadState { get; private set; }

    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_DeadState deadStateData;

    public override void Awake()
    {
        base.Awake();
        MoveState = new Pexe_MoveState(this, stateMachine, "move", moveStateData, this);
        FleeState = new Pexe_MoveState(this, stateMachine, "flee", moveStateData, this);
        DeadState = new Pexe_DeadState(this, stateMachine, "dead", deadStateData, this);


        stateMachine.Initialize(MoveState);
    }

    public override void TakeDamage(int amount, bool empty)
    {
        base.TakeDamage(amount, empty);
        if (isDead)
        {
            stateMachine.ChangeState(DeadState);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (collision.tag == "Player")
        {
            if (damageable != null)
            {
                damageable.TakeDamage(entityData.damage, false);
            }
        }
    }
    public override void Update()
    {
        base.Update();
        if(timeToFlee)
        {
            stateMachine.ChangeState(FleeState);
        }
    }

}
