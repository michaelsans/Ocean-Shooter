using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutubarao_RangedAttackState : RangedAttackState
{
    private Tutubarao enemy;
    private float waitTime = 1f;
    
    public Tutubarao_RangedAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_RangedAttackState stateData, Tutubarao enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        EnemyProjetil[] projetil = enemy.GetComponentsInChildren<EnemyProjetil>();
        for (int i = 0; i < projetil.Length; i++)
        {
            if(startTime >= waitTime)
            {
                startTime = waitTime;
                projetil[i].enabled = true;
            }
               
        }
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            enemy.hasMissile = false;
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
}
