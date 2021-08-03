using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pexe_DeadState : DeadState
{
    private Pexe enemy;
    public Pexe_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, Pexe enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        if (enemy.transform.position.x >= 0)
            core.Movements.SetVelocity(10, new Vector2(-45, -45), -1);
        else
            core.Movements.SetVelocity(10, new Vector2(-45, -45), 1);
    }
}
