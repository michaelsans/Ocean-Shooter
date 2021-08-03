using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(NewPlayer player, PlayerStateMachine stateMachine, NewPlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        NewAudioManager.instance.Volume("motor", .5f);
    }

    public override void Exit()
    {
        base.Exit();
        NewAudioManager.instance.Volume("motor", .2f);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


        core.Movements.SetVelocityX(playerData.movementVelocity * xInput);
        core.Movements.SetVelocityY(playerData.movementVelocity * yInput); 

        if (xInput == 0 && yInput == 0 && !isExitingState)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
