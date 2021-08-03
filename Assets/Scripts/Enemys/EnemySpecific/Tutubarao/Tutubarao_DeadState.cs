using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutubarao_DeadState : DeadState
{
    private Tutubarao enemy;
    public Tutubarao_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, Tutubarao enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        entity.timeToFlee = false;
        for (int i = 0; i < 3; i++)
        {
            GameObject.Instantiate(stateData.itens[entity.randomN], entity.transform.position, Quaternion.identity);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
