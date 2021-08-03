using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutubarao_MoveState : MoveState
{
    private Tutubarao enemy;
    private bool fleeTime;
    private Pexe[] pexe;
    public Tutubarao_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Tutubarao enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        pexe = GameObject.FindObjectsOfType<Pexe>();
        fleeTime = core.CollisionSenses.FleeTime; 

        if(fleeTime)
        {
            NewAudioManager.instance.Play("danger");
            NewAudioManager.instance.Pause("bubbles");
            for (int i = 0; i < pexe.Length; i++)
            {
                pexe[i].timeToFlee = true;
            }
            entity.timeToFlee = true;
        }
        if (isDetectingWall)
        {
            stateMachine.ChangeState(enemy.IdleState);
        }
        else if (isPlayerInMaxAggroRange)
        {
            stateMachine.ChangeState(enemy.PlayerDetectState);
        }
        else if (isDetectingWall && Time.time >= startTime + stateData.movementSpeed)
        {
            entity.Teleport();
            stateMachine.ChangeState(enemy.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
    }
}
