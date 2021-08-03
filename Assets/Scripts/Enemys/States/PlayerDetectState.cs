 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectState : State
{
    protected D_PlayerDetectState stateData;

    protected bool isPlayerInMinAggroRange;
    protected bool isPlayerInMaxAggroRange;
    protected bool performLongRangeAction;
    protected bool performCloseRangeAction;
    protected bool isDetectingGround;
    public PlayerDetectState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Dochecks()
    {
        base.Dochecks();
        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
        isPlayerInMaxAggroRange = entity.CheckPlayerInMaxAggroRange();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        performLongRangeAction = entity.CheckPlayerInLongRangeAction();

    }

    public override void Enter()
    {
        base.Enter();
        performLongRangeAction = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Time.time >= + stateData.longRangeactionTime)
        {
            performLongRangeAction = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}
