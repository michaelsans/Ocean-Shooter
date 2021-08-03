using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeixeEspada_MoveState : MoveState
{
    private PeixeEspada enemy;
    public PeixeEspada_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, PeixeEspada enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        if (isDetectingWall)
        {
            //enemy.CleanUP();
        }
        else if (isPlayerInMaxAggroRange)
        {
            stateMachine.ChangeState(enemy.ChargeState);
        }
        else if (enemy.currentHealth <= enemy.entityData.maxHealth / 2)
        {
            stateMachine.ChangeState(enemy.HalfHPMoveState);
        }
        else
        {
            stateMachine.ChangeState(enemy.FullHPMoveState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
