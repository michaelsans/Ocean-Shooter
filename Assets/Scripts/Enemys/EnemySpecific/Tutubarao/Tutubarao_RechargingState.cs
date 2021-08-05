using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutubarao_RechargingState : RechargingState
{
    private Tutubarao enemy;
    public Tutubarao_RechargingState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_RechargingState stateData, Tutubarao enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        if (core.CollisionSenses.WallFront)
        {
            entity.Teleport();
            if (!enemy.hasMissile)
                enemy.CreateMissile();
            stateMachine.ChangeState(enemy.IdleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
