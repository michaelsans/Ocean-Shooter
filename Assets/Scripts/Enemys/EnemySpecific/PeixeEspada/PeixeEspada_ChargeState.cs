using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeixeEspada_ChargeState : ChargeState
{
    private PeixeEspada enemy;
    public PeixeEspada_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, PeixeEspada enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isPlayerinMinAggroRange)
        {
            if(enemy.currentHealth <= enemy.entityData.maxHealth / 2)
            {
                stateMachine.ChangeState(enemy.HalfHPMeeleAttackState);
            }
            else
            {
                stateMachine.ChangeState(enemy.FullHPMeeleAttackState);
            }
        }
    }
}
