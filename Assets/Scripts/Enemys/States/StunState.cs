using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunState : State
{
    protected D_StunState stateData;
    protected bool isStunTimeOver;
    protected bool isGrounded;
    protected bool isMovementStopped;
    protected bool performCloseRangeAction;
    protected bool isPlayerInMinAggroRange;


    public StunState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_StunState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Dochecks()
    {
        base.Dochecks();
        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        
    }

    public override void Enter()
    {
        base.Enter();
        isStunTimeOver = false;
        isMovementStopped = false;
        core.Movements.SetVelocity(stateData.stunKnockbackSpeed, stateData.stunKnockabckAngle, entity.lastDamageDirection);
    }

    public override void Exit()
    {
        base.Exit();

        entity.ResetStunResistence();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time > startTime + stateData.stunTime)
        {
            isStunTimeOver = true;
        }
        if(isGrounded && Time.time > startTime + stateData.stunKnockbackTime && !isMovementStopped)
        {
            isMovementStopped = true;
            core.Movements.SetVelocityY(0f);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
