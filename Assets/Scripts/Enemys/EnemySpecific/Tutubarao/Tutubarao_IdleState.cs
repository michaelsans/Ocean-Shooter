using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutubarao_IdleState : IdleState
{
    private Tutubarao enemy;
    public Tutubarao_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Tutubarao enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        if(!core.CollisionSenses.WallFront)
        {
            if(enemy.currentHealth <= enemy.entityData.maxHealth / 2)
            {
                stateMachine.ChangeState(enemy.HalfHPMoveState);
            }
            else
            {
                stateMachine.ChangeState(enemy.FullHPMoveState);
            }
            
        }
        else if(Time.time >= startTime + stateData.minIdleTime && core.CollisionSenses.WallFront)
        {
            stateMachine.ChangeState(enemy.ChargeState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
