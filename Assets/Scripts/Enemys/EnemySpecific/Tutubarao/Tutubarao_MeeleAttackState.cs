using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutubarao_MeeleAttackState : MeeleAttackState
{
    private Tutubarao enemy;

    public Tutubarao_MeeleAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeeleAttack stateData, Tutubarao enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
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

    public override void FinishAttack()
    {
        base.FinishAttack();
        if(isAnimationFinished)
        {
            if (enemy.currentHealth <= enemy.entityData.maxHealth / 2)
            {
                stateMachine.ChangeState(enemy.HalfHPRechargingState);
            }
            else
            {
                stateMachine.ChangeState(enemy.FullHPRechargingState);
            }
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

    }

    
}
