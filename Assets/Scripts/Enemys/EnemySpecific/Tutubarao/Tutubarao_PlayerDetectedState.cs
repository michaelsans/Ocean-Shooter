using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutubarao_PlayerDetectedState : PlayerDetectState
{
    private Tutubarao enemy;
    public Tutubarao_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectState stateData, Tutubarao enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Dochecks()
    {
        base.Dochecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isPlayerInMaxAggroRange)
        {
            stateMachine.ChangeState(enemy.ChargeState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
