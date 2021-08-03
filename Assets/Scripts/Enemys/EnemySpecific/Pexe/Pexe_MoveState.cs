using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pexe_MoveState : MoveState
{
    private Pexe enemy;
    public Pexe_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Pexe enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        if(stateMachine.currentState == enemy.FleeState)
        {
            if (enemy.transform.position.x >= 0)
                core.Movements.SetVelocity(stateData.fleeSpeed, new Vector2(-45, -45), -1);
            else
                core.Movements.SetVelocity(stateData.fleeSpeed, new Vector2(-45, -45), 1);
        }
    }
}
