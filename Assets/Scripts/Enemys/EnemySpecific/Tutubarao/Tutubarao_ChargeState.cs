using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutubarao_ChargeState : ChargeState
{
    private Tutubarao enemy;
    public Tutubarao_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, Tutubarao enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        if(isPlayerinMinAggroRange)
        {
            stateMachine.ChangeState(enemy.MeeleAttackState);
        }
        else if (isChargeTimeOver)
        {
            enemy.Teleport();

            if (enemy.currentHealth <= enemy.entityData.maxHealth / 2)
            {
                stateMachine.ChangeState(enemy.HalfHPMoveState);
            }
            else
            {
                stateMachine.ChangeState(enemy.FullHPMoveState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
