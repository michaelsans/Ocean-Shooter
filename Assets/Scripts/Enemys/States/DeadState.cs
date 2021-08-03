using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    protected D_DeadState stateData;
    public DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Dochecks()
    {
        base.Dochecks();
        
    }

    public override void Enter()
    {
        base.Enter();

        GameObject.Instantiate(stateData.itens[entity.randomN], entity.transform.position, Quaternion.identity);
        core.Movements.SetVelocityToZero();
        core.Movements.SetVelocityX(10);
        foreach (Collider2D c in entity.GetComponents<Collider2D>())
        {
            c.enabled = false;
        }
        entity.gameObject.GetComponent<Entity>().enabled = false;
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
