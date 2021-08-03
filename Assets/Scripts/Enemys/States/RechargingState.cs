using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargingState : State
{
    protected D_RechargingState stateData;

    protected bool flipImmediately;
    protected bool isPlayerInMinAggroRange;
    protected bool isAllturnsDone;
    protected bool isAllTurnsTimeDone;
    protected bool isPlayerInMaxAggroRange;


    protected float lastTurnTime;
    
    protected int amountOfturnsDone;
    public RechargingState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_RechargingState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Dochecks()
    {
        base.Dochecks();

        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
        isPlayerInMaxAggroRange = entity.CheckPlayerInMaxAggroRange();
    }

    public override void Enter()
    {
        base.Enter();
        core.Movements.SetVelocityX(10f); 
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
       
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    
}
