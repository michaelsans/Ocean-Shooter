using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeixeEspada_MeeleAttackState : MeeleAttackState
{
    private PeixeEspada enemy;
    public PeixeEspada_MeeleAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeeleAttack stateData, PeixeEspada enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isAnimationFinished)
        {
            stateMachine.ChangeState(enemy.ChargeState);
        }
    }
}
