using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(NewPlayer player, PlayerStateMachine stateMachine, NewPlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        core.Movements.SetVelocityX(0f);
        player.GetComponent<BoxCollider2D>().enabled = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if((xInput != 0 || yInput !=0) && !isExitingState)
        {
            if (player.currentHealth >= 15)
                stateMachine.ChangeState(player.MoveState);
            else if (player.currentHealth > 5 && player.currentHealth < 15)
                stateMachine.ChangeState(player.Damage1MoveState);
            else if ( player.currentHealth == 5)
                stateMachine.ChangeState(player.Damage2MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
